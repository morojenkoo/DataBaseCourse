using System.ComponentModel;

namespace HospitalApp.Forms;

partial class PatientForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        lblPatientSurname = new System.Windows.Forms.Label();
        lblPatientName = new System.Windows.Forms.Label();
        lblPatientPatronymic = new System.Windows.Forms.Label();
        lblPatientGender = new System.Windows.Forms.Label();
        lblPatientDateOfBirth = new System.Windows.Forms.Label();
        lblPolys = new System.Windows.Forms.Label();
        lblSNYLS = new System.Windows.Forms.Label();
        lblPatientPassportNumber = new System.Windows.Forms.Label();
        txtSurname = new System.Windows.Forms.TextBox();
        txtName = new System.Windows.Forms.TextBox();
        txtPatronymic = new System.Windows.Forms.TextBox();
        txtPassport = new System.Windows.Forms.TextBox();
        txtPolysNumber = new System.Windows.Forms.TextBox();
        txtSnils = new System.Windows.Forms.TextBox();
        btnAdd = new System.Windows.Forms.Button();
        btnUpdate = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        btnAnamnesis = new System.Windows.Forms.Button();
        btnPatientSearch = new System.Windows.Forms.Button();
        txtSearchPassport = new System.Windows.Forms.TextBox();
        lblSearchPassport = new System.Windows.Forms.Label();
        label1 = new System.Windows.Forms.Label();
        txtSearchSurname = new System.Windows.Forms.TextBox();
        cmbGender = new System.Windows.Forms.ComboBox();
        dgvPatients = new System.Windows.Forms.DataGridView();
        dtpBirthDate = new System.Windows.Forms.DateTimePicker();
        ((System.ComponentModel.ISupportInitialize)dgvPatients).BeginInit();
        SuspendLayout();
        // 
        // lblPatientSurname
        // 
        lblPatientSurname.Location = new System.Drawing.Point(8, 495);
        lblPatientSurname.Name = "lblPatientSurname";
        lblPatientSurname.Size = new System.Drawing.Size(100, 23);
        lblPatientSurname.TabIndex = 0;
        lblPatientSurname.Text = "Фамилия";
        // 
        // lblPatientName
        // 
        lblPatientName.Location = new System.Drawing.Point(8, 528);
        lblPatientName.Name = "lblPatientName";
        lblPatientName.Size = new System.Drawing.Size(100, 23);
        lblPatientName.TabIndex = 1;
        lblPatientName.Text = "Имя";
        // 
        // lblPatientPatronymic
        // 
        lblPatientPatronymic.Location = new System.Drawing.Point(8, 561);
        lblPatientPatronymic.Name = "lblPatientPatronymic";
        lblPatientPatronymic.Size = new System.Drawing.Size(100, 23);
        lblPatientPatronymic.TabIndex = 2;
        lblPatientPatronymic.Text = "Отчество ";
        // 
        // lblPatientGender
        // 
        lblPatientGender.Location = new System.Drawing.Point(8, 594);
        lblPatientGender.Name = "lblPatientGender";
        lblPatientGender.Size = new System.Drawing.Size(100, 23);
        lblPatientGender.TabIndex = 3;
        lblPatientGender.Text = "Пол";
        // 
        // lblPatientDateOfBirth
        // 
        lblPatientDateOfBirth.Location = new System.Drawing.Point(8, 624);
        lblPatientDateOfBirth.Name = "lblPatientDateOfBirth";
        lblPatientDateOfBirth.Size = new System.Drawing.Size(121, 23);
        lblPatientDateOfBirth.TabIndex = 4;
        lblPatientDateOfBirth.Text = "Дата рождения";
        // 
        // lblPolys
        // 
        lblPolys.Location = new System.Drawing.Point(8, 690);
        lblPolys.Name = "lblPolys";
        lblPolys.Size = new System.Drawing.Size(114, 27);
        lblPolys.TabIndex = 5;
        lblPolys.Text = "Полис ОМС";
        // 
        // lblSNYLS
        // 
        lblSNYLS.Location = new System.Drawing.Point(8, 723);
        lblSNYLS.Name = "lblSNYLS";
        lblSNYLS.Size = new System.Drawing.Size(100, 27);
        lblSNYLS.TabIndex = 6;
        lblSNYLS.Text = "СНИЛС";
        // 
        // lblPatientPassportNumber
        // 
        lblPatientPassportNumber.Location = new System.Drawing.Point(8, 657);
        lblPatientPassportNumber.Name = "lblPatientPassportNumber";
        lblPatientPassportNumber.Size = new System.Drawing.Size(107, 27);
        lblPatientPassportNumber.TabIndex = 7;
        lblPatientPassportNumber.Text = "Паспорт";
        // 
        // txtSurname
        // 
        txtSurname.Location = new System.Drawing.Point(128, 495);
        txtSurname.Name = "txtSurname";
        txtSurname.Size = new System.Drawing.Size(204, 27);
        txtSurname.TabIndex = 8;
        // 
        // txtName
        // 
        txtName.Location = new System.Drawing.Point(128, 528);
        txtName.Name = "txtName";
        txtName.Size = new System.Drawing.Size(204, 27);
        txtName.TabIndex = 9;
        // 
        // txtPatronymic
        // 
        txtPatronymic.Location = new System.Drawing.Point(128, 561);
        txtPatronymic.Name = "txtPatronymic";
        txtPatronymic.Size = new System.Drawing.Size(204, 27);
        txtPatronymic.TabIndex = 10;
        // 
        // txtPassport
        // 
        txtPassport.Location = new System.Drawing.Point(128, 657);
        txtPassport.Name = "txtPassport";
        txtPassport.Size = new System.Drawing.Size(204, 27);
        txtPassport.TabIndex = 13;
        // 
        // txtPolysNumber
        // 
        txtPolysNumber.Location = new System.Drawing.Point(128, 690);
        txtPolysNumber.Name = "txtPolysNumber";
        txtPolysNumber.Size = new System.Drawing.Size(204, 27);
        txtPolysNumber.TabIndex = 14;
        // 
        // txtSnils
        // 
        txtSnils.Location = new System.Drawing.Point(128, 723);
        txtSnils.Name = "txtSnils";
        txtSnils.Size = new System.Drawing.Size(204, 27);
        txtSnils.TabIndex = 15;
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(8, 784);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(84, 25);
        btnAdd.TabIndex = 16;
        btnAdd.Text = "Добавить";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(98, 784);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(87, 25);
        btnUpdate.TabIndex = 17;
        btnUpdate.Text = "Обновить";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new System.Drawing.Point(191, 784);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(75, 25);
        btnDelete.TabIndex = 18;
        btnDelete.Text = "Удалить";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnAnamnesis
        // 
        btnAnamnesis.Location = new System.Drawing.Point(7, 815);
        btnAnamnesis.Name = "btnAnamnesis";
        btnAnamnesis.Size = new System.Drawing.Size(100, 25);
        btnAnamnesis.TabIndex = 19;
        btnAnamnesis.Text = "Анамнезы";
        btnAnamnesis.UseVisualStyleBackColor = true;
        btnAnamnesis.Click += btnAnamnesis_Click;
        // 
        // btnPatientSearch
        // 
        btnPatientSearch.Location = new System.Drawing.Point(328, 35);
        btnPatientSearch.Name = "btnPatientSearch";
        btnPatientSearch.Size = new System.Drawing.Size(75, 25);
        btnPatientSearch.TabIndex = 20;
        btnPatientSearch.Text = "Найти";
        btnPatientSearch.UseVisualStyleBackColor = true;
        btnPatientSearch.Click += btnPatientSearch_Click;
        // 
        // txtSearchPassport
        // 
        txtSearchPassport.Location = new System.Drawing.Point(113, 5);
        txtSearchPassport.Name = "txtSearchPassport";
        txtSearchPassport.Size = new System.Drawing.Size(208, 27);
        txtSearchPassport.TabIndex = 21;
        // 
        // lblSearchPassport
        // 
        lblSearchPassport.Location = new System.Drawing.Point(7, 5);
        lblSearchPassport.Name = "lblSearchPassport";
        lblSearchPassport.Size = new System.Drawing.Size(100, 44);
        lblSearchPassport.TabIndex = 22;
        lblSearchPassport.Text = "Поиск по паспорту";
        // 
        // label1
        // 
        label1.Location = new System.Drawing.Point(7, 49);
        label1.Name = "label1";
        label1.Size = new System.Drawing.Size(100, 44);
        label1.TabIndex = 23;
        label1.Text = "Поиск по ФИО";
        // 
        // txtSearchSurname
        // 
        txtSearchSurname.Location = new System.Drawing.Point(113, 49);
        txtSearchSurname.Name = "txtSearchSurname";
        txtSearchSurname.Size = new System.Drawing.Size(208, 27);
        txtSearchSurname.TabIndex = 24;
        // 
        // cmbGender
        // 
        cmbGender.FormattingEnabled = true;
        cmbGender.Location = new System.Drawing.Point(128, 594);
        cmbGender.Name = "cmbGender";
        cmbGender.Size = new System.Drawing.Size(204, 28);
        cmbGender.TabIndex = 26;
        // 
        // dgvPatients
        // 
        dgvPatients.ColumnHeadersHeight = 29;
        dgvPatients.Location = new System.Drawing.Point(7, 96);
        dgvPatients.Name = "dgvPatients";
        dgvPatients.RowHeadersWidth = 51;
        dgvPatients.Size = new System.Drawing.Size(1035, 377);
        dgvPatients.TabIndex = 27;
        dgvPatients.CellClick += dgvPatients_CellClick;
        // 
        // dtpBirthDate
        // 
        dtpBirthDate.Location = new System.Drawing.Point(128, 624);
        dtpBirthDate.Name = "dtpBirthDate";
        dtpBirthDate.Size = new System.Drawing.Size(204, 27);
        dtpBirthDate.TabIndex = 28;
        // 
        // PatientForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1920, 1055);
        Controls.Add(dtpBirthDate);
        Controls.Add(dgvPatients);
        Controls.Add(cmbGender);
        Controls.Add(txtSearchSurname);
        Controls.Add(label1);
        Controls.Add(lblSearchPassport);
        Controls.Add(txtSearchPassport);
        Controls.Add(btnPatientSearch);
        Controls.Add(btnAnamnesis);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtSnils);
        Controls.Add(txtPolysNumber);
        Controls.Add(txtPassport);
        Controls.Add(txtPatronymic);
        Controls.Add(txtName);
        Controls.Add(txtSurname);
        Controls.Add(lblPatientPassportNumber);
        Controls.Add(lblSNYLS);
        Controls.Add(lblPolys);
        Controls.Add(lblPatientDateOfBirth);
        Controls.Add(lblPatientGender);
        Controls.Add(lblPatientPatronymic);
        Controls.Add(lblPatientName);
        Controls.Add(lblPatientSurname);
        Text = "PatientForm";
        ((System.ComponentModel.ISupportInitialize)dgvPatients).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DateTimePicker dtpBirthDate;

    private System.Windows.Forms.Button btnPatientSearch;
    private System.Windows.Forms.TextBox txtSearchPassport;
    private System.Windows.Forms.Label lblSearchPassport;
    private System.Windows.Forms.DataGridView dgvPatients;

    private System.Windows.Forms.ComboBox cmbGender;

    private System.Windows.Forms.Label label1;

    private System.Windows.Forms.TextBox txtSearchSurname;

    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.Button btnAnamnesis;

    private System.Windows.Forms.TextBox txtPatronymic;
    private System.Windows.Forms.TextBox txtPassport;
    private System.Windows.Forms.TextBox txtPolysNumber;
    private System.Windows.Forms.TextBox txtSnils;

    private System.Windows.Forms.TextBox txtSurname;
    private System.Windows.Forms.TextBox txtName;

    private System.Windows.Forms.Label lblPolys;
    private System.Windows.Forms.Label lblSNYLS;
    private System.Windows.Forms.Label lblPatientPassportNumber;

    private System.Windows.Forms.Label lblPatientSurname;
    private System.Windows.Forms.Label lblPatientName;
    private System.Windows.Forms.Label lblPatientPatronymic;
    private System.Windows.Forms.Label lblPatientGender;
    private System.Windows.Forms.Label lblPatientDateOfBirth;

    #endregion
}