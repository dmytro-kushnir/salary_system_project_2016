using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace IPZ_Salary_System_NEW
{

    public class CWorker: CDepartment
    {
        private string PIB;
        private int age;
        private int salary;
        private string position;
        /// <summary>
        /// ///// Methods
        /// </summary>
        public string Worker_PIB
        {
          get { return PIB; }
          set { PIB = value; }
        }

        public int Worker_Age
        {
          get { return age; }
          set { age = value; }
        }

        public int Worker_Salary
        {
          get { return salary; }
          set { salary = value; }
        }

        public string Worker_Position
        {
          get { return position; }
          set { position = value; }
        }

        public void Add_Wor_to_Tree(TreeNode node)
        {
            node.Nodes.Add(Worker_PIB);
            node.ExpandAll();
        }
    }
}
