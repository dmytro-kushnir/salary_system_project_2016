// SocketServer.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.IO;


namespace Salary_System_Server
{
  public class Server
  {
    // застосовується для парсингу команд
    public enum Commands
    {
      None,
      Unknown,
      MainFormLoad,
      ItemSelected,
      AddWorker,
      AddDepartment,
      AccureSalary,
      DeleteWorker,
      DeleteDepartment,
      Autorization,
      ExitClient
    }
    private static Commands command_items = Commands.None;
    private static CConnectDB connecDB;
    // поля для передачі між методами
    private static string iId;
    private static string txtName;
    private static string txtSalary;

    // Запити до бази даних. Використовуються після парсингу команд
    private static void Connect2DB_Depart(CConnectDB Cdb, string Dname, string Ddescr)
    {
      Cdb.myOleDbConnection.Open();
      Console.WriteLine("Запис iменi/опису вiддiлу у БД: " + Dname + " , " + Ddescr);
      Cdb.Query("INSERT INTO Departments (Name, Description) VALUES (\"" + Dname + "\",\"" + Ddescr + "\")");
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("ДОДАНО данi до БД: " + Dname + ", " + Ddescr);
    }
    private static void Connect2DB_Worker(CConnectDB Cdb, string WorName, string WorPos, string WorSalary, string WorYear)
    {
      Cdb.myOleDbConnection.Open();
      Console.WriteLine("Запис iменi/посади/зарплати/року народження працiвника у БД: " + WorName
      + " , " + WorPos + " , " + WorSalary + " , " + WorYear);
      Cdb.Query("INSERT INTO Members (id_dep, Name, Surname, Middle_name, Age) VALUES (" + iId.ToString() + ",\"" + WorName + "\",\"" +
        WorPos + "\",\"" + WorSalary.ToString() + "\",\"" + WorYear.ToString() + "\")");
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("ДОДАНО данi до БД: " + iId + ", " + WorName + ", " + WorPos + ", " + WorSalary + ", " + WorYear);
    }
    private static string Connect2DB_MainForm_Activated_Dep(CConnectDB Cdb)
    {
      string DepName = "";
      string szName = "";
      string szCom_name = "";

      string buffer1 = "";
      string key = "|";
      string dot = ".";
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT Name FROM Departments");
      while (Cdb.myOleDbDataReader.Read())
      {
        DepName = Cdb.myOleDbDataReader["Name"].ToString();

        buffer1 = buffer1 + key + DepName;
        key = key + dot;
      }
      Cdb.myOleDbConnection.Close();
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT Departments.Name, Members.Name FROM Members, Departments WHERE Members.id_dep = Departments.id");
      while (Cdb.myOleDbDataReader.Read())
      {
        szName = Cdb.myOleDbDataReader["Members.Name"].ToString();

        szCom_name = Cdb.myOleDbDataReader["Departments.Name"].ToString();

        Console.WriteLine("Вiдсилання працiвникiв i вiддiлiв до клiєнту: " + szName + " -> " +
             szCom_name + "\n");
      }
      Cdb.myOleDbConnection.Close();
      return buffer1 + "`" + key;

    }
    private static string Connect2DB_MainForm_Activated_Wor(CConnectDB Cdb)
    {
      string szName = "";
      string szCom_name = "";
      string buffer2 = "";
      string buffer3 = "";
      string key = "|";
      string dot = ".";

      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT Departments.Name, Members.Name FROM Members, Departments WHERE Members.id_dep = Departments.id");
      while (Cdb.myOleDbDataReader.Read())
      {
        szName = Cdb.myOleDbDataReader["Members.Name"].ToString();
        szCom_name = Cdb.myOleDbDataReader["Departments.Name"].ToString();
        buffer2 = buffer2 + key + szName;
        buffer3 = buffer3 + key + szCom_name;
        key = key + dot;
      }
      Cdb.myOleDbConnection.Close();
      return buffer2 + key + "^" + buffer3 + "`" + key;
    }
    private static string Connect2DB_IdDep_Select(CConnectDB Cdb, string message)
    {
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT id FROM Departments WHERE Name = '" + message + "'");
      Cdb.myOleDbDataReader.Read();
      iId = Cdb.myOleDbDataReader["id"].ToString();
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("Вибрано для зв''язки iдентифiкатор №" + iId);
      return iId;
    }
    private static string Connect2DB_Department_Select(CConnectDB Cdb, string message)
    {
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT Name, Description FROM Departments WHERE Name = '" + message + "'");
      Cdb.myOleDbDataReader.Read();
      string txtName = Cdb.myOleDbDataReader["Name"].ToString();
      string txtDescription = Cdb.myOleDbDataReader["Description"].ToString();
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("Вибрано з БД: " + txtName + ", " + txtDescription);
      return txtName + "\n" + txtDescription;
    }
    private static string Connect2DB_Worker_Select(CConnectDB Cdb, string message)
    {
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT Name,Surname,Middle_name, Age FROM Members WHERE Name = '" + message + "'");
      Cdb.myOleDbDataReader.Read();
      txtName = Cdb.myOleDbDataReader["Name"].ToString();
      string txtPosition = Cdb.myOleDbDataReader["Surname"].ToString();
      txtSalary = Cdb.myOleDbDataReader["Middle_name"].ToString();
      string txtYear = Cdb.myOleDbDataReader["Age"].ToString();
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("Вибрано з БД: " + txtName + ", " + txtPosition + ", " + txtSalary + ", " + txtYear);
      return txtName + "|" + txtPosition + "|." + txtSalary + "|.." + txtYear;
    }
    private static void Connect2DB_Delete_Worker(CConnectDB Cdb, string message)
    {
      Cdb.myOleDbConnection.Open();
      Cdb.Query("DELETE FROM Members WHERE Name='" + message + "'");
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("Робiтник " + message + " успiшно ВИДАЛЕНИЙ");
    }
    private static void Connect2DB_Delete_Department(CConnectDB Cdb, string message)
    {
      Cdb.myOleDbConnection.Open();
      Cdb.Query("DELETE FROM Members WHERE id_dep=" + iId.ToString());
      Cdb.myOleDbConnection.Close();
      Cdb.myOleDbConnection.Open();
      Cdb.Query("DELETE FROM Departments WHERE Name='" + message + "'");
      Cdb.myOleDbConnection.Close();
      Console.WriteLine(message + " i всi його робiтники успiшно ВИДАЛЕНI");
    }
    private static string Connect2DB_Accure_Salary(CConnectDB Cdb, string message)
    {
      Cdb.myOleDbConnection.Open();
      int newSalary = Int32.Parse(txtSalary) + Int32.Parse(message);
      Cdb.Query("UPDATE Members SET Middle_name = " + newSalary + " WHERE Name='" + txtName + "'");
      Cdb.myOleDbConnection.Close();
      Console.WriteLine("Працiвнику  " + txtName + " Нараховану суму " + message + "\n Залишок: " + newSalary);
      return Connect2DB_Worker_Select(Cdb, txtName);
    }
    private static string Connect2DB_Autorize_login(CConnectDB Cdb)
    {
      string buffer1 = "";
      string key = "|";
      string dot = ".";
      int i = 1;
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT login FROM Autorization");
      while (Cdb.myOleDbDataReader.Read())
      {
        string login = Cdb.myOleDbDataReader["login"].ToString();
        buffer1 = buffer1 + key + login;
        key = key + dot;
        Console.WriteLine("Вибрано логiн  " + login + " №" + i);
        i++;
      }
      Cdb.myOleDbConnection.Close();

      return buffer1 + "`" + key;
    }
    private static string Connect2DB_Autorize_pass(CConnectDB Cdb)
    {
      string buffer1 = "";
      string key = "|";
      string dot = ".";
      int i = 1;
      Cdb.myOleDbConnection.Open();
      Cdb.Query("SELECT password FROM Autorization");
      while (Cdb.myOleDbDataReader.Read())
      {
        string password = Cdb.myOleDbDataReader["password"].ToString();
        buffer1 = buffer1 + key + password;
        key = key + dot;
        Console.WriteLine("Вибрано пароль " + password + " прив'язка до №" + i);
        i++;
      }
      Cdb.myOleDbConnection.Close();

      return buffer1 + "`" + key;
    }

    public static string GetLocalIPAddress()
    {
      var host = Dns.GetHostEntry(Dns.GetHostName());
      foreach (var ip in host.AddressList)
      {
        if (ip.AddressFamily == AddressFamily.InterNetwork)
        {
          return ip.ToString();
        }
      }
      throw new Exception("Local IP Address Not Found!");
    }
   
   
    static void Main(string[] args)
    {
      // Підключаємось до бази даних

      connecDB = new CConnectDB("provider=Microsoft.Jet.OLEDB.4.0;data source= Dbase.mdb");


      // Отримуємо локальну айпі адресу
      string ip_local = GetLocalIPAddress();     
      IPAddress ipAddr = IPAddress.Parse(ip_local);

      IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, 11000);

      // Створюємо сокет Tcp/Ip
      Socket sListener = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      // Назначаємо сокет локальної кінцевої точки і виконуємо прослушку вхідних сокетів 
      try
      {
        sListener.Bind(ipEndPoint);
        sListener.Listen(100);

        // Починаємо прослушку
        while (true)
        {
          Console.WriteLine("------------------------------------------");
          Console.WriteLine("Очiкуєм пiдключення через порт {0}", ipEndPoint);

          // ППрограма призупиняється, режим очікування
          Socket handler = sListener.Accept();
          string data = null;
          // Коли дочекались клієнта
          Console.Write(" Пiдключено \n");
          byte[] bytes = new byte[1024];
          int bytesRec = handler.Receive(bytes);

          data += Encoding.UTF8.GetString(bytes, 0, bytesRec);

          Console.Write("Отримана команда " + data + "\n\n");
          // ділимо отримане повідомлення за допомогою ключів
          int startIndex = data.IndexOf("\n") + 1;
          int nextIndex = data.IndexOf("\n|") + 2;
          int nextnextIndex = data.IndexOf("\n||") + 3;
          int nextnextnextIndex = data.IndexOf("\n|||") + 4;


          int endIndex = data.LastIndexOf("\n");
          int CommandIndex = data.IndexOf("->") + 2;
          // парсинг команди
          string Command = data.Substring(CommandIndex, startIndex - 1 - CommandIndex);
          // стрічки для відправки повідомлень
          string reply1 = "reply1";
          string reply2 = "reply2";
           
          try {
        command_items = (Commands)Enum.Parse(typeof(Commands), Command.Split(' ')[0]);
              }
          catch {
         command_items = Commands.Unknown; // якщо команда не зпарсилася, то вона невідома
               }
         
          switch (command_items) // парсинг за командою даних
          {
            case Commands.AddDepartment:
              {
                string DepartName = data.Substring(startIndex, endIndex - startIndex);
                string DepartDescr = data.Substring(endIndex + 1);
                Connect2DB_Depart(connecDB, DepartName, DepartDescr);
                break;
              }
            case Commands.AddWorker:
              {
                string WorkerName = data.Substring(startIndex, nextIndex - startIndex - 2);
                string WorkerDescr = data.Substring(nextIndex, nextnextIndex - nextIndex - 3);
                string WorkerSalary = data.Substring(nextnextIndex, nextnextnextIndex - nextnextIndex - 4);
                string WorkerYear = data.Substring(endIndex + 4);
                Connect2DB_Worker(connecDB, WorkerName, WorkerDescr, WorkerSalary, WorkerYear);
                break;
              }
            case Commands.MainFormLoad:
              {
                reply1 = Connect2DB_MainForm_Activated_Dep(connecDB);
                reply2 = Connect2DB_MainForm_Activated_Wor(connecDB);
                break;
              }
            case Commands.ItemSelected:
              {
                string SelectedItem = data.Substring(startIndex); // наш вибраний відділ/робітник

                if (SelectedItem.Contains("Вiддiл")) // якщо стрічка починається на "відділ"
                {
                  Connect2DB_IdDep_Select(connecDB, SelectedItem);
                  reply1 = Connect2DB_Department_Select(connecDB, SelectedItem);
                }
                else if (SelectedItem == "Департаменти") // якщо це корінь
                  break;
                else // якщо це робітник
                  reply2 = Connect2DB_Worker_Select(connecDB, SelectedItem);
                break;
              }
            case Commands.DeleteWorker:
              {
                string SelectedItem = data.Substring(startIndex); // вибраний робітник
                Connect2DB_Delete_Worker(connecDB, SelectedItem);
                reply1 = "OK";
                break;
              }
            case Commands.DeleteDepartment:
              {
                string SelectedItem = data.Substring(startIndex); // вибраний відділ
                Connect2DB_Delete_Department(connecDB, SelectedItem);
                reply1 = "OK";
                break;
              }
            case Commands.AccureSalary:
              {
                string AccuredSalary = data.Substring(startIndex);
                reply2 = Connect2DB_Accure_Salary(connecDB, AccuredSalary);
                break;
              }
            case Commands.Autorization:
              {
                reply1 = Connect2DB_Autorize_login(connecDB);
                reply2 = Connect2DB_Autorize_pass(connecDB);
                break;
              }
            case Commands.Unknown: // якщо команда невідома
             {
              Console.WriteLine("Передана команда " + Command + " не опрацьовується!");            
              break;
             }
              default: // щось пішло не так, просто обновляємо список
                break;
          }

          // Завжди відправляємо 2 повідомлення. Якщо одна з стрічок не використовується,
          // то по замовчуванню відішлеться "reply1" або "reply2"
          byte[] msg1 = Encoding.Unicode.GetBytes(reply1);
          byte[] msg2 = Encoding.Unicode.GetBytes(reply2);

          handler.Send(msg1);
          handler.Send(msg2);
          //якщо клієнт завершив з"єднання
          switch (command_items)
          {
            case Commands.ExitClient:
              {
                Console.WriteLine("Клiєнт закрив форму. З'єднання завершене");
                handler.Shutdown(SocketShutdown.Both); // роз'єднуємо
                handler.Close();
                break;
              }
            default: // щось пішло не так, просто обновляємо список
              break;
          }
        } // end of while
      }
      catch (Exception ex)
      {
        Console.WriteLine(ex.ToString());
      }
      finally
      {
        Console.ReadLine();
      }
    }
  }
}