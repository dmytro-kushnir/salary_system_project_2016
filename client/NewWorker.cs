using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;


namespace IPZ_Salary_System_NEW
{

  public partial class NewWorker : Form
  {
 
    public NewWorker()
    {
      InitializeComponent();
    }

    private void btnAddWorker_Click(object sender, EventArgs e)
    {
      if (txtName.Text != "" && txtPosition.Text != "" && txtSalary.Text != "" && Year.Text != "")
      {
      try
      {
        MainForm.bFlagDp = true;
        MainForm.worker.Worker_PIB = txtName.Text;
        MainForm.worker.Worker_Position = txtPosition.Text;
        MainForm.worker.Worker_Salary = Convert.ToInt32(txtSalary.Text);
        MainForm.worker.Worker_Age = Convert.ToInt32(Year.Text);
        // пiдключаємось до серверу
        MainForm.worker.Connection_Show("->AddWorker" + "\n"
          + MainForm.worker.Worker_PIB + "\n|"
          + MainForm.worker.Worker_Position + "\n||"
          + MainForm.worker.Worker_Salary + "\n|||"
          + MainForm.worker.Worker_Age);
        this.Close();
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      } 
      }
      else
      {
        MessageBox.Show("Заповніть всі поля");
      }
    }
  }
}
