namespace HospitalApp.Forms;

partial class Form1
{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
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
        btnDepartments = new System.Windows.Forms.Button();
        btnPatients = new System.Windows.Forms.Button();
        btnEmployees = new System.Windows.Forms.Button();
        SuspendLayout();
        // 
        // btnDepartments
        // 
        btnDepartments.Location = new System.Drawing.Point(12, 12);
        btnDepartments.Name = "btnDepartments";
        btnDepartments.Size = new System.Drawing.Size(240, 35);
        btnDepartments.TabIndex = 1;
        btnDepartments.Text = "Отделения";
        btnDepartments.UseVisualStyleBackColor = true;
        btnDepartments.Click += btnDepartments_Click;
        // 
        // btnPatients
        // 
        btnPatients.Location = new System.Drawing.Point(258, 12);
        btnPatients.Name = "btnPatients";
        btnPatients.Size = new System.Drawing.Size(240, 35);
        btnPatients.TabIndex = 2;
        btnPatients.Text = "Пациенты";
        btnPatients.UseVisualStyleBackColor = true;
        btnPatients.Click += btnPatients_Click;
        // 
        // btnEmployees
        // 
        btnEmployees.Location = new System.Drawing.Point(504, 12);
        btnEmployees.Name = "btnEmployees";
        btnEmployees.Size = new System.Drawing.Size(240, 35);
        btnEmployees.TabIndex = 3;
        btnEmployees.Text = "Сотрудники";
        btnEmployees.UseVisualStyleBackColor = true;
        btnEmployees.Click += btnEmployees_Click;
        // 
        // Form1
        // 
        AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        ClientSize = new System.Drawing.Size(1920, 1055);
        Controls.Add(btnEmployees);
        Controls.Add(btnPatients);
        Controls.Add(btnDepartments);
        Text = "Form1";
        ResumeLayout(false);
    }

    private System.Windows.Forms.Button btnEmployees;

    private System.Windows.Forms.Button btnPatients;

    private System.Windows.Forms.Button btnDepartments;

    #endregion
}