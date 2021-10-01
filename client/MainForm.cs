
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
// клас для відображення дерева відділів і працівників, нарахування зар.плати
  public partial class MainForm : Form
  {
    
    public MainForm()
    {
      InitializeComponent();
      this.Refresh();
    }
    public static CDepartment department = new CDepartment();                
    public static CWorker worker = new CWorker();                      
    public static SyncronousSocket socket = new SyncronousSocket();
    public static bool bFlag;                                           //flag from add new Department
    public static bool bFlagDp;                                         //flag from add new Worker                             
    TreeNode tvRoot = new TreeNode("Департаменти");                    //Root of tree
    
    public void Load_List_Parse(string recieved1, string recieved2)
    {
      string key = "|";
      string dot = ".";
      int lastKey_Dep = recieved1.IndexOf("`"); // Відрізаємо ключ від повідомлення
      int lastKey_Wor = recieved2.IndexOf("`");

      int endKey_Dep = recieved1.Length - lastKey_Dep - 1; // розмір ключа
      int endKey_Wor = recieved2.Length - lastKey_Wor - 1;
      int[] indexes_Depart = new int[endKey_Dep]; // масив для пустих відділів
      int[] indexes_Dep = new int[endKey_Wor]; // для відділів з робітниками
      int[] indexes_Wor = new int[endKey_Wor]; // // для робітників з відділами
      TreeNode tvDepart;
      string DepName = "";
      string WorName = "";

      string rem_ec_msg_dep = recieved1.Replace("`", ""); // забираємо ключик, необхідний для визначення кінця основного ключа
      string rem_rec_msg_wor = recieved2.Replace("`", "");


      string Workers = rem_rec_msg_wor.Split('^')[0]; // ділимо повдідомлення на 2 частини
      string Departments = rem_rec_msg_wor.Split('^')[1];


    int i = 0;
    int k = 1;
      for (string j = key; j.Length != (endKey_Wor + 1); j = j + dot) // рахуємо розміри стрічок для відділів з робітниками
      {
        indexes_Dep[i] = Departments.IndexOf(j) + k;
        indexes_Wor[i] = Workers.IndexOf(j) + k;
        
        i++;  
        k++;
      }

    i = 0;
    k = 1;
      for (string j = key; j.Length != (endKey_Dep + 1); j = j + dot) // рахуємо розміри стрічок для пустих відділів
      {
        indexes_Depart[i++] = rem_ec_msg_dep.IndexOf(j) + k++;
      }

      int v = 1;
      int r = 2;
      for (int j = 0; j < endKey_Dep - 1 ; j++) // додаємо відділи БЕЗ робітників до списку
      {
        tvDepart = new TreeNode();
        DepName = rem_ec_msg_dep.Substring(indexes_Depart[j], indexes_Depart[v] - indexes_Depart[j] - r);
        tvRoot.Nodes.Add(DepName);
        v++;
        r++;
      }
      v = 1;
      r = 2;
      for (int j = 0; j < endKey_Wor - 1; j++) //  додаємо відділи  робітниками до списку
      {
        // виловлюємо робітників і відділів за допомогою знайдених довжин ключів
        DepName = Departments.Substring(indexes_Dep[j], indexes_Dep[v] - indexes_Dep[j] - r);
        WorName = Workers.Substring(indexes_Wor[j], indexes_Wor[v] - indexes_Wor[j] - r);
        v++;
        r++;
       for (int a = 0; a < tvRoot.Nodes.Count; a++) // додаємо робітника до відділу
        {
        if (tvRoot.Nodes[a].Text.IndexOf(DepName) != -1) // при співпадінні відділів(коли декілька робітників належать одному відідлу)
        {
          TreeNode node = tvRoot.Nodes[a];
          node.Nodes.Add(WorName); // додаємо вузол
          break;
        }
        }
      }
    }
    private void MainForm_Load(object sender, EventArgs e)
    {
   
      try
      {
      socket.Connection_Show("->MainFormLoad" + "\n");
      Department_list_view.Nodes.Add(tvRoot); // додаємо корінь
     // Парсимо команди за допомогою ключів
      Load_List_Parse(SyncronousSocket.rec_msg_dep, SyncronousSocket.rec_msg_wor);
      }
      catch
      {
        MessageBox.Show("Помилка передачі даних з серверу");
        this.Close();
      }
      Department_list_view.ExpandAll(); //  розкриваємо дерево
    }
    private void btnAddWorker_Click(object sender, EventArgs e)
    {
      try
      {
        if (Department_list_view.SelectedNode.Text.IndexOf("Вiддiл") != -1) // якщо вибраний відділ
        {
          NewWorker new_wor = new NewWorker();
          new_wor.ShowDialog();
        }
        else
        {
          MessageBox.Show("Виберіть відділ");
        }
      }
      catch
      {
        MessageBox.Show("Створіть або виберіть відділ");
      }
    }
    private void btnAddDepartment_Click(object sender, EventArgs e)
    {
      NewDepartment new_dep = new NewDepartment();
      new_dep.ShowDialog();
    }
    private void MainForm_Activated(object sender, EventArgs e)
    {
      // флажки для додавання робітника/відділу до дерева. Активуються в класі
      if (bFlag) 
      {
        department.Add_DP_to_Tree(tvRoot);
        bFlag = false;
      }

      if (bFlagDp)
      {
        TreeNode newTreeNode = Department_list_view.SelectedNode;
        worker.Add_Wor_to_Tree(newTreeNode);
        bFlagDp = false;
      }
    }
    private void Item_AfterSelect(object sender, TreeViewEventArgs e)
    {
      socket.Connection_Show("->ItemSelected" + "\n" + Department_list_view.SelectedNode.Text);

   if (Department_list_view.SelectedNode.Text.IndexOf("Вiддiл") != -1) // якщо це відділ
      {
      btnAddWorker.Enabled =true;
      btnRemoveDepartment.Enabled = true;
      btnRemoveWorker.Enabled = false;
      }
   else
      {
      btnAddWorker.Enabled = false;
      btnRemoveDepartment.Enabled = false;
      btnRemoveWorker.Enabled = true;
      }

      if (Department_list_view.SelectedNode.Text.IndexOf("Вiддiл") != -1)
      {
        groupBox1.Text = Department_list_view.SelectedNode.Text;
        label1.Visible = true;
        label1.Text = "Назва: ";
        txtName.Visible = true;
        label2.Visible = true;
        label2.Text = "Діяльність: ";
        txtPosition.Visible = true;
        txtPosition.Multiline = true;
        txtPosition.Height = 100;
        txtSalary.Visible = false;
        accure_salary.Visible = false;
        txtYear.Visible = false;
        label3.Visible = false;
        label4.Visible = false;
        button_accure_salary.Visible = false;
        // парсимо відділ
        try { 
        int startIndex = SyncronousSocket.rec_msg_dep.IndexOf("\n");
        int endIndex = SyncronousSocket.rec_msg_dep.LastIndexOf("\n");

        txtName.Text = SyncronousSocket.rec_msg_dep.Substring(0, startIndex);
        txtPosition.Text = SyncronousSocket.rec_msg_dep.Substring(endIndex + 1);
        }
        catch
        {
          MessageBox.Show("Неправильно передана команда вибірки!");
          txtName.Text = "--------";
         txtPosition.Text = "--------";
        }      
      }
      else
      {
        if (Department_list_view.SelectedNode.Text != "Департаменти") // якщо це робітник
        {
          groupBox1.Text = "Працівник";
          txtName.Visible = true;
          txtPosition.Visible = true;
          txtSalary.Visible = true;
          accure_salary.Visible = true;
          txtYear.Visible = true;
          label1.Visible = true;
          label2.Visible = true;
          label3.Visible = true;
          label4.Visible = true;
     
          txtPosition.Multiline = false;
          label1.Text = "ПІБ";
          label2.Text = "Посада";
          label3.Text = "Зарплата";
          button_accure_salary.Visible = true;
          button_accure_salary.Enabled = true;
          // парсимо робітника
    try{
          int startIndex = SyncronousSocket.rec_msg_wor.IndexOf("|") + 1;
          int nextIndex = SyncronousSocket.rec_msg_wor.IndexOf("|.") + 2;
          int nextnextIndex = SyncronousSocket.rec_msg_wor.IndexOf("|..") + 3;

          txtName.Text = SyncronousSocket.rec_msg_wor.Substring(0, startIndex - 1);
          txtPosition.Text = SyncronousSocket.rec_msg_wor.Substring(startIndex, nextIndex - startIndex - 2);
          txtSalary.Text = SyncronousSocket.rec_msg_wor.Substring(nextIndex, nextnextIndex - nextIndex - 3);
          txtYear.Text = SyncronousSocket.rec_msg_wor.Substring(nextnextIndex);
        }       
    catch // якщо не отримали дані з серверу
        {
          MessageBox.Show("Неправильно передана команда вибірки!");
          txtName.Text = "--------";
          txtPosition.Text = "--------";
          txtSalary.Text = "--------";
          txtYear.Text = "--------";
        }  
        }
      }
    }
    private void btnRemoveWorker_Click(object sender, EventArgs e)
    {
      DialogResult res = new DialogResult();
      res = MessageBox.Show("Ви впевнені?",
                                       "Видалити робітника " + txtName.Text,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);
      if (res == DialogResult.Yes)
      { 
     
      if (Department_list_view.SelectedNode.Text.IndexOf("Вiддiл") == -1
          && Department_list_view.SelectedNode.Text != "Департаменти")
      {
         socket.Connection_Show("->DeleteWorker"+ "\n" + Department_list_view.SelectedNode.Text);
     if (SyncronousSocket.rec_msg_dep == "OK") 
        {
        TreeNode node = Department_list_view.SelectedNode;
        node.Remove();
        }
     
      else
        {
          MessageBox.Show("Помилка при видаленні робітника");
        }
      }
      }
      else
      { return; }
    }
    private void btnRemoveDepartment_Click(object sender, EventArgs e)
    {
 DialogResult res = new DialogResult();
      res = MessageBox.Show("Ви впевнені?",
                                       "Видалити " + txtName.Text,
                                       MessageBoxButtons.YesNo,
                                       MessageBoxIcon.Question);
      if (res == DialogResult.Yes)
      { 
      if (Department_list_view.SelectedNode.Text.IndexOf("Вiддiл") != -1)
      { 
        socket.Connection_Show("->DeleteDepartment" + "\n" + Department_list_view.SelectedNode.Text);
        if (SyncronousSocket.rec_msg_dep == "OK") 
        {
        TreeNode node = Department_list_view.SelectedNode;
        node.Remove();
        }
        else
        {
          MessageBox.Show("Помилка при видаленні відділу");
        }
      }
}
else
return;
    }
    private void button_accure_salary_Click(object sender, EventArgs e)
    {
      try 
      { 
      if (Int32.Parse(accure_salary.Text) <= 0)
      {
        MessageBox.Show("Ви нарахували від'ємне число!");
        accure_salary.Text = "0";
      }
      socket.Connection_Show("->AccureSalary" + "\n" + accure_salary.Text.ToString());
      int nextIndex = SyncronousSocket.rec_msg_wor.IndexOf("|.") + 2;
      int nextnextIndex = SyncronousSocket.rec_msg_wor.IndexOf("|..") + 3;
      txtSalary.Text = SyncronousSocket.rec_msg_wor.Substring(nextIndex, nextnextIndex - nextIndex - 3);
 
      accure_salary.Text = "";
     }
      catch // якщо ввели не цифру
      {
        MessageBox.Show("Невірний формат вводу або неправильна команда!");
      }
    }  
    private void button1_Click(object sender, EventArgs e)
    {
      foreach (TreeNode node in Department_list_view.Nodes)
      {
        node.Nodes.Clear();
      }
      Department_list_view.Nodes.Remove(tvRoot);
      MainForm_Load(sender, e);
    }
    private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
    {
      socket.Connection_Show("->ExitClient \n");
    }
  }
}
