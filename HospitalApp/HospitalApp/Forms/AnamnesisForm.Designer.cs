namespace HospitalApp.Forms;

partial class AnamnesisForm
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
        lblPatient = new System.Windows.Forms.Label();
        lblPatientName = new System.Windows.Forms.Label();
        lblDateOfDischarge = new System.Windows.Forms.Label();
        dtpDateOfDischarge = new System.Windows.Forms.DateTimePicker();
        lblDateOfArrive = new System.Windows.Forms.Label();
        dtpDateOfArrive = new System.Windows.Forms.DateTimePicker();
        lblWard = new System.Windows.Forms.Label();
        txtWardSearch = new System.Windows.Forms.TextBox();
        btnWardSearch = new System.Windows.Forms.Button();
        lstWardResults = new System.Windows.Forms.ListBox();
        lblSelectedWard = new System.Windows.Forms.Label();
        lblAdmittingDoctor = new System.Windows.Forms.Label();
        txtAdmittingDoctorSearch = new System.Windows.Forms.TextBox();
        btnAdmittingDoctorSearch = new System.Windows.Forms.Button();
        lstAdmittingDoctorResults = new System.Windows.Forms.ListBox();
        lblSelectedAdmittingDoctor = new System.Windows.Forms.Label();
        lblAttendingDoctor = new System.Windows.Forms.Label();
        txtAttendingDoctorSearch = new System.Windows.Forms.TextBox();
        btnAttendingDoctorSearch = new System.Windows.Forms.Button();
        lstAttendingDoctorResults = new System.Windows.Forms.ListBox();
        lblSelectedAttendingDoctor = new System.Windows.Forms.Label();
        lblComplaints = new System.Windows.Forms.Label();
        txtComplaints = new System.Windows.Forms.TextBox();
        lblMedicalHistory = new System.Windows.Forms.Label();
        txtMedicalHistory = new System.Windows.Forms.TextBox();
        lblAllergies = new System.Windows.Forms.Label();
        clbAllergies = new System.Windows.Forms.CheckedListBox();
        txtOtherAllergy = new System.Windows.Forms.TextBox();
        lblBadHabits = new System.Windows.Forms.Label();
        clbBadHabits = new System.Windows.Forms.CheckedListBox();
        txtOtherBadHabit = new System.Windows.Forms.TextBox();
        lblBloodPressureLow = new System.Windows.Forms.Label();
        txtBloodPressureLow = new System.Windows.Forms.TextBox();
        lblBloodPressureHigh = new System.Windows.Forms.Label();
        txtBloodPressureHigh = new System.Windows.Forms.TextBox();
        lblPulse = new System.Windows.Forms.Label();
        txtPulse = new System.Windows.Forms.TextBox();
        lblSaturation = new System.Windows.Forms.Label();
        txtSaturation = new System.Windows.Forms.TextBox();
        lblThermometry = new System.Windows.Forms.Label();
        txtThermometry = new System.Windows.Forms.TextBox();
        lblSkin = new System.Windows.Forms.Label();
        txtSkin = new System.Windows.Forms.TextBox();
        lblMucosal = new System.Windows.Forms.Label();
        txtMucosal = new System.Windows.Forms.TextBox();
        btnAdd = new System.Windows.Forms.Button();
        btnUpdate = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        dgvAnamnesis = new System.Windows.Forms.DataGridView();
        ((System.ComponentModel.ISupportInitialize)dgvAnamnesis).BeginInit();
        SuspendLayout();
        // 
        // lblPatient
        // 
        lblPatient.Location = new System.Drawing.Point(12, 15);
        lblPatient.Name = "lblPatient";
        lblPatient.Size = new System.Drawing.Size(100, 27);
        lblPatient.TabIndex = 48;
        lblPatient.Text = "Пациент:";
        // 
        // lblPatientName
        // 
        lblPatientName.Location = new System.Drawing.Point(150, 15);
        lblPatientName.Name = "lblPatientName";
        lblPatientName.Size = new System.Drawing.Size(400, 27);
        lblPatientName.TabIndex = 47;
        // 
        // lblDateOfDischarge
        // 
        lblDateOfDischarge.Location = new System.Drawing.Point(12, 50);
        lblDateOfDischarge.Name = "lblDateOfDischarge";
        lblDateOfDischarge.Size = new System.Drawing.Size(130, 27);
        lblDateOfDischarge.TabIndex = 46;
        lblDateOfDischarge.Text = "Дата выписки:";
        // 
        // dtpDateOfDischarge
        // 
        dtpDateOfDischarge.Format = System.Windows.Forms.DateTimePickerFormat.Short;
        dtpDateOfDischarge.Location = new System.Drawing.Point(150, 50);
        dtpDateOfDischarge.Name = "dtpDateOfDischarge";
        dtpDateOfDischarge.ShowCheckBox = true;
        dtpDateOfDischarge.Size = new System.Drawing.Size(200, 27);
        dtpDateOfDischarge.TabIndex = 45;
        // 
        // lblDateOfArrive
        // 
        lblDateOfArrive.Location = new System.Drawing.Point(12, 85);
        lblDateOfArrive.Name = "lblDateOfArrive";
        lblDateOfArrive.Size = new System.Drawing.Size(130, 27);
        lblDateOfArrive.TabIndex = 44;
        lblDateOfArrive.Text = "Дата поступления:";
        // 
        // dtpDateOfArrive
        // 
        dtpDateOfArrive.Location = new System.Drawing.Point(150, 85);
        dtpDateOfArrive.Name = "dtpDateOfArrive";
        dtpDateOfArrive.Size = new System.Drawing.Size(200, 27);
        dtpDateOfArrive.TabIndex = 43;
        // 
        // lblWard
        // 
        lblWard.Location = new System.Drawing.Point(12, 120);
        lblWard.Name = "lblWard";
        lblWard.Size = new System.Drawing.Size(100, 27);
        lblWard.TabIndex = 42;
        lblWard.Text = "Палата:";
        // 
        // txtWardSearch
        // 
        txtWardSearch.Location = new System.Drawing.Point(150, 120);
        txtWardSearch.Name = "txtWardSearch";
        txtWardSearch.PlaceholderText = "Введите номер палаты";
        txtWardSearch.Size = new System.Drawing.Size(150, 27);
        txtWardSearch.TabIndex = 41;
        // 
        // btnWardSearch
        // 
        btnWardSearch.Location = new System.Drawing.Point(310, 120);
        btnWardSearch.Name = "btnWardSearch";
        btnWardSearch.Size = new System.Drawing.Size(80, 27);
        btnWardSearch.TabIndex = 40;
        btnWardSearch.Text = "Найти";
        btnWardSearch.Click += btnWardSearch_Click;
        // 
        // lstWardResults
        // 
        lstWardResults.Location = new System.Drawing.Point(150, 150);
        lstWardResults.Name = "lstWardResults";
        lstWardResults.Size = new System.Drawing.Size(240, 44);
        lstWardResults.TabIndex = 39;
        lstWardResults.Visible = false;
        lstWardResults.Click += lstWardResults_Click;
        // 
        // lblSelectedWard
        // 
        lblSelectedWard.Location = new System.Drawing.Point(12, 155);
        lblSelectedWard.Name = "lblSelectedWard";
        lblSelectedWard.Size = new System.Drawing.Size(130, 27);
        lblSelectedWard.TabIndex = 38;
        lblSelectedWard.Text = "Не выбрано";
        // 
        // lblAdmittingDoctor
        // 
        lblAdmittingDoctor.Location = new System.Drawing.Point(12, 190);
        lblAdmittingDoctor.Name = "lblAdmittingDoctor";
        lblAdmittingDoctor.Size = new System.Drawing.Size(130, 27);
        lblAdmittingDoctor.TabIndex = 37;
        lblAdmittingDoctor.Text = "Принимающий врач:";
        // 
        // txtAdmittingDoctorSearch
        // 
        txtAdmittingDoctorSearch.Location = new System.Drawing.Point(150, 190);
        txtAdmittingDoctorSearch.Name = "txtAdmittingDoctorSearch";
        txtAdmittingDoctorSearch.PlaceholderText = "Введите фамилию врача";
        txtAdmittingDoctorSearch.Size = new System.Drawing.Size(200, 27);
        txtAdmittingDoctorSearch.TabIndex = 36;
        // 
        // btnAdmittingDoctorSearch
        // 
        btnAdmittingDoctorSearch.Location = new System.Drawing.Point(360, 190);
        btnAdmittingDoctorSearch.Name = "btnAdmittingDoctorSearch";
        btnAdmittingDoctorSearch.Size = new System.Drawing.Size(80, 27);
        btnAdmittingDoctorSearch.TabIndex = 35;
        btnAdmittingDoctorSearch.Text = "Найти";
        btnAdmittingDoctorSearch.Click += btnAdmittingDoctorSearch_Click;
        // 
        // lstAdmittingDoctorResults
        // 
        lstAdmittingDoctorResults.Location = new System.Drawing.Point(150, 220);
        lstAdmittingDoctorResults.Name = "lstAdmittingDoctorResults";
        lstAdmittingDoctorResults.Size = new System.Drawing.Size(290, 44);
        lstAdmittingDoctorResults.TabIndex = 34;
        lstAdmittingDoctorResults.Visible = false;
        lstAdmittingDoctorResults.Click += lstAdmittingDoctorResults_Click;
        // 
        // lblSelectedAdmittingDoctor
        // 
        lblSelectedAdmittingDoctor.Location = new System.Drawing.Point(12, 225);
        lblSelectedAdmittingDoctor.Name = "lblSelectedAdmittingDoctor";
        lblSelectedAdmittingDoctor.Size = new System.Drawing.Size(130, 27);
        lblSelectedAdmittingDoctor.TabIndex = 33;
        lblSelectedAdmittingDoctor.Text = "Не выбрано";
        // 
        // lblAttendingDoctor
        // 
        lblAttendingDoctor.Location = new System.Drawing.Point(12, 260);
        lblAttendingDoctor.Name = "lblAttendingDoctor";
        lblAttendingDoctor.Size = new System.Drawing.Size(130, 27);
        lblAttendingDoctor.TabIndex = 32;
        lblAttendingDoctor.Text = "Лечащий врач:";
        // 
        // txtAttendingDoctorSearch
        // 
        txtAttendingDoctorSearch.Location = new System.Drawing.Point(150, 260);
        txtAttendingDoctorSearch.Name = "txtAttendingDoctorSearch";
        txtAttendingDoctorSearch.PlaceholderText = "Введите фамилию врача";
        txtAttendingDoctorSearch.Size = new System.Drawing.Size(200, 27);
        txtAttendingDoctorSearch.TabIndex = 31;
        // 
        // btnAttendingDoctorSearch
        // 
        btnAttendingDoctorSearch.Location = new System.Drawing.Point(360, 260);
        btnAttendingDoctorSearch.Name = "btnAttendingDoctorSearch";
        btnAttendingDoctorSearch.Size = new System.Drawing.Size(80, 27);
        btnAttendingDoctorSearch.TabIndex = 30;
        btnAttendingDoctorSearch.Text = "Найти";
        btnAttendingDoctorSearch.Click += btnAttendingDoctorSearch_Click;
        // 
        // lstAttendingDoctorResults
        // 
        lstAttendingDoctorResults.Location = new System.Drawing.Point(150, 290);
        lstAttendingDoctorResults.Name = "lstAttendingDoctorResults";
        lstAttendingDoctorResults.Size = new System.Drawing.Size(290, 44);
        lstAttendingDoctorResults.TabIndex = 29;
        lstAttendingDoctorResults.Visible = false;
        lstAttendingDoctorResults.Click += lstAttendingDoctorResults_Click;
        // 
        // lblSelectedAttendingDoctor
        // 
        lblSelectedAttendingDoctor.Location = new System.Drawing.Point(12, 295);
        lblSelectedAttendingDoctor.Name = "lblSelectedAttendingDoctor";
        lblSelectedAttendingDoctor.Size = new System.Drawing.Size(130, 27);
        lblSelectedAttendingDoctor.TabIndex = 28;
        lblSelectedAttendingDoctor.Text = "Не выбрано";
        // 
        // lblComplaints
        // 
        lblComplaints.Location = new System.Drawing.Point(12, 340);
        lblComplaints.Name = "lblComplaints";
        lblComplaints.Size = new System.Drawing.Size(100, 27);
        lblComplaints.TabIndex = 27;
        lblComplaints.Text = "Жалобы:";
        // 
        // txtComplaints
        // 
        txtComplaints.Location = new System.Drawing.Point(150, 340);
        txtComplaints.Multiline = true;
        txtComplaints.Name = "txtComplaints";
        txtComplaints.Size = new System.Drawing.Size(400, 60);
        txtComplaints.TabIndex = 26;
        // 
        // lblMedicalHistory
        // 
        lblMedicalHistory.Location = new System.Drawing.Point(12, 420);
        lblMedicalHistory.Name = "lblMedicalHistory";
        lblMedicalHistory.Size = new System.Drawing.Size(130, 27);
        lblMedicalHistory.TabIndex = 25;
        lblMedicalHistory.Text = "История болезни:";
        // 
        // txtMedicalHistory
        // 
        txtMedicalHistory.Location = new System.Drawing.Point(150, 420);
        txtMedicalHistory.Multiline = true;
        txtMedicalHistory.Name = "txtMedicalHistory";
        txtMedicalHistory.Size = new System.Drawing.Size(400, 60);
        txtMedicalHistory.TabIndex = 24;
        // 
        // lblAllergies
        // 
        lblAllergies.Location = new System.Drawing.Point(12, 500);
        lblAllergies.Name = "lblAllergies";
        lblAllergies.Size = new System.Drawing.Size(100, 27);
        lblAllergies.TabIndex = 23;
        lblAllergies.Text = "Аллергии:";
        // 
        // clbAllergies
        // 
        clbAllergies.CheckOnClick = true;
        clbAllergies.Location = new System.Drawing.Point(150, 500);
        clbAllergies.Name = "clbAllergies";
        clbAllergies.Size = new System.Drawing.Size(400, 92);
        clbAllergies.TabIndex = 22;
        // 
        // txtOtherAllergy
        // 
        txtOtherAllergy.Enabled = false;
        txtOtherAllergy.Location = new System.Drawing.Point(150, 605);
        txtOtherAllergy.Name = "txtOtherAllergy";
        txtOtherAllergy.PlaceholderText = "Если выбрали \'Другое\', укажите аллергию";
        txtOtherAllergy.Size = new System.Drawing.Size(400, 27);
        txtOtherAllergy.TabIndex = 21;
        // 
        // lblBadHabits
        // 
        lblBadHabits.Location = new System.Drawing.Point(12, 650);
        lblBadHabits.Name = "lblBadHabits";
        lblBadHabits.Size = new System.Drawing.Size(130, 27);
        lblBadHabits.TabIndex = 20;
        lblBadHabits.Text = "Вредные привычки:";
        // 
        // clbBadHabits
        // 
        clbBadHabits.CheckOnClick = true;
        clbBadHabits.Location = new System.Drawing.Point(150, 650);
        clbBadHabits.Name = "clbBadHabits";
        clbBadHabits.Size = new System.Drawing.Size(400, 92);
        clbBadHabits.TabIndex = 19;
        // 
        // txtOtherBadHabit
        // 
        txtOtherBadHabit.Enabled = false;
        txtOtherBadHabit.Location = new System.Drawing.Point(150, 755);
        txtOtherBadHabit.Name = "txtOtherBadHabit";
        txtOtherBadHabit.PlaceholderText = "Если выбрали \'Другое\', укажите вредную привычку";
        txtOtherBadHabit.Size = new System.Drawing.Size(400, 27);
        txtOtherBadHabit.TabIndex = 18;
        // 
        // lblBloodPressureLow
        // 
        lblBloodPressureLow.Location = new System.Drawing.Point(12, 800);
        lblBloodPressureLow.Name = "lblBloodPressureLow";
        lblBloodPressureLow.Size = new System.Drawing.Size(130, 27);
        lblBloodPressureLow.TabIndex = 17;
        lblBloodPressureLow.Text = "Давление (нижн.):";
        // 
        // txtBloodPressureLow
        // 
        txtBloodPressureLow.Location = new System.Drawing.Point(150, 800);
        txtBloodPressureLow.Name = "txtBloodPressureLow";
        txtBloodPressureLow.Size = new System.Drawing.Size(80, 27);
        txtBloodPressureLow.TabIndex = 16;
        // 
        // lblBloodPressureHigh
        // 
        lblBloodPressureHigh.Location = new System.Drawing.Point(260, 800);
        lblBloodPressureHigh.Name = "lblBloodPressureHigh";
        lblBloodPressureHigh.Size = new System.Drawing.Size(130, 27);
        lblBloodPressureHigh.TabIndex = 15;
        lblBloodPressureHigh.Text = "Давление (верхн.):";
        // 
        // txtBloodPressureHigh
        // 
        txtBloodPressureHigh.Location = new System.Drawing.Point(400, 800);
        txtBloodPressureHigh.Name = "txtBloodPressureHigh";
        txtBloodPressureHigh.Size = new System.Drawing.Size(80, 27);
        txtBloodPressureHigh.TabIndex = 14;
        // 
        // lblPulse
        // 
        lblPulse.Location = new System.Drawing.Point(12, 840);
        lblPulse.Name = "lblPulse";
        lblPulse.Size = new System.Drawing.Size(80, 27);
        lblPulse.TabIndex = 13;
        lblPulse.Text = "Пульс:";
        // 
        // txtPulse
        // 
        txtPulse.Location = new System.Drawing.Point(90, 840);
        txtPulse.Name = "txtPulse";
        txtPulse.Size = new System.Drawing.Size(80, 27);
        txtPulse.TabIndex = 12;
        // 
        // lblSaturation
        // 
        lblSaturation.Location = new System.Drawing.Point(200, 840);
        lblSaturation.Name = "lblSaturation";
        lblSaturation.Size = new System.Drawing.Size(90, 27);
        lblSaturation.TabIndex = 11;
        lblSaturation.Text = "Сатурация:";
        // 
        // txtSaturation
        // 
        txtSaturation.Location = new System.Drawing.Point(300, 840);
        txtSaturation.Name = "txtSaturation";
        txtSaturation.Size = new System.Drawing.Size(80, 27);
        txtSaturation.TabIndex = 10;
        // 
        // lblThermometry
        // 
        lblThermometry.Location = new System.Drawing.Point(420, 840);
        lblThermometry.Name = "lblThermometry";
        lblThermometry.Size = new System.Drawing.Size(100, 27);
        lblThermometry.TabIndex = 9;
        lblThermometry.Text = "Температура:";
        // 
        // txtThermometry
        // 
        txtThermometry.Location = new System.Drawing.Point(530, 840);
        txtThermometry.Name = "txtThermometry";
        txtThermometry.Size = new System.Drawing.Size(80, 27);
        txtThermometry.TabIndex = 8;
        // 
        // lblSkin
        // 
        lblSkin.Location = new System.Drawing.Point(12, 880);
        lblSkin.Name = "lblSkin";
        lblSkin.Size = new System.Drawing.Size(80, 27);
        lblSkin.TabIndex = 7;
        lblSkin.Text = "Кожа:";
        // 
        // txtSkin
        // 
        txtSkin.Location = new System.Drawing.Point(90, 880);
        txtSkin.Name = "txtSkin";
        txtSkin.Size = new System.Drawing.Size(250, 27);
        txtSkin.TabIndex = 6;
        // 
        // lblMucosal
        // 
        lblMucosal.Location = new System.Drawing.Point(380, 880);
        lblMucosal.Name = "lblMucosal";
        lblMucosal.Size = new System.Drawing.Size(90, 27);
        lblMucosal.TabIndex = 5;
        lblMucosal.Text = "Слизистые:";
        // 
        // txtMucosal
        // 
        txtMucosal.Location = new System.Drawing.Point(480, 880);
        txtMucosal.Name = "txtMucosal";
        txtMucosal.Size = new System.Drawing.Size(250, 27);
        txtMucosal.TabIndex = 4;
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(12, 940);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(100, 35);
        btnAdd.TabIndex = 3;
        btnAdd.Text = "Добавить";
        btnAdd.Click += btnAdd_Click;
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(120, 940);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(100, 35);
        btnUpdate.TabIndex = 2;
        btnUpdate.Text = "Обновить";
        btnUpdate.Click += btnUpdate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new System.Drawing.Point(230, 940);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(100, 35);
        btnDelete.TabIndex = 1;
        btnDelete.Text = "Удалить";
        btnDelete.Click += btnDelete_Click;
        // 
        // dgvAnamnesis
        // 
        dgvAnamnesis.ColumnHeadersHeight = 29;
        dgvAnamnesis.Location = new System.Drawing.Point(805, 15);
        dgvAnamnesis.Name = "dgvAnamnesis";
        dgvAnamnesis.RowHeadersWidth = 51;
        dgvAnamnesis.Size = new System.Drawing.Size(1103, 200);
        dgvAnamnesis.TabIndex = 0;
        dgvAnamnesis.CellClick += dgvAnamnesis_CellClick;
        // 
        // AnamnesisForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1920, 1055);
        Controls.Add(dgvAnamnesis);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtMucosal);
        Controls.Add(lblMucosal);
        Controls.Add(txtSkin);
        Controls.Add(lblSkin);
        Controls.Add(txtThermometry);
        Controls.Add(lblThermometry);
        Controls.Add(txtSaturation);
        Controls.Add(lblSaturation);
        Controls.Add(txtPulse);
        Controls.Add(lblPulse);
        Controls.Add(txtBloodPressureHigh);
        Controls.Add(lblBloodPressureHigh);
        Controls.Add(txtBloodPressureLow);
        Controls.Add(lblBloodPressureLow);
        Controls.Add(txtOtherBadHabit);
        Controls.Add(clbBadHabits);
        Controls.Add(lblBadHabits);
        Controls.Add(txtOtherAllergy);
        Controls.Add(clbAllergies);
        Controls.Add(lblAllergies);
        Controls.Add(txtMedicalHistory);
        Controls.Add(lblMedicalHistory);
        Controls.Add(txtComplaints);
        Controls.Add(lblComplaints);
        Controls.Add(lblSelectedAttendingDoctor);
        Controls.Add(lstAttendingDoctorResults);
        Controls.Add(btnAttendingDoctorSearch);
        Controls.Add(txtAttendingDoctorSearch);
        Controls.Add(lblAttendingDoctor);
        Controls.Add(lblSelectedAdmittingDoctor);
        Controls.Add(lstAdmittingDoctorResults);
        Controls.Add(btnAdmittingDoctorSearch);
        Controls.Add(txtAdmittingDoctorSearch);
        Controls.Add(lblAdmittingDoctor);
        Controls.Add(lblSelectedWard);
        Controls.Add(lstWardResults);
        Controls.Add(btnWardSearch);
        Controls.Add(txtWardSearch);
        Controls.Add(lblWard);
        Controls.Add(dtpDateOfArrive);
        Controls.Add(lblDateOfArrive);
        Controls.Add(dtpDateOfDischarge);
        Controls.Add(lblDateOfDischarge);
        Controls.Add(lblPatientName);
        Controls.Add(lblPatient);
        Text = "Анамнезы пациента";
        ((System.ComponentModel.ISupportInitialize)dgvAnamnesis).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    // Объявления полей
    private Label lblPatient;
    private Label lblPatientName;
    private Label lblDateOfDischarge;
    private DateTimePicker dtpDateOfDischarge;
    private Label lblDateOfArrive;
    private DateTimePicker dtpDateOfArrive;
    private Label lblWard;
    private TextBox txtWardSearch;
    private Button btnWardSearch;
    private ListBox lstWardResults;
    private Label lblSelectedWard;
    private Label lblAdmittingDoctor;
    private TextBox txtAdmittingDoctorSearch;
    private Button btnAdmittingDoctorSearch;
    private ListBox lstAdmittingDoctorResults;
    private Label lblSelectedAdmittingDoctor;
    private Label lblAttendingDoctor;
    private TextBox txtAttendingDoctorSearch;
    private Button btnAttendingDoctorSearch;
    private ListBox lstAttendingDoctorResults;
    private Label lblSelectedAttendingDoctor;
    private Label lblComplaints;
    private TextBox txtComplaints;
    private Label lblMedicalHistory;
    private TextBox txtMedicalHistory;
    private Label lblAllergies;
    private CheckedListBox clbAllergies;
    private TextBox txtOtherAllergy;
    private Label lblBadHabits;
    private CheckedListBox clbBadHabits;
    private TextBox txtOtherBadHabit;
    private Label lblBloodPressureLow;
    private TextBox txtBloodPressureLow;
    private Label lblBloodPressureHigh;
    private TextBox txtBloodPressureHigh;
    private Label lblPulse;
    private TextBox txtPulse;
    private Label lblSaturation;
    private TextBox txtSaturation;
    private Label lblThermometry;
    private TextBox txtThermometry;
    private Label lblSkin;
    private TextBox txtSkin;
    private Label lblMucosal;
    private TextBox txtMucosal;
    private Button btnAdd;
    private Button btnUpdate;
    private Button btnDelete;
    private System.Windows.Forms.DataGridView dgvAnamnesis;
}