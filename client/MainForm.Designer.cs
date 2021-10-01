namespace IPZ_Salary_System_NEW
{
  partial class MainForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
      this.groupBox1 = new System.Windows.Forms.GroupBox();
      this.button_accure_salary = new System.Windows.Forms.Button();
      this.txtYear = new System.Windows.Forms.TextBox();
      this.accure_salary = new System.Windows.Forms.TextBox();
      this.label4 = new System.Windows.Forms.Label();
      this.txtSalary = new System.Windows.Forms.TextBox();
      this.label3 = new System.Windows.Forms.Label();
      this.txtPosition = new System.Windows.Forms.TextBox();
      this.label2 = new System.Windows.Forms.Label();
      this.txtName = new System.Windows.Forms.TextBox();
      this.label1 = new System.Windows.Forms.Label();
      this.btnAddWorker = new System.Windows.Forms.Button();
      this.btnAddDepartment = new System.Windows.Forms.Button();
      this.Department_list_view = new System.Windows.Forms.TreeView();
      this.btnRemoveWorker = new System.Windows.Forms.Button();
      this.btnRemoveDepartment = new System.Windows.Forms.Button();
      this.timer1 = new System.Windows.Forms.Timer(this.components);
      this.button1 = new System.Windows.Forms.Button();
      this.groupBox1.SuspendLayout();
      this.SuspendLayout();
      // 
      // groupBox1
      // 
      this.groupBox1.Controls.Add(this.button_accure_salary);
      this.groupBox1.Controls.Add(this.txtYear);
      this.groupBox1.Controls.Add(this.accure_salary);
      this.groupBox1.Controls.Add(this.label4);
      this.groupBox1.Controls.Add(this.txtSalary);
      this.groupBox1.Controls.Add(this.label3);
      this.groupBox1.Controls.Add(this.txtPosition);
      this.groupBox1.Controls.Add(this.label2);
      this.groupBox1.Controls.Add(this.txtName);
      this.groupBox1.Controls.Add(this.label1);
      this.groupBox1.Location = new System.Drawing.Point(278, 80);
      this.groupBox1.Name = "groupBox1";
      this.groupBox1.Size = new System.Drawing.Size(283, 170);
      this.groupBox1.TabIndex = 9;
      this.groupBox1.TabStop = false;
      this.groupBox1.Text = "Дані";
      // 
      // button_accure_salary
      // 
      this.button_accure_salary.Enabled = false;
      this.button_accure_salary.Location = new System.Drawing.Point(9, 137);
      this.button_accure_salary.Name = "button_accure_salary";
      this.button_accure_salary.Size = new System.Drawing.Size(104, 23);
      this.button_accure_salary.TabIndex = 10;
      this.button_accure_salary.Text = "Нарах. зар. плату";
      this.button_accure_salary.UseVisualStyleBackColor = true;
      this.button_accure_salary.Click += new System.EventHandler(this.button_accure_salary_Click);
      // 
      // txtYear
      // 
      this.txtYear.Location = new System.Drawing.Point(125, 107);
      this.txtYear.Name = "txtYear";
      this.txtYear.ReadOnly = true;
      this.txtYear.Size = new System.Drawing.Size(152, 20);
      this.txtYear.TabIndex = 9;
      // 
      // accure_salary
      // 
      this.accure_salary.Location = new System.Drawing.Point(125, 140);
      this.accure_salary.Name = "accure_salary";
      this.accure_salary.Size = new System.Drawing.Size(152, 20);
      this.accure_salary.TabIndex = 7;
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(6, 107);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(90, 13);
      this.label4.TabIndex = 6;
      this.label4.Text = "Рік народження:";
      // 
      // txtSalary
      // 
      this.txtSalary.Location = new System.Drawing.Point(125, 81);
      this.txtSalary.Name = "txtSalary";
      this.txtSalary.ReadOnly = true;
      this.txtSalary.Size = new System.Drawing.Size(152, 20);
      this.txtSalary.TabIndex = 5;
      // 
      // label3
      // 
      this.label3.AutoSize = true;
      this.label3.Location = new System.Drawing.Point(6, 81);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(117, 13);
      this.label3.TabIndex = 4;
      this.label3.Text = "Поточний баланс(грн)";
      // 
      // txtPosition
      // 
      this.txtPosition.Location = new System.Drawing.Point(125, 55);
      this.txtPosition.Name = "txtPosition";
      this.txtPosition.ReadOnly = true;
      this.txtPosition.Size = new System.Drawing.Size(152, 20);
      this.txtPosition.TabIndex = 3;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(9, 55);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(48, 13);
      this.label2.TabIndex = 2;
      this.label2.Text = "Посада:";
      // 
      // txtName
      // 
      this.txtName.Location = new System.Drawing.Point(125, 22);
      this.txtName.Name = "txtName";
      this.txtName.ReadOnly = true;
      this.txtName.Size = new System.Drawing.Size(152, 20);
      this.txtName.TabIndex = 1;
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(9, 29);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(28, 13);
      this.label1.TabIndex = 0;
      this.label1.Text = "ПІБ:";
      // 
      // btnAddWorker
      // 
      this.btnAddWorker.Enabled = false;
      this.btnAddWorker.Location = new System.Drawing.Point(278, 12);
      this.btnAddWorker.Name = "btnAddWorker";
      this.btnAddWorker.Size = new System.Drawing.Size(115, 23);
      this.btnAddWorker.TabIndex = 8;
      this.btnAddWorker.Text = "Додати робітника";
      this.btnAddWorker.UseVisualStyleBackColor = true;
      this.btnAddWorker.Click += new System.EventHandler(this.btnAddWorker_Click);
      // 
      // btnAddDepartment
      // 
      this.btnAddDepartment.Location = new System.Drawing.Point(278, 41);
      this.btnAddDepartment.Name = "btnAddDepartment";
      this.btnAddDepartment.Size = new System.Drawing.Size(115, 23);
      this.btnAddDepartment.TabIndex = 6;
      this.btnAddDepartment.Text = "Додати відділ";
      this.btnAddDepartment.UseVisualStyleBackColor = true;
      this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
      // 
      // Department_list_view
      // 
      this.Department_list_view.Location = new System.Drawing.Point(1, 12);
      this.Department_list_view.Name = "Department_list_view";
      this.Department_list_view.Size = new System.Drawing.Size(268, 238);
      this.Department_list_view.TabIndex = 7;
      this.Department_list_view.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.Item_AfterSelect);
      // 
      // btnRemoveWorker
      // 
      this.btnRemoveWorker.Enabled = false;
      this.btnRemoveWorker.Location = new System.Drawing.Point(446, 12);
      this.btnRemoveWorker.Name = "btnRemoveWorker";
      this.btnRemoveWorker.Size = new System.Drawing.Size(115, 23);
      this.btnRemoveWorker.TabIndex = 11;
      this.btnRemoveWorker.Text = "Видалити робітника";
      this.btnRemoveWorker.UseVisualStyleBackColor = true;
      this.btnRemoveWorker.Click += new System.EventHandler(this.btnRemoveWorker_Click);
      // 
      // btnRemoveDepartment
      // 
      this.btnRemoveDepartment.Enabled = false;
      this.btnRemoveDepartment.Location = new System.Drawing.Point(446, 41);
      this.btnRemoveDepartment.Name = "btnRemoveDepartment";
      this.btnRemoveDepartment.Size = new System.Drawing.Size(115, 23);
      this.btnRemoveDepartment.TabIndex = 10;
      this.btnRemoveDepartment.Text = "Видалити відділ";
      this.btnRemoveDepartment.UseVisualStyleBackColor = true;
      this.btnRemoveDepartment.Click += new System.EventHandler(this.btnRemoveDepartment_Click);
      // 
      // button1
      // 
      this.button1.Location = new System.Drawing.Point(1, 256);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(101, 23);
      this.button1.TabIndex = 12;
      this.button1.Text = "Обновити";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.button1_Click);
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.InactiveCaption;
      this.ClientSize = new System.Drawing.Size(573, 288);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.groupBox1);
      this.Controls.Add(this.btnAddWorker);
      this.Controls.Add(this.btnAddDepartment);
      this.Controls.Add(this.Department_list_view);
      this.Controls.Add(this.btnRemoveWorker);
      this.Controls.Add(this.btnRemoveDepartment);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "MainForm";
      this.Text = "Система обліку і нарахування заробітної плати                        ©Dima_Kush ";
      this.Activated += new System.EventHandler(this.MainForm_Activated);
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Load += new System.EventHandler(this.MainForm_Load);
      this.groupBox1.ResumeLayout(false);
      this.groupBox1.PerformLayout();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.TextBox txtYear;
    private System.Windows.Forms.TextBox accure_salary;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.TextBox txtSalary;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.TextBox txtPosition;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.TextBox txtName;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnAddWorker;
    private System.Windows.Forms.Button btnAddDepartment;
    private System.Windows.Forms.Button btnRemoveWorker;
    private System.Windows.Forms.Button btnRemoveDepartment;
    private System.Windows.Forms.Button button_accure_salary;
    private System.Windows.Forms.TreeView Department_list_view;
    private System.Windows.Forms.Timer timer1;
    private System.Windows.Forms.Button button1;
  }
}