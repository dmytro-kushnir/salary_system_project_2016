using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
namespace IPZ_Salary_System_NEW
{
  public class SyncronousSocket 
  {
    public static string rec_msg_dep; // отримані дані з серверу
    public static string rec_msg_wor; // отримані дані з серверу
    protected internal static IPAddress ipAddr;
    protected internal static byte[] bytes = new byte[1024]; // массив для передавання отрмування даних
    protected internal static int port = 11000 ;

    public IPAddress local_IP
    {
      get { return ipAddr; }
      set { ipAddr = value; }
    }
    public void Connection_Show(string message)
    {
      try   
      { 
      IPEndPoint ipEndPoint = new IPEndPoint(ipAddr, port);
      
      Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

      sender.Connect(ipEndPoint);

      byte[] msg = Encoding.UTF8.GetBytes(message);

      int bytesSent = sender.Send(msg);


      int bytesRec = sender.Receive(bytes);

      SyncronousSocket.rec_msg_dep = Encoding.Unicode.GetString(bytes, 0, bytesRec);

      int bytesRec2 = sender.Receive(bytes);

      SyncronousSocket.rec_msg_wor = Encoding.Unicode.GetString(bytes, 0, bytesRec2);

      sender.Shutdown(SocketShutdown.Both);
      sender.Close();
      }
      catch
      {
        MessageBox.Show("З'єднання з сервером відсутнє.");
      }
    } 
  }
}
