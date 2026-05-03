using System;
using System.Windows.Forms;
using HospitalApp.Database;

namespace HospitalApp
{
    public partial class Form1 : Form
    {
        private DataBaseHelper dbHelper;

        public Form1()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (dbHelper.TestConnection())
            {
                MessageBox.Show("Подключение к базе данных успешно!", "Успех", 
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не удалось подключиться к базе данных!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var conn = dbHelper.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT Department_ID, Department_name, Floor_number, Inner_phone FROM Department";
                    using (var cmd = new Npgsql.NpgsqlCommand(query, conn))
                    {
                        using (var reader = cmd.ExecuteReader())
                        {
                            // Создаём DataTable для загрузки данных
                            var dt = new System.Data.DataTable();
                            dt.Load(reader);
                    
                            // Привязываем данные к DataGridView
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка загрузки: " + ex.Message);
            }
        }
    }
}