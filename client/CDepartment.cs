using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;

namespace IPZ_Salary_System_NEW
{
    public class CDepartment : SyncronousSocket
    {
        //////////Fields
        private string DP_Name;
        private string DP_description;

        //////////Methods
        public string Department_Name
        {
          get { return DP_Name; }
          set { DP_Name = value; }
        }

        public string Department_Description
        {
          get { return DP_description; }
          set { DP_description = value; }
        }
        public void Add_DP_to_Tree(TreeNode node)
        {
          TreeNode tvComitet = new TreeNode(Department_Name);
          node.Nodes.Add(tvComitet);
          node.ExpandAll();
        }
    }
}
