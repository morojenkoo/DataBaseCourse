using System.ComponentModel;

namespace HospitalApp.Forms;

partial class DepartmentForm
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
        txtSearchName = new System.Windows.Forms.TextBox();
        btnSearch = new System.Windows.Forms.Button();
        dgvDepartments = new System.Windows.Forms.DataGridView();
        txtDepartmentName = new System.Windows.Forms.TextBox();
        txtFloorNumber = new System.Windows.Forms.TextBox();
        txtInnerPhone = new System.Windows.Forms.TextBox();
        btnAdd = new System.Windows.Forms.Button();
        btnUpdate = new System.Windows.Forms.Button();
        btnDelete = new System.Windows.Forms.Button();
        btnWards = new System.Windows.Forms.Button();
        lblSearch = new System.Windows.Forms.Label();
        lblDepartmentName = new System.Windows.Forms.Label();
        lblFloorNumber = new System.Windows.Forms.Label();
        lblInnerPhone = new System.Windows.Forms.Label();
        ((System.ComponentModel.ISupportInitialize)dgvDepartments).BeginInit();
        SuspendLayout();
        // 
        // txtSearchName
        // 
        txtSearchName.Location = new System.Drawing.Point(78, 9);
        txtSearchName.Name = "txtSearchName";
        txtSearchName.Size = new System.Drawing.Size(342, 27);
        txtSearchName.TabIndex = 0;
        // 
        // btnSearch
        // 
        btnSearch.Location = new System.Drawing.Point(426, 9);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new System.Drawing.Size(104, 27);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Найти";
        btnSearch.UseVisualStyleBackColor = true;
        btnSearch.Click += btnSearch_Click;
        // 
        // dgvDepartments
        // 
        dgvDepartments.ColumnHeadersHeight = 29;
        dgvDepartments.Location = new System.Drawing.Point(12, 45);
        dgvDepartments.Name = "dgvDepartments";
        dgvDepartments.RowHeadersWidth = 51;
        dgvDepartments.Size = new System.Drawing.Size(1896, 150);
        dgvDepartments.TabIndex = 2;
        dgvDepartments.CellClick += dgvDepartments_CellClick;
        // 
        // txtDepartmentName
        // 
        txtDepartmentName.Location = new System.Drawing.Point(177, 201);
        txtDepartmentName.Name = "txtDepartmentName";
        txtDepartmentName.Size = new System.Drawing.Size(399, 27);
        txtDepartmentName.TabIndex = 3;
        txtDepartmentName.Text = "\r\n";
        // 
        // txtFloorNumber
        // 
        txtFloorNumber.Location = new System.Drawing.Point(177, 234);
        txtFloorNumber.Name = "txtFloorNumber";
        txtFloorNumber.Size = new System.Drawing.Size(75, 27);
        txtFloorNumber.TabIndex = 4;
        // 
        // txtInnerPhone
        // 
        txtInnerPhone.Location = new System.Drawing.Point(177, 267);
        txtInnerPhone.Name = "txtInnerPhone";
        txtInnerPhone.Size = new System.Drawing.Size(399, 27);
        txtInnerPhone.TabIndex = 5;
        txtInnerPhone.Text = "\r\n\r\n";
        // 
        // btnAdd
        // 
        btnAdd.Location = new System.Drawing.Point(12, 300);
        btnAdd.Name = "btnAdd";
        btnAdd.Size = new System.Drawing.Size(104, 27);
        btnAdd.TabIndex = 6;
        btnAdd.Text = "Добавить";
        btnAdd.UseVisualStyleBackColor = true;
        btnAdd.Click += btnAdd_Click;
        // 
        // btnUpdate
        // 
        btnUpdate.Location = new System.Drawing.Point(122, 300);
        btnUpdate.Name = "btnUpdate";
        btnUpdate.Size = new System.Drawing.Size(104, 27);
        btnUpdate.TabIndex = 7;
        btnUpdate.Text = "Обновить";
        btnUpdate.UseVisualStyleBackColor = true;
        btnUpdate.Click += btnUpdate_Click;
        // 
        // btnDelete
        // 
        btnDelete.Location = new System.Drawing.Point(232, 300);
        btnDelete.Name = "btnDelete";
        btnDelete.Size = new System.Drawing.Size(104, 27);
        btnDelete.TabIndex = 8;
        btnDelete.Text = "Удалить";
        btnDelete.UseVisualStyleBackColor = true;
        btnDelete.Click += btnDelete_Click;
        // 
        // btnWards
        // 
        btnWards.Location = new System.Drawing.Point(12, 377);
        btnWards.Name = "btnWards";
        btnWards.Size = new System.Drawing.Size(104, 27);
        btnWards.TabIndex = 9;
        btnWards.Text = "Палаты";
        btnWards.UseVisualStyleBackColor = true;
        btnWards.Click += btnWards_Click;
        // 
        // lblSearch
        // 
        lblSearch.Location = new System.Drawing.Point(16, 12);
        lblSearch.Name = "lblSearch";
        lblSearch.Size = new System.Drawing.Size(56, 27);
        lblSearch.TabIndex = 10;
        lblSearch.Text = "Поиск";
        // 
        // lblDepartmentName
        // 
        lblDepartmentName.Location = new System.Drawing.Point(16, 204);
        lblDepartmentName.Name = "lblDepartmentName";
        lblDepartmentName.Size = new System.Drawing.Size(155, 23);
        lblDepartmentName.TabIndex = 11;
        lblDepartmentName.Text = "Название отделения";
        // 
        // lblFloorNumber
        // 
        lblFloorNumber.Location = new System.Drawing.Point(16, 234);
        lblFloorNumber.Name = "lblFloorNumber";
        lblFloorNumber.Size = new System.Drawing.Size(155, 23);
        lblFloorNumber.TabIndex = 12;
        lblFloorNumber.Text = "Номер этажа";
        // 
        // lblInnerPhone
        // 
        lblInnerPhone.Location = new System.Drawing.Point(16, 267);
        lblInnerPhone.Name = "lblInnerPhone";
        lblInnerPhone.Size = new System.Drawing.Size(155, 23);
        lblInnerPhone.TabIndex = 13;
        lblInnerPhone.Text = "Внутренний телефон";
        // 
        // DepartmentForm
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1920, 1055);
        Controls.Add(lblInnerPhone);
        Controls.Add(lblFloorNumber);
        Controls.Add(lblDepartmentName);
        Controls.Add(lblSearch);
        Controls.Add(btnWards);
        Controls.Add(btnDelete);
        Controls.Add(btnUpdate);
        Controls.Add(btnAdd);
        Controls.Add(txtInnerPhone);
        Controls.Add(txtFloorNumber);
        Controls.Add(txtDepartmentName);
        Controls.Add(dgvDepartments);
        Controls.Add(btnSearch);
        Controls.Add(txtSearchName);
        Text = "DepartmentForm";
        ((System.ComponentModel.ISupportInitialize)dgvDepartments).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    private System.Windows.Forms.Label lblInnerPhone;

    private System.Windows.Forms.Label lblFloorNumber;

    private System.Windows.Forms.Label lblDepartmentName;

    private System.Windows.Forms.Label lblSearch;

    private System.Windows.Forms.Button btnWards;

    private System.Windows.Forms.Button btnAdd;
    private System.Windows.Forms.Button btnUpdate;
    private System.Windows.Forms.Button btnDelete;

    private System.Windows.Forms.TextBox txtInnerPhone;

    private System.Windows.Forms.DataGridView dgvDepartments;

    private System.Windows.Forms.Button btnSearch;

    private System.Windows.Forms.TextBox txtSearchName;
    private System.Windows.Forms.TextBox txtDepartmentName;
    private System.Windows.Forms.TextBox txtFloorNumber;
    #endregion
}