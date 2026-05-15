namespace HospitalApp.Forms;

partial class EmployeeForm
{
    private System.ComponentModel.IContainer components = null;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
            components.Dispose();
        base.Dispose(disposing);
    }

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblSurname = new System.Windows.Forms.Label();
        txtSurname = new System.Windows.Forms.TextBox();
        lblName = new System.Windows.Forms.Label();
        txtName = new System.Windows.Forms.TextBox();
        lblPatronymic = new System.Windows.Forms.Label();
        txtPatronymic = new System.Windows.Forms.TextBox();
        lblGender = new System.Windows.Forms.Label();
        rbMale = new System.Windows.Forms.RadioButton();
        rbFemale = new System.Windows.Forms.RadioButton();
        lblBirthDate = new System.Windows.Forms.Label();
        dtpBirthDate = new System.Windows.Forms.DateTimePicker();
        lblPhone = new System.Windows.Forms.Label();
        txtPhone = new System.Windows.Forms.TextBox();
        lblPassport = new System.Windows.Forms.Label();
        txtPassport = new System.Windows.Forms.TextBox();
        lblDepartment = new System.Windows.Forms.Label();
        cmbDepartment = new System.Windows.Forms.ComboBox();
        lblPosition = new System.Windows.Forms.Label();
        rbDoctor = new System.Windows.Forms.RadioButton();
        rbNurse = new System.Windows.Forms.RadioButton();
        rbSanitar = new System.Windows.Forms.RadioButton();
        pnlDoctor = new System.Windows.Forms.GroupBox();
        lblSpecialization = new System.Windows.Forms.Label();
        txtSpecialization = new System.Windows.Forms.TextBox();
        lblCertificate = new System.Windows.Forms.Label();
        txtCertificate = new System.Windows.Forms.TextBox();
        lblAcademicDegree = new System.Windows.Forms.Label();
        txtAcademicDegree = new System.Windows.Forms.TextBox();
        lblQualification = new System.Windows.Forms.Label();
        cmbQualification = new System.Windows.Forms.ComboBox();
        lblRank = new System.Windows.Forms.Label();
        txtRank = new System.Windows.Forms.TextBox();
        pnlNurse = new System.Windows.Forms.GroupBox();
        lblNurseCertificate = new System.Windows.Forms.Label();
        txtNurseCertificate = new System.Windows.Forms.TextBox();
        lblNurseQualification = new System.Windows.Forms.Label();
        cmbNurseQualification = new System.Windows.Forms.ComboBox();
        lblNurseRank = new System.Windows.Forms.Label();
        txtNurseRank = new System.Windows.Forms.TextBox();
        pnlSanitar = new System.Windows.Forms.GroupBox();
        chkAdmission = new System.Windows.Forms.CheckBox();
        lblSearch = new System.Windows.Forms.Label();
        txtSearchSurname = new System.Windows.Forms.TextBox();
        txtSearchPassport = new System.Windows.Forms.TextBox();
        btnSearch = new System.Windows.Forms.Button();
        btnAdd = new System.Windows.Forms.Button();
        btnUpdate = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        dgvEmployees = new System.Windows.Forms.DataGridView();
        panelGender = new System.Windows.Forms.Panel();
        pnlDoctor.SuspendLayout();
        pnlNurse.SuspendLayout();
        pnlSanitar.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvEmployees).BeginInit();
        panelGender.SuspendLayout();
        SuspendLayout();
        // 
        // lblSurname
        // 
        lblSurname.Location = new System.Drawing.Point(12, 39);
        lblSurname.Name = "lblSurname";
        lblSurname.Size = new System.Drawing.Size(100, 27);
        lblSurname.TabIndex = 33;
        lblSurname.Text = "Фамилия:";
        // 
        // txtSurname
        // 
        txtSurname.Location = new System.Drawing.Point(150, 39);
        txtSurname.Name = "txtSurname";
        txtSurname.Size = new System.Drawing.Size(200, 27);
        txtSurname.TabIndex = 32;
        // 
        // lblName
        // 
        lblName.Location = new System.Drawing.Point(12, 74);
        lblName.Name = "lblName";
        lblName.Size = new System.Drawing.Size(100, 27);
        lblName.TabIndex = 31;
        lblName.Text = "Имя:";
        // 
        // txtName
        // 
        txtName.Location = new System.Drawing.Point(150, 74);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(200, 27);
        txtName.TabIndex = 30;
        // 
        // lblPatronymic
        // 
        lblPatronymic.Location = new System.Drawing.Point(12, 109);
        lblPatronymic.Name = "lblPatronymic";
        lblPatronymic.Size = new System.Drawing.Size(100, 27);
        lblPatronymic.TabIndex = 29;
        lblPatronymic.Text = "Отчество:";
        // 
        // txtPatronymic
        // 
        txtPatronymic.Location = new System.Drawing.Point(150, 109);
        txtPatronymic.Name = "txtPatronymic";
        txtPatronymic.Size = new System.Drawing.Size(200, 27);
        txtPatronymic.TabIndex = 28;
        // 
        // lblGender
        // 
        lblGender.Location = new System.Drawing.Point(12, 144);
        lblGender.Name = "lblGender";
        lblGender.Size = new System.Drawing.Size(100, 27);
        lblGender.TabIndex = 27;
        lblGender.Text = "Пол:";
        // 
        // rbMale
        // 
        rbMale.Checked = true;
        rbMale.Location = new System.Drawing.Point(10, 5);
        rbMale.Name = "rbMale";
        rbMale.Size = new System.Drawing.Size(104, 27);
        rbMale.TabIndex = 26;
        rbMale.TabStop = true;
        rbMale.Text = "Мужской";
        // 
        // rbFemale
        // 
        rbFemale.Location = new System.Drawing.Point(120, 5);
        rbFemale.Name = "rbFemale";
        rbFemale.Size = new System.Drawing.Size(117, 27);
        rbFemale.TabIndex = 25;
        rbFemale.Text = "Женский";
        // 
        // lblBirthDate
        // 
        lblBirthDate.Location = new System.Drawing.Point(12, 179);
        lblBirthDate.Name = "lblBirthDate";
        lblBirthDate.Size = new System.Drawing.Size(120, 27);
        lblBirthDate.TabIndex = 24;
        lblBirthDate.Text = "Дата рождения:";
        // 
        // dtpBirthDate
        // 
        dtpBirthDate.Location = new System.Drawing.Point(150, 179);
        dtpBirthDate.Name = "dtpBirthDate";
        dtpBirthDate.Size = new System.Drawing.Size(200, 27);
        dtpBirthDate.TabIndex = 23;
        // 
        // lblPhone
        // 
        lblPhone.Location = new System.Drawing.Point(12, 214);
        lblPhone.Name = "lblPhone";
        lblPhone.Size = new System.Drawing.Size(100, 27);
        lblPhone.TabIndex = 22;
        lblPhone.Text = "Телефон:";
        // 
        // txtPhone
        // 
        txtPhone.Location = new System.Drawing.Point(150, 214);
        txtPhone.Name = "txtPhone";
        txtPhone.Size = new System.Drawing.Size(200, 27);
        txtPhone.TabIndex = 21;
        // 
        // lblPassport
        // 
        lblPassport.Location = new System.Drawing.Point(12, 249);
        lblPassport.Name = "lblPassport";
        lblPassport.Size = new System.Drawing.Size(100, 27);
        lblPassport.TabIndex = 20;
        lblPassport.Text = "Паспорт:";
        // 
        // txtPassport
        // 
        txtPassport.Location = new System.Drawing.Point(150, 249);
        txtPassport.Name = "txtPassport";
        txtPassport.PlaceholderText = "XXXX XXXXXX";
        txtPassport.Size = new System.Drawing.Size(200, 27);
        txtPassport.TabIndex = 19;
        // 
        // lblDepartment
        // 
        lblDepartment.Location = new System.Drawing.Point(12, 284);
        lblDepartment.Name = "lblDepartment";
        lblDepartment.Size = new System.Drawing.Size(100, 27);
        lblDepartment.TabIndex = 18;
        lblDepartment.Text = "Отделение:";
        // 
        // cmbDepartment
        // 
        cmbDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbDepartment.Location = new System.Drawing.Point(150, 284);
        cmbDepartment.Name = "cmbDepartment";
        cmbDepartment.Size = new System.Drawing.Size(250, 28);
        cmbDepartment.TabIndex = 17;
        // 
        // lblPosition
        // 
        lblPosition.Location = new System.Drawing.Point(12, 319);
        lblPosition.Name = "lblPosition";
        lblPosition.Size = new System.Drawing.Size(100, 27);
        lblPosition.TabIndex = 16;
        lblPosition.Text = "Должность:";
        // 
        // rbDoctor
        // 
        rbDoctor.Location = new System.Drawing.Point(150, 319);
        rbDoctor.Name = "rbDoctor";
        rbDoctor.Size = new System.Drawing.Size(80, 27);
        rbDoctor.TabIndex = 15;
        rbDoctor.Text = "Доктор";
        rbDoctor.CheckedChanged += rbPosition_CheckedChanged;
        // 
        // rbNurse
        // 
        rbNurse.Location = new System.Drawing.Point(240, 319);
        rbNurse.Name = "rbNurse";
        rbNurse.Size = new System.Drawing.Size(110, 27);
        rbNurse.TabIndex = 14;
        rbNurse.Text = "Медсестра";
        rbNurse.CheckedChanged += rbPosition_CheckedChanged;
        // 
        // rbSanitar
        // 
        rbSanitar.Location = new System.Drawing.Point(350, 319);
        rbSanitar.Name = "rbSanitar";
        rbSanitar.Size = new System.Drawing.Size(88, 27);
        rbSanitar.TabIndex = 13;
        rbSanitar.Text = "Санитар";
        rbSanitar.CheckedChanged += rbPosition_CheckedChanged;
        // 
        // pnlDoctor
        // 
        pnlDoctor.Controls.Add(lblSpecialization);
        pnlDoctor.Controls.Add(txtSpecialization);
        pnlDoctor.Controls.Add(lblCertificate);
        pnlDoctor.Controls.Add(txtCertificate);
        pnlDoctor.Controls.Add(lblAcademicDegree);
        pnlDoctor.Controls.Add(txtAcademicDegree);
        pnlDoctor.Controls.Add(lblQualification);
        pnlDoctor.Controls.Add(cmbQualification);
        pnlDoctor.Controls.Add(lblRank);
        pnlDoctor.Controls.Add(txtRank);
        pnlDoctor.Location = new System.Drawing.Point(12, 354);
        pnlDoctor.Name = "pnlDoctor";
        pnlDoctor.Size = new System.Drawing.Size(500, 180);
        pnlDoctor.TabIndex = 12;
        pnlDoctor.TabStop = false;
        pnlDoctor.Text = "Данные доктора";
        // 
        // lblSpecialization
        // 
        lblSpecialization.Location = new System.Drawing.Point(10, 25);
        lblSpecialization.Name = "lblSpecialization";
        lblSpecialization.Size = new System.Drawing.Size(120, 27);
        lblSpecialization.TabIndex = 0;
        lblSpecialization.Text = "Специализация:";
        // 
        // txtSpecialization
        // 
        txtSpecialization.Location = new System.Drawing.Point(140, 25);
        txtSpecialization.Name = "txtSpecialization";
        txtSpecialization.Size = new System.Drawing.Size(340, 27);
        txtSpecialization.TabIndex = 1;
        // 
        // lblCertificate
        // 
        lblCertificate.Location = new System.Drawing.Point(10, 60);
        lblCertificate.Name = "lblCertificate";
        lblCertificate.Size = new System.Drawing.Size(162, 27);
        lblCertificate.TabIndex = 2;
        lblCertificate.Text = "Номер сертификата:";
        // 
        // txtCertificate
        // 
        txtCertificate.Location = new System.Drawing.Point(170, 60);
        txtCertificate.Name = "txtCertificate";
        txtCertificate.PlaceholderText = "XXXXXX XXXXXXX";
        txtCertificate.Size = new System.Drawing.Size(310, 27);
        txtCertificate.TabIndex = 3;
        // 
        // lblAcademicDegree
        // 
        lblAcademicDegree.Location = new System.Drawing.Point(10, 95);
        lblAcademicDegree.Name = "lblAcademicDegree";
        lblAcademicDegree.Size = new System.Drawing.Size(130, 27);
        lblAcademicDegree.TabIndex = 4;
        lblAcademicDegree.Text = "Учёная степень:";
        // 
        // txtAcademicDegree
        // 
        txtAcademicDegree.Location = new System.Drawing.Point(140, 95);
        txtAcademicDegree.Name = "txtAcademicDegree";
        txtAcademicDegree.Size = new System.Drawing.Size(340, 27);
        txtAcademicDegree.TabIndex = 5;
        // 
        // lblQualification
        // 
        lblQualification.Location = new System.Drawing.Point(10, 130);
        lblQualification.Name = "lblQualification";
        lblQualification.Size = new System.Drawing.Size(120, 27);
        lblQualification.TabIndex = 6;
        lblQualification.Text = "Квалификация:";
        // 
        // cmbQualification
        // 
        cmbQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbQualification.Items.AddRange(new object[] { "1 (первая)", "2 (вторая)", "3 (высшая)" });
        cmbQualification.Location = new System.Drawing.Point(140, 130);
        cmbQualification.Name = "cmbQualification";
        cmbQualification.Size = new System.Drawing.Size(150, 28);
        cmbQualification.TabIndex = 7;
        // 
        // lblRank
        // 
        lblRank.Location = new System.Drawing.Point(310, 130);
        lblRank.Name = "lblRank";
        lblRank.Size = new System.Drawing.Size(93, 27);
        lblRank.TabIndex = 8;
        lblRank.Text = "Должность:";
        // 
        // txtRank
        // 
        txtRank.Location = new System.Drawing.Point(400, 130);
        txtRank.Name = "txtRank";
        txtRank.Size = new System.Drawing.Size(80, 27);
        txtRank.TabIndex = 9;
        // 
        // pnlNurse
        // 
        pnlNurse.Controls.Add(lblNurseCertificate);
        pnlNurse.Controls.Add(txtNurseCertificate);
        pnlNurse.Controls.Add(lblNurseQualification);
        pnlNurse.Controls.Add(cmbNurseQualification);
        pnlNurse.Controls.Add(lblNurseRank);
        pnlNurse.Controls.Add(txtNurseRank);
        pnlNurse.Location = new System.Drawing.Point(12, 349);
        pnlNurse.Name = "pnlNurse";
        pnlNurse.Size = new System.Drawing.Size(500, 130);
        pnlNurse.TabIndex = 11;
        pnlNurse.TabStop = false;
        pnlNurse.Text = "Данные медсестры";
        pnlNurse.Visible = false;
        // 
        // lblNurseCertificate
        // 
        lblNurseCertificate.Location = new System.Drawing.Point(10, 25);
        lblNurseCertificate.Name = "lblNurseCertificate";
        lblNurseCertificate.Size = new System.Drawing.Size(164, 27);
        lblNurseCertificate.TabIndex = 0;
        lblNurseCertificate.Text = "Номер сертификата:";
        // 
        // txtNurseCertificate
        // 
        txtNurseCertificate.Location = new System.Drawing.Point(170, 25);
        txtNurseCertificate.Name = "txtNurseCertificate";
        txtNurseCertificate.PlaceholderText = "XXXXXX XXXXXXX";
        txtNurseCertificate.Size = new System.Drawing.Size(310, 27);
        txtNurseCertificate.TabIndex = 1;
        // 
        // lblNurseQualification
        // 
        lblNurseQualification.Location = new System.Drawing.Point(10, 65);
        lblNurseQualification.Name = "lblNurseQualification";
        lblNurseQualification.Size = new System.Drawing.Size(120, 27);
        lblNurseQualification.TabIndex = 2;
        lblNurseQualification.Text = "Квалификация:";
        // 
        // cmbNurseQualification
        // 
        cmbNurseQualification.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        cmbNurseQualification.Items.AddRange(new object[] { "1 (первая)", "2 (вторая)", "3 (высшая)" });
        cmbNurseQualification.Location = new System.Drawing.Point(140, 65);
        cmbNurseQualification.Name = "cmbNurseQualification";
        cmbNurseQualification.Size = new System.Drawing.Size(150, 28);
        cmbNurseQualification.TabIndex = 3;
        // 
        // lblNurseRank
        // 
        lblNurseRank.Location = new System.Drawing.Point(310, 65);
        lblNurseRank.Name = "lblNurseRank";
        lblNurseRank.Size = new System.Drawing.Size(93, 27);
        lblNurseRank.TabIndex = 4;
        lblNurseRank.Text = "Должность:";
        // 
        // txtNurseRank
        // 
        txtNurseRank.Location = new System.Drawing.Point(400, 65);
        txtNurseRank.Name = "txtNurseRank";
        txtNurseRank.Size = new System.Drawing.Size(80, 27);
        txtNurseRank.TabIndex = 5;
        // 
        // pnlSanitar
        // 
        pnlSanitar.Controls.Add(chkAdmission);
        pnlSanitar.Location = new System.Drawing.Point(12, 349);
        pnlSanitar.Name = "pnlSanitar";
        pnlSanitar.Size = new System.Drawing.Size(500, 80);
        pnlSanitar.TabIndex = 10;
        pnlSanitar.TabStop = false;
        pnlSanitar.Text = "Данные санитара";
        pnlSanitar.Visible = false;
        // 
        // chkAdmission
        // 
        chkAdmission.Location = new System.Drawing.Point(140, 30);
        chkAdmission.Name = "chkAdmission";
        chkAdmission.Size = new System.Drawing.Size(308, 27);
        chkAdmission.TabIndex = 0;
        chkAdmission.Text = "Допущен к медицинской деятельности\r\n";
        // 
        // lblSearch
        // 
        lblSearch.Location = new System.Drawing.Point(12, 9);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new System.Drawing.Size(60, 27);
        lblSearch.TabIndex = 9;
        lblSearch.Text = "Поиск:";
        // 
        // txtSearchSurname
        // 
        txtSearchSurname.Location = new System.Drawing.Point(80, 9);
        txtSearchSurname.Name = "txtSearchSurname";
        txtSearchSurname.PlaceholderText = "Фамилия";
        txtSearchSurname.Size = new System.Drawing.Size(150, 27);
        txtSearchSurname.TabIndex = 8;
        // 
        // txtSearchPassport
        // 
        txtSearchPassport.Location = new System.Drawing.Point(240, 9);
        txtSearchPassport.Name = "txtSearchPassport";
        txtSearchPassport.PlaceholderText = "Паспорт";
        txtSearchPassport.Size = new System.Drawing.Size(150, 27);
        txtSearchPassport.TabIndex = 7;
        // 
        // btnSearch
        // 
        btnSearch.Location = new System.Drawing.Point(400, 9);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(80, 27);
        btnSearch.TabIndex = 6;
        btnSearch.Text = "Найти";
        btnSearch.Click += btnSearch_Click;
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(12, 541);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(100, 35);
        btnAdd.TabIndex = 4;
        btnAdd.Text = "Добавить";
        btnAdd.Click += btnAdd_Click;
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(120, 541);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(100, 35);
        btnUpdate.TabIndex = 3;
        btnUpdate.Text = "Обновить";
        btnUpdate.Click += btnUpdate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new System.Drawing.Point(230, 541);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(100, 35);
        btnDelete.TabIndex = 2;
        btnDelete.Text = "Удалить";
        btnDelete.Click += btnDelete_Click;
        // 
        // dgvEmployees
        // 
        dgvEmployees.ColumnHeadersHeight = 29;
        dgvEmployees.Location = new System.Drawing.Point(12, 582);
        dgvEmployees.Name = "dgvEmployees";
        dgvEmployees.RowHeadersWidth = 51;
        dgvEmployees.Size = new System.Drawing.Size(800, 250);
        dgvEmployees.TabIndex = 0;
        dgvEmployees.CellClick += dgvEmployees_CellClick;
        // 
        // panelGender
        // 
        panelGender.Controls.Add(rbMale);
        panelGender.Controls.Add(rbFemale);
        panelGender.Location = new System.Drawing.Point(140, 140);
        panelGender.Name = "panelGender";
        panelGender.Size = new System.Drawing.Size(400, 31);
        panelGender.TabIndex = 0;
        // 
        // EmployeeForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1920, 1055);
        Controls.Add(panelGender);
        Controls.Add(dgvEmployees);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(btnSearch);
        Controls.Add(txtSearchPassport);
        Controls.Add(txtSearchSurname);
        Controls.Add(lblSearch);
        Controls.Add(pnlDoctor);
        Controls.Add(pnlNurse);
        Controls.Add(pnlSanitar);
        Controls.Add(rbSanitar);
        Controls.Add(rbNurse);
        Controls.Add(rbDoctor);
        Controls.Add(lblPosition);
        Controls.Add(cmbDepartment);
        Controls.Add(lblDepartment);
        Controls.Add(txtPassport);
        Controls.Add(lblPassport);
        Controls.Add(txtPhone);
        Controls.Add(lblPhone);
        Controls.Add(dtpBirthDate);
        Controls.Add(lblBirthDate);
        Controls.Add(lblGender);
        Controls.Add(txtPatronymic);
        Controls.Add(lblPatronymic);
        Controls.Add(txtName);
        Controls.Add(lblName);
        Controls.Add(txtSurname);
        Controls.Add(lblSurname);
        Text = "Сотрудники";
        pnlDoctor.ResumeLayout(false);
        pnlDoctor.PerformLayout();
        pnlNurse.ResumeLayout(false);
        pnlNurse.PerformLayout();
        pnlSanitar.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvEmployees).EndInit();
        panelGender.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Panel panelGender;

    // Объявления полей
    private Label lblSurname, lblName, lblPatronymic, lblGender, lblBirthDate, lblPhone, lblPassport, lblDepartment, lblPosition;
    private TextBox txtSurname, txtName, txtPatronymic, txtPhone, txtPassport;
    private RadioButton rbMale, rbFemale;
    private DateTimePicker dtpBirthDate;
    private ComboBox cmbDepartment;
    private RadioButton rbDoctor, rbNurse, rbSanitar;

    private GroupBox pnlDoctor, pnlNurse, pnlSanitar;
    private Label lblSpecialization, lblCertificate, lblAcademicDegree, lblQualification, lblRank;
    private TextBox txtSpecialization, txtCertificate, txtAcademicDegree, txtRank;
    private ComboBox cmbQualification;
    private Label lblNurseCertificate, lblNurseQualification, lblNurseRank;
    private TextBox txtNurseCertificate, txtNurseRank;
    private ComboBox cmbNurseQualification;
    private System.Windows.Forms.CheckBox chkAdmission;

    private Label lblSearch;
    private TextBox txtSearchSurname, txtSearchPassport;
    private Button btnSearch;

    private Button btnAdd, btnUpdate, btnDelete;

    private DataGridView dgvEmployees;
}