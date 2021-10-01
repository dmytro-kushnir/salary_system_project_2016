using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace IPZ_Salary_System_NEW
{
  public partial class Autorization : Form
  {
    public Autorization()
    {
      InitializeComponent();

      PasswordBox.PasswordChar = '*';
    }
    private static bool choice = false;
    public bool logonSuccesfull()
    {
      return choice;
    }
  
    SyncronousSocket socket = new SyncronousSocket();
    CLogin login = new CLogin();

    public void Parser(string buf1, string buf2)
    {
      try { 
      string key = "|"; // ключ яким будемо дешифрувати
      string dot = ".";
      int lastKey_Log = buf1.IndexOf("`"); // Відрізаємо ключ №2 (який потрібен для визначення довжини ключа №1)від повідомлення
      int lastKey_Pass = buf2.IndexOf("`");

      int endKey_Log = buf1.Length - lastKey_Log - 1; // розмір ключа. на 1 менше! (5)
      int endKey_Pass = buf2.Length - lastKey_Pass - 1;
      int[] indexes_Log = new int[endKey_Log]; // масив для логінів
      int[] indexes_Pass = new int[endKey_Pass]; // для паролів
      // забираємо ключик, необхідний для визначення кінця основного ключа
      string logins = buf1.Replace("`", "");
      string passwords = buf2.Replace("`", "");

      int i = 0;
      int k = 1;
      // рахуємо розміри стрічок для логінів і паролів
      for (string j = key; j.Length != (endKey_Log + 1); j = j + dot)
      {
        indexes_Log[i] = logins.IndexOf(j) + k;
        indexes_Pass[i] = passwords.IndexOf(j) + k;
        i++;
        k++;
      }

      if (!LoginBox.Text.Equals("") && !PasswordBox.Text.Equals(""))
      {
        int v = 1;
        int r = 2;

        for (int j = 0; j < endKey_Log - 1; j++)
        { // Витягуємо логіни і паролі за допомогою отиманих розмірів ключів
          string Login = logins.Substring(indexes_Log[j], indexes_Log[v] - indexes_Log[j] - r);
          string Password = passwords.Substring(indexes_Pass[j], indexes_Pass[v] - indexes_Pass[j] - r);
          v++;
          r++;
          if (LoginBox.Text.Equals(Login) && PasswordBox.Text.Equals(Password))
          {
            choice = true;
            logonSuccesfull(); // все ОК закриваємо форму. Відкриваємо головну форму в Program.cs
            this.Close();
          }
          else
            Error_label.Text = "Неправильний логін або пароль!";
        }
      }
      else
        Error_label.Text = "Введіть інформацію!";
    }
      catch
      {
        //MessageBox.Show("Не отримано даних з серверу");
        //this.Close();
      }
    }

    public void button1_Click(object sender, EventArgs e)
    {
      try
      {   
        socket.local_IP = IPAddress.Parse(LocacIpTextBox.Text); // відсилаємо адресу хоста в клас комунікації
        socket.Connection_Show("->Autorization" + "\n");
      }
      catch 
      {
        MessageBox.Show("Не правильно введена IP-адреса");
      }
      login.Login_UserName = SyncronousSocket.rec_msg_dep;
      login.Login_Password = SyncronousSocket.rec_msg_wor;
      Parser(login.Login_UserName, login.Login_Password); // парсимо вхідні дані
    }

    private void Autorization_Load(object sender, EventArgs e)
    {
      try
      {
        //socket.local_IP = IPAddress.Parse(LocacIpTextBox.Text);
   //   socket.Connection_Show("->Autorization" + "\n");  // підключаємось до серверу
      }
      catch(Exception ex)
      {
        MessageBox.Show(ex.ToString());
        Application.Exit();
      }
    
    }

    private void Autorization_FormClosing(object sender, FormClosingEventArgs e)
    {
      //if(e.CloseReason == CloseReason.WindowsShutDown)
      //{ 
      //   SyncronousSocket socket = new SyncronousSocket();
      //  socket.Connection_Show("->ExitClient \n");
      //}  
  }
  }
}
