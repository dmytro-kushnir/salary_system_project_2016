namespace IPZ_Salary_System_NEW
{
  partial class NewDepartment
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
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewDepartment));
      this.label2 = new System.Windows.Forms.Label();
      this.label1 = new System.Windows.Forms.Label();
      this.btnAddDepartment = new System.Windows.Forms.Button();
      this.txtDescription = new System.Windows.Forms.TextBox();
      this.txtNameCom = new System.Windows.Forms.TextBox();
      this.SuspendLayout();
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label2.Location = new System.Drawing.Point(74, 9);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(99, 16);
      this.label2.TabIndex = 11;
      this.label2.Text = "Назва відділу";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.label1.Location = new System.Drawing.Point(74, 53);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(90, 16);
      this.label1.TabIndex = 10;
      this.label1.Text = "Опис відділу";
      // 
      // btnAddDepartment
      // 
      this.btnAddDepartment.Enabled = false;
      this.btnAddDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.btnAddDepartment.Location = new System.Drawing.Point(87, 215);
      this.btnAddDepartment.Name = "btnAddDepartment";
      this.btnAddDepartment.Size = new System.Drawing.Size(75, 23);
      this.btnAddDepartment.TabIndex = 8;
      this.btnAddDepartment.Text = "Додати";
      this.btnAddDepartment.UseVisualStyleBackColor = true;
      this.btnAddDepartment.Click += new System.EventHandler(this.btnAddDepartment_Click);
      // 
      // txtDescription
      // 
      this.txtDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
      this.txtDescription.Location = new System.Drawing.Point(26, 72);
      this.txtDescription.Multiline = true;
      this.txtDescription.Name = "txtDescription";
      this.txtDescription.Size = new System.Drawing.Size(203, 135);
      this.txtDescription.TabIndex = 7;
      this.txtDescription.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
      this.txtDescription.TextChanged += new System.EventHandler(this.txtNameCom_TextChanged2);
      // 
      // txtNameCom
      // 
      this.txtNameCom.Location = new System.Drawing.Point(26, 30);
      this.txtNameCom.Name = "txtNameCom";
      this.txtNameCom.Size = new System.Drawing.Size(203, 20);
      this.txtNameCom.TabIndex = 12;
      // 
      // NewDepartment
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.BackColor = System.Drawing.SystemColors.ControlLight;
      this.ClientSize = new System.Drawing.Size(254, 250);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.btnAddDepartment);
      this.Controls.Add(this.txtDescription);
      this.Controls.Add(this.txtNameCom);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.Name = "NewDepartment";
      this.Text = "Додати відділ";
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Button btnAddDepartment;
    private System.Windows.Forms.TextBox txtDescription;
    private System.Windows.Forms.TextBox txtNameCom;
  }
}