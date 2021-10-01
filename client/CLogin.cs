using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace IPZ_Salary_System_NEW
{
  partial class CLogin : CWorker
  {
   private string username;
   private string password;
   
  public string Login_UserName
  {
    get {return username;}
    set {username = value;}
  }
   public string Login_Password
   {
     get {return password;}
     set {password = value;} 
   } 
  }
}
