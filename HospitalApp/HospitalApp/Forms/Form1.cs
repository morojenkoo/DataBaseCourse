using HospitalApp.DataBase;

namespace HospitalApp.Forms
{
    public partial class Form1 : Form
    {
        private DataBaseHelper dbHelper;
        public Form1()
        {
            InitializeComponent();
            dbHelper = new DataBaseHelper();
        }
        private void btnDepartments_Click(object sender, EventArgs e)
        {
            DepartmentForm deptForm = new DepartmentForm();
            deptForm.ShowDialog();
        }

        private void btnPatients_Click(object sender, EventArgs e)
        {
            PatientForm deptForm = new PatientForm();
            deptForm.ShowDialog();
        }
        private void btnEmployees_Click(object sender, EventArgs e)
        {
            EmployeeForm empForm = new EmployeeForm();
            empForm.ShowDialog();
        }
    }
}