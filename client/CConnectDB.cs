using System;
using System.Collections.Generic;
using System.Text;
using System.Data.OleDb;

namespace IPZ_Salary_System_NEW
{

    public class CConnectDB
    {
        public  OleDbConnection myOleDbConnection = new OleDbConnection();
        private  OleDbCommand myOleDbCommand;
        public  OleDbDataReader myOleDbDataReader;
        string m_szConnectStr;

        public CConnectDB(string cs)
        {
            m_szConnectStr = cs;
            myOleDbConnection.ConnectionString = m_szConnectStr;
            myOleDbCommand = myOleDbConnection.CreateCommand();
        }

        public void Query(string queryStr)
        {
            myOleDbCommand.CommandText = queryStr;
            myOleDbDataReader = myOleDbCommand.ExecuteReader();
        }
    }
}
