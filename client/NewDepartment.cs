using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IPZ_Salary_System_NEW
{

  public partial class NewDepartment : Form
  {
    public NewDepartment()
    {
 
      InitializeComponent();
    }

    private void btnAddDepartment_Click(object sender, EventArgs e)
    {
      try
      {    
      if (txtNameCom.Text != "" && txtDescription.Text != "")
      {
        MainForm.bFlag = true;
        if (txtNameCom.Text.IndexOf("Відділ") == 0) 
        {
          MainForm.department.Department_Name = txtNameCom.Text; 
        }
        else
        {
          MainForm.department.Department_Name = "Вiддiл " + txtNameCom.Text; 
        }
        MainForm.department.Department_Description = txtDescription.Text;
        // пiдключаємось до серверу
        MainForm.department.Connection_Show("->AddDepartment\n" + MainForm.department.Department_Name
        + "\n" + MainForm.department.Department_Description);  
        NewDepartment.ActiveForm.Close();
      }
      else
      {
        MessageBox.Show("Заповніть всі поля");
      }
      }
 catch (Exception ex)
      {
         MessageBox.Show(ex.ToString());
      }
    }


    private void txtNameCom_TextChanged2(object sender, EventArgs e)
    {
      btnAddDepartment.Enabled = true;
    }
  }
}
