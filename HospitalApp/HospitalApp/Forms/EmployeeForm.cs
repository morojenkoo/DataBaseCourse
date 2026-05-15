using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using HospitalApp.DataBase;

namespace HospitalApp.Forms
{
    public partial class EmployeeForm : Form
    {
        private readonly DataBaseHelper dbHelper;
        private int currentEmployeeId = 0;

        public EmployeeForm()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            LoadDepartments();
            LoadEmployees();
            rbDoctor.Checked = true;
        }

        private void LoadDepartments()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Department_ID, Department_name FROM Department ORDER BY Department_name";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        cmbDepartment.DisplayMember = "Department_name";
                        cmbDepartment.ValueMember = "Department_ID";
                        cmbDepartment.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки отделений: " + ex.Message);
            }
        }

        private void LoadEmployees()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                SELECT 
                    e.Employee_ID,
                    e.Surname AS Фамилия,
                    e.Name AS Имя,
                    e.Patronymic AS Отчество,
                    CASE WHEN e.Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Пол,
                    e.Date_of_birth AS Дата_рождения,
                    e.Phone_number AS Телефон,
                    CASE e.Position 
                        WHEN 1 THEN 'Доктор' 
                        WHEN 2 THEN 'Медсестра' 
                        WHEN 3 THEN 'Санитар' 
                    END AS Должность,
                    d.Department_name AS Отделение,
                    e.Passport_number AS Паспорт
                FROM Employee e
                JOIN Department d ON e.Department_ID = d.Department_ID
                ORDER BY e.Surname, e.Name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dgvEmployees.DataSource = dt;

                        // Скрываем колонку Employee_ID
                        if (dgvEmployees.Columns["Employee_ID"] != null)
                            dgvEmployees.Columns["Employee_ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки сотрудников: " + ex.Message);
            }
        }

        private void rbPosition_CheckedChanged(object sender, EventArgs e)
        {
            pnlDoctor.Visible = rbDoctor.Checked;
            pnlNurse.Visible = rbNurse.Checked;
            pnlSanitar.Visible = rbSanitar.Checked;
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
                    e.Employee_ID,
                    e.Surname AS Фамилия,
                    e.Name AS Имя,
                    e.Patronymic AS Отчество,
                    CASE WHEN e.Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Пол,
                    e.Date_of_birth AS Дата_рождения,
                    e.Phone_number AS Телефон,
                    CASE e.Position 
                        WHEN 1 THEN 'Доктор' 
                        WHEN 2 THEN 'Медсестра' 
                        WHEN 3 THEN 'Санитар' 
                    END AS Должность,
                    d.Department_name AS Отделение,
                    e.Passport_number AS Паспорт
                FROM Employee e
                JOIN Department d ON e.Department_ID = d.Department_ID
                WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(txtSearchSurname.Text))
                        query += $" AND e.Surname ILIKE '%{txtSearchSurname.Text}%'";
                    if (!string.IsNullOrWhiteSpace(txtSearchPassport.Text))
                        query += $" AND e.Passport_number ILIKE '%{txtSearchPassport.Text}%'";

                    query += " ORDER BY e.Surname, e.Name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dgvEmployees.DataSource = dt;

                        if (dgvEmployees.Columns["Employee_ID"] != null)
                            dgvEmployees.Columns["Employee_ID"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message);
            }
        }

        private void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtSearchSurname.Text = "";
            txtSearchPassport.Text = "";
            LoadEmployees();
        }

        private void dgvEmployees_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvEmployees.Rows[e.RowIndex];
            currentEmployeeId = Convert.ToInt32(row.Cells["Employee_ID"].Value);

            txtSurname.Text = row.Cells["Фамилия"].Value.ToString();
            txtName.Text = row.Cells["Имя"].Value.ToString();
            txtPatronymic.Text = row.Cells["Отчество"].Value.ToString();
    
            string gender = row.Cells["Пол"].Value.ToString();
            rbMale.Checked = gender == "Мужской";
            rbFemale.Checked = gender == "Женский";
    
            object dateObj = row.Cells["Дата_рождения"].Value;
            if (dateObj != null && dateObj != DBNull.Value)
            {
                dtpBirthDate.Value = Convert.ToDateTime(dateObj.ToString());
            }
            txtPhone.Text = row.Cells["Телефон"].Value.ToString();
            txtPassport.Text = row.Cells["Паспорт"].Value.ToString();

            string position = row.Cells["Должность"].Value.ToString();
            if (position == "Доктор")
            {
                rbDoctor.Checked = true;
                LoadDoctorData();
            }
            else if (position == "Медсестра")
            {
                rbNurse.Checked = true;
                LoadNurseData();
            }
            else
            {
                rbSanitar.Checked = true;
                LoadSanitarData();
            }

            string departmentName = row.Cells["Отделение"].Value.ToString();
            for (int i = 0; i < cmbDepartment.Items.Count; i++)
            {
                DataRowView item = (DataRowView)cmbDepartment.Items[i];
                if (item["Department_name"].ToString() == departmentName)
                {
                    cmbDepartment.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadDoctorData()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT Specialization, Certificate_number, Academic_degree, Qualification, Rank
                        FROM Doctor
                        WHERE Employee_ID = @employeeId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtSpecialization.Text = reader["Specialization"].ToString();
                                txtCertificate.Text = reader["Certificate_number"].ToString();
                                txtAcademicDegree.Text = reader["Academic_degree"].ToString();
                                int qual = Convert.ToInt32(reader["Qualification"]);
                                cmbQualification.SelectedIndex = qual - 1;
                                txtRank.Text = reader["Rank"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных доктора: " + ex.Message);
            }
        }

        private void LoadNurseData()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT Certificate_number, Qualification, Rank
                        FROM Nurse
                        WHERE Employee_ID = @employeeId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtNurseCertificate.Text = reader["Certificate_number"].ToString();
                                int qual = Convert.ToInt32(reader["Qualification"]);
                                cmbNurseQualification.SelectedIndex = qual - 1;
                                txtNurseRank.Text = reader["Rank"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных медсестры: " + ex.Message);
            }
        }

        private void LoadSanitarData()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Admission FROM Sanitar WHERE Employee_ID = @employeeId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                        object result = cmd.ExecuteScalar();
                        chkAdmission.Checked = result != null && result.ToString() == "1";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки данных санитара: " + ex.Message);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateCommonFields()) return;

            int position = rbDoctor.Checked ? 1 : rbNurse.Checked ? 2 : 3;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        string insertEmployee = @"
                            INSERT INTO Employee (Surname, Name, Patronymic, Gender, Date_of_birth, 
                                Phone_number, Position, Department_ID, Passport_number)
                            VALUES (@surname, @name, @patronymic, @gender, @dob, 
                                @phone, @position, @deptId, @passport)
                            RETURNING Employee_ID";

                        int employeeId;
                        using (var cmd = new NpgsqlCommand(insertEmployee, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@patronymic", string.IsNullOrEmpty(txtPatronymic.Text) ? DBNull.Value : (object)txtPatronymic.Text);
                            cmd.Parameters.Add("@gender", NpgsqlTypes.NpgsqlDbType.Bit).Value = rbMale.Checked;
                            cmd.Parameters.AddWithValue("@dob", dtpBirthDate.Value.Date);
                            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                            cmd.Parameters.AddWithValue("@position", position);
                            cmd.Parameters.AddWithValue("@deptId", cmbDepartment.SelectedValue);
                            cmd.Parameters.AddWithValue("@passport", txtPassport.Text);
                            employeeId = (int)cmd.ExecuteScalar();
                        }

                        if (rbDoctor.Checked)
                        {
                            string insertDoctor = @"
                                INSERT INTO Doctor (Employee_ID, Position, Specialization, Certificate_number, 
                                    Academic_degree, Qualification, Rank)
                                VALUES (@employeeId, 1, @specialization, @certificate, @degree, @qualification, @rank)";

                            using (var cmd = new NpgsqlCommand(insertDoctor, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                                cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text);
                                cmd.Parameters.AddWithValue("@certificate", string.IsNullOrEmpty(txtCertificate.Text) ? DBNull.Value : (object)txtCertificate.Text);
                                cmd.Parameters.AddWithValue("@degree", txtAcademicDegree.Text);
                                cmd.Parameters.AddWithValue("@qualification", cmbQualification.SelectedIndex + 1);
                                cmd.Parameters.AddWithValue("@rank", txtRank.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (rbNurse.Checked)
                        {
                            string insertNurse = @"
                                INSERT INTO Nurse (Employee_ID, Position, Certificate_number, Qualification, Rank)
                                VALUES (@employeeId, 2, @certificate, @qualification, @rank)";

                            using (var cmd = new NpgsqlCommand(insertNurse, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                                cmd.Parameters.AddWithValue("@certificate", string.IsNullOrEmpty(txtNurseCertificate.Text) ? DBNull.Value : (object)txtNurseCertificate.Text);
                                cmd.Parameters.AddWithValue("@qualification", cmbNurseQualification.SelectedIndex + 1);
                                cmd.Parameters.AddWithValue("@rank", txtNurseRank.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (rbSanitar.Checked)
                        {
                            string insertSanitar = @"
                                INSERT INTO Sanitar (Employee_ID, Position, Admission)
                                VALUES (@employeeId, 3, @admission)";

                            using (var cmd = new NpgsqlCommand(insertSanitar, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", employeeId);
                                cmd.Parameters.Add("@admission", NpgsqlTypes.NpgsqlDbType.Bit).Value = chkAdmission.Checked;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                }

                MessageBox.Show("Сотрудник добавлен");
                ClearFields();
                LoadEmployees();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentEmployeeId == 0)
            {
                MessageBox.Show("Выберите сотрудника из списка");
                return;
            }

            if (!ValidateCommonFields()) return;

            int position = rbDoctor.Checked ? 1 : rbNurse.Checked ? 2 : 3;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    using (var tran = conn.BeginTransaction())
                    {
                        string updateEmployee = @"
                            UPDATE Employee 
                            SET Surname = @surname, Name = @name, Patronymic = @patronymic,
                                Gender = @gender, Date_of_birth = @dob,
                                Phone_number = @phone, Position = @position,
                                Department_ID = @deptId, Passport_number = @passport
                            WHERE Employee_ID = @employeeId";

                        using (var cmd = new NpgsqlCommand(updateEmployee, conn, tran))
                        {
                            cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                            cmd.Parameters.AddWithValue("@name", txtName.Text);
                            cmd.Parameters.AddWithValue("@patronymic", string.IsNullOrEmpty(txtPatronymic.Text) ? DBNull.Value : (object)txtPatronymic.Text);
                            cmd.Parameters.Add("@gender", NpgsqlTypes.NpgsqlDbType.Bit).Value = rbMale.Checked;
                            cmd.Parameters.AddWithValue("@dob", dtpBirthDate.Value.Date);
                            cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                            cmd.Parameters.AddWithValue("@position", position);
                            cmd.Parameters.AddWithValue("@deptId", cmbDepartment.SelectedValue);
                            cmd.Parameters.AddWithValue("@passport", txtPassport.Text);
                            cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                            cmd.ExecuteNonQuery();
                        }

                        if (rbDoctor.Checked)
                        {
                            // Сначала удаляем старые данные
                            string deleteDoctor = "DELETE FROM Doctor WHERE Employee_ID = @employeeId";
                            using (var cmd = new NpgsqlCommand(deleteDoctor, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                                cmd.ExecuteNonQuery();
                            }

                            string insertDoctor = @"
                                INSERT INTO Doctor (Employee_ID, Position, Specialization, Certificate_number, 
                                    Academic_degree, Qualification, Rank)
                                VALUES (@employeeId, 1, @specialization, @certificate, @degree, @qualification, @rank)";

                            using (var cmd = new NpgsqlCommand(insertDoctor, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                                cmd.Parameters.AddWithValue("@specialization", txtSpecialization.Text);
                                cmd.Parameters.AddWithValue("@certificate", string.IsNullOrEmpty(txtCertificate.Text) ? DBNull.Value : (object)txtCertificate.Text);
                                cmd.Parameters.AddWithValue("@degree", txtAcademicDegree.Text);
                                cmd.Parameters.AddWithValue("@qualification", cmbQualification.SelectedIndex + 1);
                                cmd.Parameters.AddWithValue("@rank", txtRank.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (rbNurse.Checked)
                        {
                            string deleteNurse = "DELETE FROM Nurse WHERE Employee_ID = @employeeId";
                            using (var cmd = new NpgsqlCommand(deleteNurse, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                                cmd.ExecuteNonQuery();
                            }

                            string insertNurse = @"
                                INSERT INTO Nurse (Employee_ID, Position, Certificate_number, Qualification, Rank)
                                VALUES (@employeeId, 2, @certificate, @qualification, @rank)";

                            using (var cmd = new NpgsqlCommand(insertNurse, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                                cmd.Parameters.AddWithValue("@certificate", string.IsNullOrEmpty(txtNurseCertificate.Text) ? DBNull.Value : (object)txtNurseCertificate.Text);
                                cmd.Parameters.AddWithValue("@qualification", cmbNurseQualification.SelectedIndex + 1);
                                cmd.Parameters.AddWithValue("@rank", txtNurseRank.Text);
                                cmd.ExecuteNonQuery();
                            }
                        }
                        else if (rbSanitar.Checked)
                        {
                            string deleteSanitar = "DELETE FROM Sanitar WHERE Employee_ID = @employeeId";
                            using (var cmd = new NpgsqlCommand(deleteSanitar, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                                cmd.ExecuteNonQuery();
                            }

                            string insertSanitar = @"
                                INSERT INTO Sanitar (Employee_ID, Position, Admission)
                                VALUES (@employeeId, 3, @admission)";

                            using (var cmd = new NpgsqlCommand(insertSanitar, conn, tran))
                            {
                                cmd.Parameters.AddWithValue("@employeeId", currentEmployeeId);
                                cmd.Parameters.Add("@admission", NpgsqlTypes.NpgsqlDbType.Bit).Value = chkAdmission.Checked;
                                cmd.ExecuteNonQuery();
                            }
                        }

                        tran.Commit();
                    }
                }

                MessageBox.Show("Сотрудник обновлён");
                ClearFields();
                LoadEmployees();
                currentEmployeeId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentEmployeeId == 0)
            {
                MessageBox.Show("Выберите сотрудника из списка");
                return;
            }

            if (MessageBox.Show("Удалить сотрудника?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = dbHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Employee WHERE Employee_ID = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentEmployeeId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Сотрудник удалён");
                    ClearFields();
                    LoadEmployees();
                    currentEmployeeId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private bool ValidateCommonFields()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPhone.Text) ||
                string.IsNullOrWhiteSpace(txtPassport.Text) ||
                cmbDepartment.SelectedItem == null)
            {
                MessageBox.Show("Заполните обязательные поля: Фамилия, Имя, Телефон, Паспорт, Отделение");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtSurname.Text = "";
            txtName.Text = "";
            txtPatronymic.Text = "";
            rbMale.Checked = true;
            dtpBirthDate.Value = DateTime.Now.AddYears(-30);
            txtPhone.Text = "";
            txtPassport.Text = "";
            if (cmbDepartment.Items.Count > 0) cmbDepartment.SelectedIndex = 0;
            rbDoctor.Checked = true;

            // Доктор
            txtSpecialization.Text = "";
            txtCertificate.Text = "";
            txtAcademicDegree.Text = "";
            cmbQualification.SelectedIndex = 0;
            txtRank.Text = "";

            // Медсестра
            txtNurseCertificate.Text = "";
            cmbNurseQualification.SelectedIndex = 0;
            txtNurseRank.Text = "";

            // Санитар
            chkAdmission.Checked = false;

            currentEmployeeId = 0;
        }
    }
}