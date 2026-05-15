using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using HospitalApp.DataBase;
using NpgsqlTypes;

namespace HospitalApp.Forms
{
    public partial class PatientForm : Form
    {
        private readonly DataBaseHelper dbHelper;
        private int currentPatientId = 0;

        public PatientForm()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            LoadPatients();

            // Заполнение ComboBox для пола
            cmbGender.Items.Add("Мужской");
            cmbGender.Items.Add("Женский");
            cmbGender.SelectedIndex = 0;
        }

        // Загрузка списка пациентов
        private void LoadPatients()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            Surname AS Фамилия,
                            Name AS Имя,
                            Patronymic AS Отчество,
                            CASE WHEN Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Пол,
                            Date_of_birth AS Дата_рождения,
                            Polys_number AS Полис,
                            SNILS AS СНИЛС,
                            Passport_number AS Паспорт
                        FROM Patient
                        ORDER BY Surname, Name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dgvPatients.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void btnPatientSearch_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            Surname AS Фамилия,
                            Name AS Имя,
                            Patronymic AS Отчество,
                            CASE WHEN Gender = B'1' THEN 'Мужской' ELSE 'Женский' END AS Пол,
                            Date_of_birth AS Дата_рождения,
                            Polys_number AS Полис,
                            SNILS AS СНИЛС,
                            Passport_number AS Паспорт
                        FROM Patient
                        WHERE 1=1";

                    if (!string.IsNullOrWhiteSpace(txtSearchSurname.Text))
                    {
                        string searchTerm = txtSearchSurname.Text.Trim();
                        string[] parts = searchTerm.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                
                        if (parts.Length == 1)
                        {
                            query += $" AND (Surname ILIKE '%{parts[0]}%' OR Name ILIKE '%{parts[0]}%' OR Patronymic ILIKE '%{parts[0]}%')";
                        }
                        else if (parts.Length == 2)
                        {
                            query += $" AND Surname ILIKE '%{parts[0]}%' AND Name ILIKE '%{parts[1]}%'";
                        }
                        else if (parts.Length >= 3)
                        {
                            query += $" AND Surname ILIKE '%{parts[0]}%' AND Name ILIKE '%{parts[1]}%' AND Patronymic ILIKE '%{parts[2]}%'";
                        }
                    }
                    if (!string.IsNullOrWhiteSpace(txtSearchPassport.Text))
                        query += $" AND Passport_number ILIKE '%{txtSearchPassport.Text}%'";

                    query += " ORDER BY Surname, Name";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        dgvPatients.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска: " + ex.Message);
            }
        }

        

        // Выбор строки в таблице
        private void dgvPatients_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvPatients.Rows[e.RowIndex];
            string surname = row.Cells["Фамилия"].Value.ToString();
            string name = row.Cells["Имя"].Value.ToString();
            string patronymic = row.Cells["Отчество"].Value.ToString();

            // Получаем Patient_ID
            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = @"
                    SELECT Patient_ID FROM Patient 
                    WHERE Surname = @surname AND Name = @name 
                    AND (Patronymic = @patronymic OR (Patronymic IS NULL AND @patronymic IS NULL))";
                
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@surname", surname);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@patronymic", string.IsNullOrEmpty(patronymic) ? DBNull.Value : (object)patronymic);
                    currentPatientId = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }

            // Заполнение полей
            txtSurname.Text = surname;
            txtName.Text = name;
            txtPatronymic.Text = patronymic;
            cmbGender.SelectedItem = row.Cells["Пол"].Value.ToString();
            object dateObj = row.Cells["Дата_рождения"].Value;
            if (dateObj != null && dateObj != DBNull.Value)
            {
                dtpBirthDate.Value = Convert.ToDateTime(dateObj.ToString());
            }
            txtPolysNumber.Text = row.Cells["Полис"].Value.ToString();
            txtSnils.Text = row.Cells["СНИЛС"].Value.ToString();
            txtPassport.Text = row.Cells["Паспорт"].Value.ToString();
        }

        // Добавление
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateFields()) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Patient (Surname, Name, Patronymic, Gender, Date_of_birth, 
                                            Polys_number, SNILS, Passport_number)
                        VALUES (@surname, @name, @patronymic, @gender, @dob, 
                                @polys, @snils, @passport)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@patronymic", string.IsNullOrEmpty(txtPatronymic.Text) ? DBNull.Value : (object)txtPatronymic.Text);
                        cmd.Parameters.Add("@gender", NpgsqlTypes.NpgsqlDbType.Bit).Value = cmbGender.SelectedIndex == 0;                        
                        cmd.Parameters.AddWithValue("@dob", dtpBirthDate.Value);
                        cmd.Parameters.AddWithValue("@polys", string.IsNullOrEmpty(txtPolysNumber.Text) ? DBNull.Value : (object)txtPolysNumber.Text);
                        cmd.Parameters.AddWithValue("@snils", string.IsNullOrEmpty(txtSnils.Text) ? DBNull.Value : (object)txtSnils.Text);
                        cmd.Parameters.AddWithValue("@passport", txtPassport.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Пациент добавлен");
                ClearFields();
                LoadPatients();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        // Обновление
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentPatientId == 0)
            {
                MessageBox.Show("Выберите пациента из списка");
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Patient 
                        SET Surname = @surname, Name = @name, Patronymic = @patronymic,
                            Gender = @gender, Date_of_birth = @dob,
                            Polys_number = @polys, SNILS = @snils, Passport_number = @passport
                        WHERE Patient_ID = @id";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@surname", txtSurname.Text);
                        cmd.Parameters.AddWithValue("@name", txtName.Text);
                        cmd.Parameters.AddWithValue("@patronymic", string.IsNullOrEmpty(txtPatronymic.Text) ? DBNull.Value : (object)txtPatronymic.Text);
                        cmd.Parameters.Add("@gender", NpgsqlTypes.NpgsqlDbType.Bit).Value = cmbGender.SelectedIndex == 0;   
                        cmd.Parameters.AddWithValue("@dob", dtpBirthDate.Value.Date);
                        cmd.Parameters.AddWithValue("@polys", string.IsNullOrEmpty(txtPolysNumber.Text) ? DBNull.Value : (object)txtPolysNumber.Text);
                        cmd.Parameters.AddWithValue("@snils", string.IsNullOrEmpty(txtSnils.Text) ? DBNull.Value : (object)txtSnils.Text);
                        cmd.Parameters.AddWithValue("@passport", txtPassport.Text);
                        cmd.Parameters.AddWithValue("@id", currentPatientId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Пациент обновлён");
                ClearFields();
                LoadPatients();
                currentPatientId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        // Удаление
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentPatientId == 0)
            {
                MessageBox.Show("Выберите пациента из списка");
                return;
            }

            if (MessageBox.Show("Удалить пациента? Все его анамнезы будут удалены!",
                "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = dbHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Patient WHERE Patient_ID = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentPatientId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Пациент удалён");
                    ClearFields();
                    LoadPatients();
                    currentPatientId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }



        // Переход к анамнезам (пока заглушка)
        private void btnAnamnesis_Click(object sender, EventArgs e)
        {
            if (currentPatientId == 0)
            {
                MessageBox.Show("Выберите пациента из списка");
                return;
            }

            string patientName = $"{txtSurname.Text} {txtName.Text} {txtPatronymic.Text}".Trim();
            var anamnesisForm = new AnamnesisForm(currentPatientId, patientName);
            anamnesisForm.ShowDialog();
        }

        // Вспомогательные методы
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtSurname.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtPassport.Text))
            {
                MessageBox.Show("Заполните обязательные поля: Фамилия, Имя, Паспорт");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtSurname.Text = "";
            txtName.Text = "";
            txtPatronymic.Text = "";
            cmbGender.SelectedIndex = 0;
            dtpBirthDate.Value = DateTime.Now.AddYears(-30);
            txtPolysNumber.Text = "";
            txtSnils.Text = "";
            txtPassport.Text = "";
            currentPatientId = 0;
        }
    }
}