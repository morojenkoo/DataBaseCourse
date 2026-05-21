using System.ComponentModel;

namespace HospitalApp.Forms;

partial class WardForm
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
        dgvWards = new System.Windows.Forms.DataGridView();
        lblWardNumber = new System.Windows.Forms.Label();
        lblBedCount = new System.Windows.Forms.Label();
        lblVipStatus = new System.Windows.Forms.Label();
        lblIsolationStatus = new System.Windows.Forms.Label();
        txtWardNumber = new System.Windows.Forms.TextBox();
        txtBedCount = new System.Windows.Forms.TextBox();
        cmbVipStatus = new System.Windows.Forms.ComboBox();
        txtIsolationStatus = new System.Windows.Forms.TextBox();
        btnAdd = new System.Windows.Forms.Button();
        btnUpdate = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        lblStats = new System.Windows.Forms.Label();
        btnRefreshStats = new System.Windows.Forms.Button();
        dgvPatientsInWard = new System.Windows.Forms.DataGridView();
        lblAnamnesisId = new System.Windows.Forms.Label();
        txtAnamnesisId = new System.Windows.Forms.TextBox();
        btnAddAnamnesis = new System.Windows.Forms.Button();
        btnDischarge = new System.Windows.Forms.Button();
        ((System.ComponentModel.ISupportInitialize)dgvWards).BeginInit();
        ((System.ComponentModel.ISupportInitialize)dgvPatientsInWard).BeginInit();
        SuspendLayout();
        // 
        // dgvWards
        // 
        dgvWards.ColumnHeadersHeight = 29;
        dgvWards.Location = new System.Drawing.Point(607, 35);
        dgvWards.Name = "dgvWards";
        dgvWards.RowHeadersWidth = 51;
        dgvWards.Size = new System.Drawing.Size(589, 150);
        dgvWards.TabIndex = 0;
        dgvWards.CellClick += dgvWards_CellClick;
        // 
        // lblWardNumber
        // 
        lblWardNumber.Location = new System.Drawing.Point(12, 188);
        lblWardNumber.Name = "lblWardNumber";
        lblWardNumber.Size = new System.Drawing.Size(114, 23);
        lblWardNumber.TabIndex = 1;
        lblWardNumber.Text = "Номер палаты";
        // 
        // lblBedCount
        // 
        lblBedCount.Location = new System.Drawing.Point(12, 221);
        lblBedCount.Name = "lblBedCount";
        lblBedCount.Size = new System.Drawing.Size(126, 23);
        lblBedCount.TabIndex = 2;
        lblBedCount.Text = "Количество мест";
        // 
        // lblVipStatus
        // 
        lblVipStatus.Location = new System.Drawing.Point(12, 254);
        lblVipStatus.Name = "lblVipStatus";
        lblVipStatus.Size = new System.Drawing.Size(100, 23);
        lblVipStatus.TabIndex = 3;
        lblVipStatus.Text = "Статус VIP";
        // 
        // lblIsolationStatus
        // 
        lblIsolationStatus.Location = new System.Drawing.Point(12, 287);
        lblIsolationStatus.Name = "lblIsolationStatus";
        lblIsolationStatus.Size = new System.Drawing.Size(144, 23);
        lblIsolationStatus.TabIndex = 4;
        lblIsolationStatus.Text = "Уровень изоляции";
        // 
        // txtWardNumber
        // 
        txtWardNumber.Location = new System.Drawing.Point(162, 187);
        txtWardNumber.Name = "txtWardNumber";
        txtWardNumber.Size = new System.Drawing.Size(121, 27);
        txtWardNumber.TabIndex = 5;
        // 
        // txtBedCount
        // 
        txtBedCount.Location = new System.Drawing.Point(162, 220);
        txtBedCount.Name = "txtBedCount";
        txtBedCount.Size = new System.Drawing.Size(121, 27);
        txtBedCount.TabIndex = 6;
        // 
        // cmbVipStatus
        // 
        cmbVipStatus.FormattingEnabled = true;
        cmbVipStatus.Items.AddRange(new object[] { "VIP", "Обычная" });
        cmbVipStatus.Location = new System.Drawing.Point(162, 253);
        cmbVipStatus.Name = "cmbVipStatus";
        cmbVipStatus.Size = new System.Drawing.Size(121, 28);
        cmbVipStatus.TabIndex = 7;
        // 
        // txtIsolationStatus
        // 
        txtIsolationStatus.Location = new System.Drawing.Point(162, 287);
        txtIsolationStatus.Name = "txtIsolationStatus";
        txtIsolationStatus.Size = new System.Drawing.Size(121, 27);
        txtIsolationStatus.TabIndex = 8;
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(12, 335);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(85, 28);
        btnAdd.TabIndex = 9;
        btnAdd.Text = "Добавить";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(103, 335);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(93, 28);
        btnUpdate.TabIndex = 10;
        btnUpdate.Text = "Обновить";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new System.Drawing.Point(202, 335);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(81, 28);
        btnDelete.TabIndex = 11;
        btnDelete.Text = "Удалить";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // lblStats
        // 
        lblStats.Location = new System.Drawing.Point(12, 9);
        lblStats.Name = "lblStats";
        lblStats.Size = new System.Drawing.Size(100, 23);
        lblStats.TabIndex = 12;
        lblStats.Text = "Статистика";
        // 
        // btnRefreshStats
        // 
        btnRefreshStats.Location = new System.Drawing.Point(103, 9);
        btnRefreshStats.Name = "btnRefreshStats";
        btnRefreshStats.Size = new System.Drawing.Size(180, 28);
        btnRefreshStats.TabIndex = 13;
        btnRefreshStats.Text = "Обновить статистику";
        btnRefreshStats.UseVisualStyleBackColor = true;
        // 
        // dgvPatientsInWard
        // 
        dgvPatientsInWard.ColumnHeadersHeight = 29;
        dgvPatientsInWard.Location = new System.Drawing.Point(12, 35);
        dgvPatientsInWard.Name = "dgvPatientsInWard";
        dgvPatientsInWard.RowHeadersWidth = 51;
        dgvPatientsInWard.Size = new System.Drawing.Size(589, 150);
        dgvPatientsInWard.TabIndex = 14;
        // 
        // lblAnamnesisId
        // 
        lblAnamnesisId.Location = new System.Drawing.Point(12, 411);
        lblAnamnesisId.Name = "lblAnamnesisId";
        lblAnamnesisId.Size = new System.Drawing.Size(184, 27);
        lblAnamnesisId.TabIndex = 15;
        lblAnamnesisId.Text = "Номер истории болезни\r\n";
        // 
        // txtAnamnesisId
        // 
        txtAnamnesisId.Location = new System.Drawing.Point(202, 411);
        txtAnamnesisId.Name = "txtAnamnesisId";
        txtAnamnesisId.Size = new System.Drawing.Size(168, 27);
        txtAnamnesisId.TabIndex = 16;
        // 
        // btnAddAnamnesis
        // 
        btnAddAnamnesis.Location = new System.Drawing.Point(380, 411);
        btnAddAnamnesis.Name = "btnAddAnamnesis";
        btnAddAnamnesis.Size = new System.Drawing.Size(150, 27);
        btnAddAnamnesis.TabIndex = 17;
        btnAddAnamnesis.Text = "Добавить в палату";
        btnAddAnamnesis.Click += btnAddAnamnesis_Click;
        // 
        // btnDischarge
        // 
        btnDischarge.Location = new System.Drawing.Point(550, 411);
        btnDischarge.Name = "btnDischarge";
        btnDischarge.Size = new System.Drawing.Size(150, 27);
        btnDischarge.TabIndex = 0;
        btnDischarge.Text = "Выписать пациента";
        btnDischarge.Click += btnDischarge_Click;
        // 
        // WardForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1920, 1055);
        Controls.Add(btnDischarge);
        Controls.Add(dgvPatientsInWard);
        Controls.Add(btnRefreshStats);
        Controls.Add(lblStats);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtIsolationStatus);
        Controls.Add(cmbVipStatus);
        Controls.Add(txtBedCount);
        Controls.Add(txtWardNumber);
        Controls.Add(lblIsolationStatus);
        Controls.Add(lblVipStatus);
        Controls.Add(lblBedCount);
        Controls.Add(lblWardNumber);
        Controls.Add(dgvWards);
        Controls.Add(lblAnamnesisId);
        Controls.Add(txtAnamnesisId);
        Controls.Add(btnAddAnamnesis);
        Text = "WardForm";
        ((System.ComponentModel.ISupportInitialize)dgvWards).EndInit();
        ((System.ComponentModel.ISupportInitialize)dgvPatientsInWard).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.DataGridView dgvPatientsInWard;
    private System.Windows.Forms.Label lblStats;
    private Button btnRefreshStats;
        
    private System.Windows.Forms.Button btnAddAnamnesis;
    //private System.Windows.Forms.Button btnRefreshStats;
    
    private System.Windows.Forms.Label lblAnamnesisId;
    private System.Windows.Forms.TextBox txtAnamnesisId;
    private System.Windows.Forms.Button btnDischarge;
    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;
    private System.Windows.Forms.TextBox txtIsolationStatus;
    private System.Windows.Forms.TextBox txtWardNumber;

    private System.Windows.Forms.ComboBox cmbVipStatus;

    private System.Windows.Forms.TextBox txtBedCount;

    private System.Windows.Forms.Label lblIsolationStatus;

    private System.Windows.Forms.Label lblVipStatus;

    private System.Windows.Forms.Label lblBedCount;

    private System.Windows.Forms.Label lblWardNumber;

    private System.Windows.Forms.DataGridView dgvWards;

    #endregion
}