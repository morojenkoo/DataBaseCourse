using System;
using System.Data;
using System.Windows.Forms;
using Npgsql;
using HospitalApp.DataBase;

namespace HospitalApp.Forms
{
    public partial class WardForm : Form
    {
        private readonly DataBaseHelper dbHelper;
        private int currentWardId = 0;
        private readonly int departmentId;
        
        public WardForm(int deptId)
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            departmentId = deptId;
            LoadWards();
        }

        private void LoadWards()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            Ward_number AS Номер_палаты,
                            Bed_count AS Количество_мест,
                            CASE WHEN VIP_status = B'1' THEN 'VIP' ELSE 'Обычная' END AS VIP_статус,
                            Isolation_status AS Уровень_изоляции
                        FROM Ward 
                        WHERE Department_ID = @deptId
                        ORDER BY Ward_number";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@deptId", departmentId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var dt = new DataTable();
                            dt.Load(reader);
                            dgvWards.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }

        private void dgvWards_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvWards.Rows[e.RowIndex];
            if (row.Cells["Номер_палаты"].Value == null || row.Cells["Номер_палаты"].Value == DBNull.Value)
                return;
            int wardNumber = Convert.ToInt32(row.Cells["Номер_палаты"].Value);

            using (var conn = dbHelper.GetConnection())
            {
                conn.Open();
                string query = "SELECT Ward_ID FROM Ward WHERE Department_ID = @deptId AND Ward_number = @wardNumber";
                using (var cmd = new NpgsqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@deptId", departmentId);
                    cmd.Parameters.AddWithValue("@wardNumber", wardNumber);
                    currentWardId = Convert.ToInt32(cmd.ExecuteScalar());
                    RefreshStatsAndPatients();
                }
            }

            txtWardNumber.Text = wardNumber.ToString();
            txtBedCount.Text = row.Cells["Количество_мест"].Value.ToString();
            cmbVipStatus.SelectedItem = row.Cells["VIP_статус"].Value.ToString();
            txtIsolationStatus.Text = row.Cells["Уровень_изоляции"].Value.ToString();
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
                        INSERT INTO Ward (Ward_number, Bed_count, VIP_status, Isolation_status, Department_ID)
                        VALUES (@wardNumber, @bedCount, @vipStatus, @isolationStatus, @deptId)";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardNumber", Convert.ToInt32(txtWardNumber.Text));
                        cmd.Parameters.AddWithValue("@bedCount", Convert.ToInt32(txtBedCount.Text));
                        cmd.Parameters.Add("@vipStatus", NpgsqlTypes.NpgsqlDbType.Bit).Value = cmbVipStatus.SelectedIndex == 0;
                        cmd.Parameters.AddWithValue("@isolationStatus", txtIsolationStatus.Text);
                        cmd.Parameters.AddWithValue("@deptId", departmentId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Палата добавлена");
                ClearFields();
                LoadWards();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentWardId == 0)
            {
                MessageBox.Show("Выберите палату из списка");
                return;
            }

            if (!ValidateFields()) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Ward 
                        SET Ward_number = @wardNumber, 
                            Bed_count = @bedCount, 
                            VIP_status = @vipStatus, 
                            Isolation_status = @isolationStatus
                        WHERE Ward_ID = @wardId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardNumber", Convert.ToInt32(txtWardNumber.Text));
                        cmd.Parameters.AddWithValue("@bedCount", Convert.ToInt32(txtBedCount.Text));
                        cmd.Parameters.Add("@vipStatus", NpgsqlTypes.NpgsqlDbType.Bit).Value = cmbVipStatus.SelectedIndex == 0;
                        cmd.Parameters.AddWithValue("@isolationStatus", txtIsolationStatus.Text);
                        cmd.Parameters.AddWithValue("@wardId", currentWardId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Палата обновлена");
                ClearFields();
                LoadWards();
                currentWardId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentWardId == 0)
            {
                MessageBox.Show("Выберите палату из списка");
                return;
            }

            if (MessageBox.Show("Удалить палату? Это действие нельзя отменить.", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = dbHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Ward WHERE Ward_ID = @wardId";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@wardId", currentWardId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Палата удалена");
                    ClearFields();
                    LoadWards();
                    currentWardId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }
        private void btnRefreshStats_Click(object sender, EventArgs e)
        {
            RefreshStatsAndPatients();
        }
        private void btnAddAnamnesis_Click(object sender, EventArgs e)
        {
            if (currentWardId == 0)
            {
                MessageBox.Show("Выберите палату из списка");
                return;
            }

            if (!int.TryParse(txtAnamnesisId.Text, out int anamnesisId))
            {
                MessageBox.Show("Введите корректный номер истории болезни");
                return;
            }

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    // 1. Проверяем существование анамнеза и его статус
                    string checkQuery = @"
                        SELECT Date_of_discharge 
                        FROM Anamnesis 
                        WHERE Anamnesis_ID = @anamnesisId";

                    using (var cmd = new NpgsqlCommand(checkQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@anamnesisId", anamnesisId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (!reader.Read())
                            {
                                MessageBox.Show("Анамнез с таким номером не найден");
                                return;
                            }

                            if (reader["Date_of_discharge"] != DBNull.Value)
                            {
                                MessageBox.Show("Этот пациент уже выписан. Нельзя добавить в палату.");
                                return;
                            }
                        }
                    }

                    // 2. Проверяем, есть ли свободное место в палате
                    string capacityQuery = @"
                        SELECT 
                            Bed_count,
                            (SELECT COUNT(*) FROM Anamnesis 
                             WHERE Ward_ID = @wardId AND Date_of_discharge IS NULL) AS Occupied
                        FROM Ward 
                        WHERE Ward_ID = @wardId";

                    using (var cmd = new NpgsqlCommand(capacityQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardId", currentWardId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int bedCount = reader.GetInt32(0);
                                int occupied = reader.GetInt32(1);
                                
                                if (occupied >= bedCount)
                                {
                                    MessageBox.Show($"В палате нет свободных мест. Всего мест: {bedCount}, занято: {occupied}");
                                    return;
                                }
                            }
                        }
                    }

                    // 3. Обновляем Ward_ID у анамнеза
                    string updateQuery = "UPDATE Anamnesis SET Ward_ID = @wardId WHERE Anamnesis_ID = @anamnesisId";
                    using (var cmd = new NpgsqlCommand(updateQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardId", currentWardId);
                        cmd.Parameters.AddWithValue("@anamnesisId", anamnesisId);
                        int rows = cmd.ExecuteNonQuery();
                        
                        if (rows > 0)
                        {
                            MessageBox.Show("Анамнез успешно добавлен в палату");
                            RefreshStatsAndPatients();
                            txtAnamnesisId.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("Ошибка при добавлении анамнеза");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
        private void btnDischarge_Click(object sender, EventArgs e)
        {
            if (currentWardId == 0)
            {
                MessageBox.Show("Выберите палату из списка");
                return;
            }
            dgvPatientsInWard.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            if (dgvPatientsInWard.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите пациента из списка для выписки");
                return;
            }

            string fio = dgvPatientsInWard.SelectedRows[0].Cells["ФИО"].Value.ToString();

            if (MessageBox.Show($"Выписать пациента {fio}?", "Подтверждение", MessageBoxButtons.YesNo) != DialogResult.Yes)
                return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    // Находим анамнез пациента в этой палате (не выписанный)
                    string findQuery = @"
                        SELECT Anamnesis_ID 
                        FROM Anamnesis 
                        WHERE Ward_ID = @wardId AND Date_of_discharge IS NULL
                        AND Patient_ID = (
                            SELECT Patient_ID FROM Anamnesis 
                            WHERE Ward_ID = @wardId AND Date_of_discharge IS NULL
                            LIMIT 1
                        )";

                    // Проще: по выбранному пациенту найти его активный анамнез
                    string findPatientQuery = @"
                        SELECT a.Anamnesis_ID 
                        FROM Anamnesis a
                        JOIN Patient p ON a.Patient_ID = p.Patient_ID
                        WHERE a.Ward_ID = @wardId 
                          AND a.Date_of_discharge IS NULL
                          AND (p.Surname || ' ' || p.Name || ' ' || COALESCE(p.Patronymic, '')) = @fio";

                    using (var cmd = new NpgsqlCommand(findPatientQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardId", currentWardId);
                        cmd.Parameters.AddWithValue("@fio", fio);
                        var result = cmd.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Не найден активный анамнез для выбранного пациента");
                            return;
                        }

                        int anamnesisId = Convert.ToInt32(result);

                        // Обновляем дату выписки
                        string updateQuery = "UPDATE Anamnesis SET Date_of_discharge = @today, Ward_ID = NULL WHERE Anamnesis_ID = @id";
                        using (var updateCmd = new NpgsqlCommand(updateQuery, conn))
                        {
                            updateCmd.Parameters.AddWithValue("@today", DateTime.Now.Date);
                            updateCmd.Parameters.AddWithValue("@id", anamnesisId);
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show("Пациент выписан");
                RefreshStatsAndPatients(); // Обновляем статистику и список пациентов
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при выписке: " + ex.Message);
            }
        }
        private void RefreshStatsAndPatients()
        {
            if (currentWardId == 0) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();

                    // Статистика
                    string statsQuery = @"
                        SELECT 
                            COUNT(*) AS Occupied,
                            (SELECT Bed_count FROM Ward WHERE Ward_ID = @wardId) AS Total
                        FROM Anamnesis
                        WHERE Ward_ID = @wardId AND Date_of_discharge IS NULL";

                    using (var cmd = new NpgsqlCommand(statsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardId", currentWardId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int occupied = reader["Occupied"] != DBNull.Value ? Convert.ToInt32(reader["Occupied"]) : 0;
                                int total = reader["Total"] != DBNull.Value ? Convert.ToInt32(reader["Total"]) : 0;
                                int free = total - occupied;
                                lblStats.Text = $"Статистика: занято {occupied} из {total}. Свободно: {free}";
                            }
                        }
                    }

                    // Список пациентов в палате
                    string patientsQuery = @"
                        SELECT 
                            p.Surname || ' ' || p.Name || ' ' || COALESCE(p.Patronymic, '') AS ФИО,
                            a.Date_of_arrive AS Дата_поступления
                        FROM Anamnesis a
                        JOIN Patient p ON a.Patient_ID = p.Patient_ID
                        WHERE a.Ward_ID = @wardId AND a.Date_of_discharge IS NULL
                        ORDER BY a.Date_of_arrive";

                    using (var cmd = new NpgsqlCommand(patientsQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardId", currentWardId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var dt = new DataTable();
                            dt.Load(reader);
                            dgvPatientsInWard.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления данных палаты: " + ex.Message);
            }
        }
        private bool ValidateFields()
        {
            if (string.IsNullOrWhiteSpace(txtWardNumber.Text) ||
                string.IsNullOrWhiteSpace(txtBedCount.Text) ||
                string.IsNullOrWhiteSpace(txtIsolationStatus.Text))
            {
                MessageBox.Show("Заполните все поля");
                return false;
            }
            return true;
        }

        private void ClearFields()
        {
            txtWardNumber.Text = "";
            txtBedCount.Text = "";
            cmbVipStatus.SelectedIndex = 0;
            txtIsolationStatus.Text = "";
            currentWardId = 0;
        }
    }
}