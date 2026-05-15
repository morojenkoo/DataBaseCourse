using System.Data;
using Npgsql;
using HospitalApp.DataBase;

namespace HospitalApp.Forms
{
    public partial class DepartmentForm : Form
    {
        private DataBaseHelper dbHelper;
        private int currentDepartmentId = 0;

        public DepartmentForm()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            LoadDepartments();
        }
        private void LoadDepartments()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            Department_name AS Название,
                            Floor_number AS Этаж,
                            Inner_phone AS Внутренний_телефон
                        FROM Department
                        ORDER BY Department_name";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dgvDepartments.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            Department_name AS Название,
                            Floor_number AS Этаж,
                            Inner_phone AS Внутренний_телефон
                        FROM Department
                        WHERE Department_name ILIKE @name
                        ORDER BY Department_name";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", "%" + txtSearchName.Text + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            var dt = new DataTable();
                            dt.Load(reader);
                            dgvDepartments.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message);
            }
        }
        private void dgvDepartments_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvDepartments.Rows[e.RowIndex];
            string deptName = row.Cells["Название"].Value.ToString();
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Department_ID FROM Department WHERE Department_name = @name";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@name", deptName);
                    currentDepartmentId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            txtDepartmentName.Text = deptName;
            txtFloorNumber.Text = row.Cells["Этаж"].Value.ToString();
            txtInnerPhone.Text = row.Cells["Внутренний_телефон"].Value.ToString();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Department (Department_name, Floor_number, Inner_phone)
                        VALUES (@name, @floor, @phone)";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtDepartmentName.Text);
                        cmd.Parameters.AddWithValue("@floor", Convert.ToInt32(txtFloorNumber.Text));
                        cmd.Parameters.AddWithValue("@phone", txtInnerPhone.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Отделение добавлено");
                ClearFields();
                LoadDepartments();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentDepartmentId == 0)
            {
                MessageBox.Show("Выберите отделение из списка");
                return;
            }
            if (!ValidateFields()) return;
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Department 
                        SET Department_name = @name, 
                            Floor_number = @floor, 
                            Inner_phone = @phone
                        WHERE Department_ID = @id";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", txtDepartmentName.Text);
                        cmd.Parameters.AddWithValue("@floor", Convert.ToInt32(txtFloorNumber.Text));
                        cmd.Parameters.AddWithValue("@phone", txtInnerPhone.Text);
                        cmd.Parameters.AddWithValue("@id", currentDepartmentId);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Отделение обновлено");
                ClearFields();
                LoadDepartments();
                currentDepartmentId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentDepartmentId == 0)
            {
                MessageBox.Show("Выберите отделение из списка");
                return;
            }
            if (MessageBox.Show("Удалить отделение? Все связанные палаты и сотрудники будут удалены!",
                "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = dbHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Department WHERE Department_ID = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentDepartmentId);
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Отделение удалено");
                    ClearFields();
                    LoadDepartments();
                    currentDepartmentId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }
        private void btnWards_Click(object sender, EventArgs e)
        {
            if (currentDepartmentId == 0)
            {
                MessageBox.Show("Выберите отделение из списка");
                return;
            }

            var wardForm = new WardForm(currentDepartmentId);
            wardForm.ShowDialog();
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtDepartmentName.Text) ||
                string.IsNullOrWhiteSpace(txtFloorNumber.Text) ||
                string.IsNullOrWhiteSpace(txtInnerPhone.Text))
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            return true;
        }
        private void ClearFields()
        {
            txtDepartmentName.Text = "";
            txtFloorNumber.Text = "";
            txtInnerPhone.Text = "";
            currentDepartmentId = 0;
        }
    }
}