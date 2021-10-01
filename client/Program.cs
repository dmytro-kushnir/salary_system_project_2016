using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IPZ_Salary_System_NEW
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Autorization AutorForm = new Autorization();
            Application.Run(AutorForm);

            if (AutorForm.logonSuccesfull())   // Якщо всі дані введено правильно
            {
              Application.Run(new MainForm()); //  запускаємо головну форму
            }
            else
            { 
            Application.Exit();
            }
           
        }
    }
}
