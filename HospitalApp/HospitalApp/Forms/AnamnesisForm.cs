using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Npgsql;
using HospitalApp.DataBase;
using Newtonsoft.Json;

namespace HospitalApp.Forms
{
    public partial class AnamnesisForm : Form
    {
        private readonly DataBaseHelper dbHelper;
        private readonly int patientId;
        private string currentPatientName;
        private int currentAnamnesisId = 0;

        // Выбранные значения
        private int selectedWardId = 0;
        private int selectedAdmittingDoctorId = 0;
        private int selectedAttendingDoctorId = 0;

        public AnamnesisForm(int patientId, string patientName)
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
            this.patientId = patientId;
            this.currentPatientName = patientName;
            lblPatientName.Text = patientName;
            
            LoadAllergiesList();
            LoadBadHabitsList();
            LoadWards();
            LoadDoctors();
            LoadAnamnesis();
        }

        private void LoadAllergiesList()
        {
            clbAllergies.Items.Clear();
            clbAllergies.Items.Add("Пыльца", false);
            clbAllergies.Items.Add("Пенициллин", false);
            clbAllergies.Items.Add("Орехи", false);
            clbAllergies.Items.Add("Лактоза", false);
            clbAllergies.Items.Add("Цитрусовые", false);
            clbAllergies.Items.Add("Другое", false);
            
            clbAllergies.ItemCheck += clbAllergies_ItemCheck;
        }

        private void LoadBadHabitsList()
        {
            clbBadHabits.Items.Clear();
            clbBadHabits.Items.Add("Курение", false);
            clbBadHabits.Items.Add("Алкоголь", false);
            clbBadHabits.Items.Add("Наркотики", false);
            clbBadHabits.Items.Add("Переедание", false);
            clbBadHabits.Items.Add("Малоподвижный образ жизни", false);
            clbBadHabits.Items.Add("Другое", false);
            
            clbBadHabits.ItemCheck += clbBadHabits_ItemCheck;
        }

        private void clbAllergies_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                bool otherSelected = false;
                for (int i = 0; i < clbAllergies.Items.Count; i++)
                {
                    if (clbAllergies.GetItemChecked(i) && clbAllergies.Items[i].ToString() == "Другое")
                    {
                        otherSelected = true;
                        break;
                    }
                }
                txtOtherAllergy.Enabled = otherSelected;
                if (!otherSelected)
                    txtOtherAllergy.Text = "";
            }));
        }

        private void clbBadHabits_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            this.BeginInvoke(new Action(() =>
            {
                bool otherSelected = false;
                for (int i = 0; i < clbBadHabits.Items.Count; i++)
                {
                    if (clbBadHabits.GetItemChecked(i) && clbBadHabits.Items[i].ToString() == "Другое")
                    {
                        otherSelected = true;
                        break;
                    }
                }
                txtOtherBadHabit.Enabled = otherSelected;
                if (!otherSelected)
                    txtOtherBadHabit.Text = "";
            }));
        }

        private string GetSelectedItemsAsJson(CheckedListBox clb, TextBox txtOther, string otherItemText = "Другое")
        {
            var selected = new List<string>();
            foreach (var item in clb.CheckedItems)
            {
                string itemStr = item.ToString();
                if (itemStr == otherItemText)
                {
                    if (!string.IsNullOrWhiteSpace(txtOther.Text))
                        selected.Add($"\"{txtOther.Text.Trim()}\"");
                }
                else
                {
                    selected.Add($"\"{itemStr}\"");
                }
            }
            return "[" + string.Join(",", selected) + "]";
        }

        private void SetSelectedItemsFromJson(CheckedListBox clb, string json)
        {
            if (string.IsNullOrEmpty(json) || json == "[]") return;
            
            string trimmed = json.Trim('[', ']');
            var items = trimmed.Split(',');
            for (int i = 0; i < items.Length; i++)
                items[i] = items[i].Trim('"');
            
            for (int i = 0; i < clb.Items.Count; i++)
            {
                string itemText = clb.Items[i].ToString();
                clb.SetItemChecked(i, items.Contains(itemText));
            }
        }

        private void LoadWards()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Ward_ID, Ward_number FROM Ward ORDER BY Ward_number";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        // Не используем ComboBox, поиск отдельно
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки палат: " + ex.Message);
            }
        }

        private void LoadDoctors()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT e.Employee_ID, e.Surname, e.Name, e.Patronymic
                        FROM Employee e
                        JOIN Doctor d ON e.Employee_ID = d.Employee_ID
                        ORDER BY e.Surname";
                    using (var cmd = new NpgsqlCommand(query, conn))
                    using (var reader = cmd.ExecuteReader())
                    {
                        var dt = new DataTable();
                        dt.Load(reader);
                        // Не используем ComboBox, поиск отдельно
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки врачей: " + ex.Message);
            }
        }

        // Поиск палаты
        private void btnWardSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtWardSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT Ward_ID, Ward_number 
                        FROM Ward 
                        WHERE Ward_number::text ILIKE @search
                        ORDER BY Ward_number";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            lstWardResults.Items.Clear();
                            while (reader.Read())
                            {
                                var item = new { Id = reader.GetInt32(0), Number = reader.GetInt32(1) };
                                lstWardResults.Items.Add(item);
                                lstWardResults.DisplayMember = "Number";
                            }
                            lstWardResults.Visible = lstWardResults.Items.Count > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска палаты: " + ex.Message);
            }
        }

        private void lstWardResults_Click(object sender, EventArgs e)
        {
            if (lstWardResults.SelectedItem == null) return;
            dynamic selected = lstWardResults.SelectedItem;
            selectedWardId = selected.Id;
            lblSelectedWard.Text = $"Выбрано: палата {selected.Number}";
            lstWardResults.Visible = false;
        }

        // Поиск принимающего врача
        private void btnAdmittingDoctorSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtAdmittingDoctorSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT e.Employee_ID, e.Surname, e.Name, e.Patronymic
                        FROM Employee e
                        JOIN Doctor d ON e.Employee_ID = d.Employee_ID
                        WHERE e.Surname ILIKE @search
                        ORDER BY e.Surname";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            lstAdmittingDoctorResults.Items.Clear();
                            while (reader.Read())
                            {
                                string fullName = $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}".Trim();
                                var item = new { Id = reader.GetInt32(0), Name = fullName };
                                lstAdmittingDoctorResults.Items.Add(item);
                                lstAdmittingDoctorResults.DisplayMember = "Name";
                            }
                            lstAdmittingDoctorResults.Visible = lstAdmittingDoctorResults.Items.Count > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска врачей: " + ex.Message);
            }
        }

        private void lstAdmittingDoctorResults_Click(object sender, EventArgs e)
        {
            if (lstAdmittingDoctorResults.SelectedItem == null) return;
            dynamic selected = lstAdmittingDoctorResults.SelectedItem;
            selectedAdmittingDoctorId = selected.Id;
            lblSelectedAdmittingDoctor.Text = $"Выбрано: {selected.Name}";
            lstAdmittingDoctorResults.Visible = false;
        }

        // Поиск лечащего врача
        private void btnAttendingDoctorSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtAttendingDoctorSearch.Text.Trim();
            if (string.IsNullOrEmpty(searchText)) return;

            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT e.Employee_ID, e.Surname, e.Name, e.Patronymic
                        FROM Employee e
                        JOIN Doctor d ON e.Employee_ID = d.Employee_ID
                        WHERE e.Surname ILIKE @search
                        ORDER BY e.Surname";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@search", "%" + searchText + "%");
                        using (var reader = cmd.ExecuteReader())
                        {
                            lstAttendingDoctorResults.Items.Clear();
                            while (reader.Read())
                            {
                                string fullName = $"{reader.GetString(1)} {reader.GetString(2)} {reader.GetString(3)}".Trim();
                                var item = new { Id = reader.GetInt32(0), Name = fullName };
                                lstAttendingDoctorResults.Items.Add(item);
                                lstAttendingDoctorResults.DisplayMember = "Name";
                            }
                            lstAttendingDoctorResults.Visible = lstAttendingDoctorResults.Items.Count > 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка поиска врачей: " + ex.Message);
            }
        }

        private void lstAttendingDoctorResults_Click(object sender, EventArgs e)
        {
            if (lstAttendingDoctorResults.SelectedItem == null) return;
            dynamic selected = lstAttendingDoctorResults.SelectedItem;
            selectedAttendingDoctorId = selected.Id;
            lblSelectedAttendingDoctor.Text = $"Выбрано: {selected.Name}";
            lstAttendingDoctorResults.Visible = false;
        }

        private void LoadAnamnesis()
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        SELECT 
                            Anamnesis_ID,
                            Date_of_arrive,
                            Date_of_discharge,
                            Complaints,
                            Medical_history,
                            Allergies,
                            Bad_habits,
                            Blood_pressure_low,
                            Blood_pressure_high,
                            Pulse,
                            Saturation,
                            Skin,
                            Mucosal,
                            Thermometry,
                            Ward_ID,
                            Admitting_doctor_ID,
                            Attending_doctor_ID
                        FROM Anamnesis
                        WHERE Patient_ID = @patientId
                        ORDER BY Date_of_arrive DESC";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientId);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var dt = new DataTable();
                            dt.Load(reader);
                            dgvAnamnesis.DataSource = dt;

                            if (dgvAnamnesis.Columns["Anamnesis_ID"] != null)
                                dgvAnamnesis.Columns["Anamnesis_ID"].Visible = false;
                            if (dgvAnamnesis.Columns["Ward_ID"] != null)
                                dgvAnamnesis.Columns["Ward_ID"].Visible = false;
                            if (dgvAnamnesis.Columns["Admitting_doctor_ID"] != null)
                                dgvAnamnesis.Columns["Admitting_doctor_ID"].Visible = false;
                            if (dgvAnamnesis.Columns["Attending_doctor_ID"] != null)
                                dgvAnamnesis.Columns["Attending_doctor_ID"].Visible = false;

                            if (dgvAnamnesis.Columns["Date_of_arrive"] != null)
                                dgvAnamnesis.Columns["Date_of_arrive"].HeaderText = "Дата поступления";
                            if (dgvAnamnesis.Columns["Date_of_discharge"] != null)
                                dgvAnamnesis.Columns["Date_of_discharge"].HeaderText = "Дата выписки";
                            if (dgvAnamnesis.Columns["Complaints"] != null)
                                dgvAnamnesis.Columns["Complaints"].HeaderText = "Жалобы";
                            if (dgvAnamnesis.Columns["Medical_history"] != null)
                                dgvAnamnesis.Columns["Medical_history"].HeaderText = "История болезни";
                            if (dgvAnamnesis.Columns["Allergies"] != null)
                                dgvAnamnesis.Columns["Allergies"].HeaderText = "Аллергии";
                            if (dgvAnamnesis.Columns["Bad_habits"] != null)
                                dgvAnamnesis.Columns["Bad_habits"].HeaderText = "Вредные привычки";
                            if (dgvAnamnesis.Columns["Blood_pressure_low"] != null)
                                dgvAnamnesis.Columns["Blood_pressure_low"].HeaderText = "Давление (нижн.)";
                            if (dgvAnamnesis.Columns["Blood_pressure_high"] != null)
                                dgvAnamnesis.Columns["Blood_pressure_high"].HeaderText = "Давление (верхн.)";
                            if (dgvAnamnesis.Columns["Pulse"] != null)
                                dgvAnamnesis.Columns["Pulse"].HeaderText = "Пульс";
                            if (dgvAnamnesis.Columns["Saturation"] != null)
                                dgvAnamnesis.Columns["Saturation"].HeaderText = "Сатурация";
                            if (dgvAnamnesis.Columns["Skin"] != null)
                                dgvAnamnesis.Columns["Skin"].HeaderText = "Кожа";
                            if (dgvAnamnesis.Columns["Mucosal"] != null)
                                dgvAnamnesis.Columns["Mucosal"].HeaderText = "Слизистые";
                            if (dgvAnamnesis.Columns["Thermometry"] != null)
                                dgvAnamnesis.Columns["Thermometry"].HeaderText = "Температура";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки анамнезов: " + ex.Message);
            }
        }

        private void dgvAnamnesis_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dgvAnamnesis.Rows[e.RowIndex];
            currentAnamnesisId = Convert.ToInt32(row.Cells["Anamnesis_ID"].Value);

            object dateArriveObj = row.Cells["Date_of_arrive"].Value;
            if (dateArriveObj != null && dateArriveObj != DBNull.Value)
            {
                dtpDateOfArrive.Value = Convert.ToDateTime(dateArriveObj.ToString());
            }
            
            object dateDischargeObj = row.Cells["Date_of_discharge"].Value;
            if (dateDischargeObj != null && dateDischargeObj != DBNull.Value)
            {
                dtpDateOfDischarge.Checked = true;
                dtpDateOfDischarge.Value = Convert.ToDateTime(dateDischargeObj.ToString());
            }
            else
            {
                dtpDateOfDischarge.Checked = false;
            }
            
            txtComplaints.Text = row.Cells["Complaints"].Value.ToString();
            txtMedicalHistory.Text = row.Cells["Medical_history"].Value.ToString();
            txtBloodPressureLow.Text = row.Cells["Blood_pressure_low"].Value.ToString();
            txtBloodPressureHigh.Text = row.Cells["Blood_pressure_high"].Value.ToString();
            txtPulse.Text = row.Cells["Pulse"].Value.ToString();
            txtSaturation.Text = row.Cells["Saturation"].Value.ToString();
            txtSkin.Text = row.Cells["Skin"].Value.ToString();
            txtMucosal.Text = row.Cells["Mucosal"].Value.ToString();
            txtThermometry.Text = row.Cells["Thermometry"].Value.ToString();

            // Аллергии
            string allergiesJson = row.Cells["Allergies"].Value.ToString();
            var allergiesList = JsonConvert.DeserializeObject<List<string>>(allergiesJson);
            bool hasOtherAllergy = allergiesList.Any(a => !clbAllergies.Items.Cast<string>().Contains(a));
            if (hasOtherAllergy)
            {
                txtOtherAllergy.Enabled = true;
                var otherItems = allergiesList.Where(a => !clbAllergies.Items.Cast<string>().Contains(a)).ToList();
                txtOtherAllergy.Text = string.Join(", ", otherItems);
                for (int i = 0; i < clbAllergies.Items.Count; i++)
                {
                    if (clbAllergies.Items[i].ToString() == "Другое")
                    {
                        clbAllergies.SetItemChecked(i, true);
                        break;
                    }
                }
            }
            else
            {
                SetSelectedItemsFromJson(clbAllergies, allergiesJson);
            }

            // Вредные привычки
            string badHabitsJson = row.Cells["Bad_habits"].Value.ToString();
            var badHabitsList = JsonConvert.DeserializeObject<List<string>>(badHabitsJson);
            bool hasOtherBadHabit = badHabitsList.Any(b => !clbBadHabits.Items.Cast<string>().Contains(b));
            if (hasOtherBadHabit)
            {
                txtOtherBadHabit.Enabled = true;
                var otherItems = badHabitsList.Where(b => !clbBadHabits.Items.Cast<string>().Contains(b)).ToList();
                txtOtherBadHabit.Text = string.Join(", ", otherItems);
                for (int i = 0; i < clbBadHabits.Items.Count; i++)
                {
                    if (clbBadHabits.Items[i].ToString() == "Другое")
                    {
                        clbBadHabits.SetItemChecked(i, true);
                        break;
                    }
                }
            }
            else
            {
                SetSelectedItemsFromJson(clbBadHabits, badHabitsJson);
            }

            selectedWardId = Convert.ToInt32(row.Cells["Ward_ID"].Value);
            selectedAdmittingDoctorId = Convert.ToInt32(row.Cells["Admitting_doctor_ID"].Value);
            selectedAttendingDoctorId = Convert.ToInt32(row.Cells["Attending_doctor_ID"].Value);

            lblSelectedWard.Text = $"Выбрано: палата {selectedWardId}";
            lblSelectedAdmittingDoctor.Text = $"Выбрано: врач ID {selectedAdmittingDoctorId}";
            lblSelectedAttendingDoctor.Text = $"Выбрано: врач ID {selectedAttendingDoctorId}";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (selectedWardId == 0)
            {
                MessageBox.Show("Выберите палату");
                return;
            }
            if (selectedAdmittingDoctorId == 0)
            {
                MessageBox.Show("Выберите принимающего врача");
                return;
            }
            if (selectedAttendingDoctorId == 0)
            {
                MessageBox.Show("Выберите лечащего врача");
                return;
            }

            try
            {
                string allergiesJson = GetSelectedItemsAsJson(clbAllergies, txtOtherAllergy, "Другое");
                string badHabitsJson = GetSelectedItemsAsJson(clbBadHabits, txtOtherBadHabit, "Другое");

                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        INSERT INTO Anamnesis (
                            Patient_ID, Ward_ID, Admitting_doctor_ID, Attending_doctor_ID,
                            Date_of_arrive, Date_of_discharge, Complaints, Medical_history, Allergies, Bad_habits,
                            Blood_pressure_low, Blood_pressure_high, Pulse, Saturation,
                            Skin, Mucosal, Thermometry
                        ) VALUES (
                            @patientId, @wardId, @admittingDoctor, @attendingDoctor,
                            @date, @dateOfDischarge, @complaints, @medicalHistory, @allergies::jsonb, @badHabits::jsonb,
                            @bpLow, @bpHigh, @pulse, @saturation,
                            @skin, @mucosal, @thermometry
                        )";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@patientId", patientId);
                        cmd.Parameters.AddWithValue("@wardId", selectedWardId);
                        cmd.Parameters.AddWithValue("@admittingDoctor", selectedAdmittingDoctorId);
                        cmd.Parameters.AddWithValue("@attendingDoctor", selectedAttendingDoctorId);
                        cmd.Parameters.AddWithValue("@date", dtpDateOfArrive.Value.Date);
                        cmd.Parameters.AddWithValue("@dateOfDischarge", 
                            dtpDateOfDischarge.Checked ? (object)dtpDateOfDischarge.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@complaints", txtComplaints.Text);
                        cmd.Parameters.AddWithValue("@medicalHistory", txtMedicalHistory.Text);
                        cmd.Parameters.AddWithValue("@allergies", allergiesJson);
                        cmd.Parameters.AddWithValue("@badHabits", badHabitsJson);
                        cmd.Parameters.AddWithValue("@bpLow", Convert.ToInt32(txtBloodPressureLow.Text));
                        cmd.Parameters.AddWithValue("@bpHigh", Convert.ToInt32(txtBloodPressureHigh.Text));
                        cmd.Parameters.AddWithValue("@pulse", Convert.ToInt32(txtPulse.Text));
                        cmd.Parameters.AddWithValue("@saturation", Convert.ToInt32(txtSaturation.Text));
                        cmd.Parameters.AddWithValue("@skin", txtSkin.Text);
                        cmd.Parameters.AddWithValue("@mucosal", txtMucosal.Text);
                        cmd.Parameters.AddWithValue("@thermometry", Convert.ToDecimal(txtThermometry.Text));
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Анамнез добавлен");
                ClearFields();
                LoadAnamnesis();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка добавления: " + ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (currentAnamnesisId == 0)
            {
                MessageBox.Show("Выберите запись для обновления");
                return;
            }

            try
            {
                string allergiesJson = GetSelectedItemsAsJson(clbAllergies, txtOtherAllergy, "Другое");
                string badHabitsJson = GetSelectedItemsAsJson(clbBadHabits, txtOtherBadHabit, "Другое");

                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = @"
                        UPDATE Anamnesis SET
                            Ward_ID = @wardId,
                            Admitting_doctor_ID = @admittingDoctor,
                            Attending_doctor_ID = @attendingDoctor,
                            Date_of_arrive = @date,
                            Date_of_discharge = @dateOfDischarge,
                            Complaints = @complaints,
                            Medical_history = @medicalHistory,
                            Allergies = @allergies::jsonb,
                            Bad_habits = @badHabits::jsonb,
                            Blood_pressure_low = @bpLow,
                            Blood_pressure_high = @bpHigh,
                            Pulse = @pulse,
                            Saturation = @saturation,
                            Skin = @skin,
                            Mucosal = @mucosal,
                            Thermometry = @thermometry
                        WHERE Anamnesis_ID = @anamnesisId";

                    using (var cmd = new NpgsqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@wardId", selectedWardId);
                        cmd.Parameters.AddWithValue("@admittingDoctor", selectedAdmittingDoctorId);
                        cmd.Parameters.AddWithValue("@attendingDoctor", selectedAttendingDoctorId);
                        cmd.Parameters.AddWithValue("@date", dtpDateOfArrive.Value.Date);
                        cmd.Parameters.AddWithValue("@dateOfDischarge", 
                            dtpDateOfDischarge.Checked ? (object)dtpDateOfDischarge.Value.Date : DBNull.Value);
                        cmd.Parameters.AddWithValue("@complaints", txtComplaints.Text);
                        cmd.Parameters.AddWithValue("@medicalHistory", txtMedicalHistory.Text);
                        cmd.Parameters.AddWithValue("@allergies", allergiesJson);
                        cmd.Parameters.AddWithValue("@badHabits", badHabitsJson);
                        cmd.Parameters.AddWithValue("@bpLow", Convert.ToInt32(txtBloodPressureLow.Text));
                        cmd.Parameters.AddWithValue("@bpHigh", Convert.ToInt32(txtBloodPressureHigh.Text));
                        cmd.Parameters.AddWithValue("@pulse", Convert.ToInt32(txtPulse.Text));
                        cmd.Parameters.AddWithValue("@saturation", Convert.ToInt32(txtSaturation.Text));
                        cmd.Parameters.AddWithValue("@skin", txtSkin.Text);
                        cmd.Parameters.AddWithValue("@mucosal", txtMucosal.Text);
                        cmd.Parameters.AddWithValue("@thermometry", Convert.ToDecimal(txtThermometry.Text));
                        cmd.Parameters.AddWithValue("@anamnesisId", currentAnamnesisId);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Анамнез обновлён");
                ClearFields();
                LoadAnamnesis();
                currentAnamnesisId = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка обновления: " + ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (currentAnamnesisId == 0)
            {
                MessageBox.Show("Выберите запись для удаления");
                return;
            }

            if (MessageBox.Show("Удалить запись анамнеза?", "Подтверждение", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    using (var conn = dbHelper.GetConnection())
                    {
                        conn.Open();
                        string query = "DELETE FROM Anamnesis WHERE Anamnesis_ID = @id";
                        using (var cmd = new NpgsqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@id", currentAnamnesisId);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Анамнез удалён");
                    ClearFields();
                    LoadAnamnesis();
                    currentAnamnesisId = 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка удаления: " + ex.Message);
                }
            }
        }

        private void ClearFields()
        {
            dtpDateOfArrive.Value = DateTime.Now;
            dtpDateOfDischarge.Checked = false;
            txtComplaints.Text = "";
            txtMedicalHistory.Text = "";
            txtBloodPressureLow.Text = "";
            txtBloodPressureHigh.Text = "";
            txtPulse.Text = "";
            txtSaturation.Text = "";
            txtSkin.Text = "";
            txtMucosal.Text = "";
            txtThermometry.Text = "";

            for (int i = 0; i < clbAllergies.Items.Count; i++)
                clbAllergies.SetItemChecked(i, false);
            for (int i = 0; i < clbBadHabits.Items.Count; i++)
                clbBadHabits.SetItemChecked(i, false);
            
            txtOtherAllergy.Text = "";
            txtOtherAllergy.Enabled = false;
            txtOtherBadHabit.Text = "";
            txtOtherBadHabit.Enabled = false;

            selectedWardId = 0;
            selectedAdmittingDoctorId = 0;
            selectedAttendingDoctorId = 0;

            lblSelectedWard.Text = "Не выбрано";
            lblSelectedAdmittingDoctor.Text = "Не выбрано";
            lblSelectedAttendingDoctor.Text = "Не выбрано";

            currentAnamnesisId = 0;
        }
    }
}