using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace _P__PWLister
{
  public partial class Form1 : Form
  {
    private int _i;

    public Form1()
    {
      InitializeComponent();
      dataGridView1.Size = new Size(800, 600);
      dataGridView1.ColumnCount = 8;
      dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
      dataGridView1.Columns[0].Name = "ID";
      dataGridView1.Columns[1].Name = "Place";
      dataGridView1.Columns[2].Name = "Username";
      dataGridView1.Columns[3].Name = "E-mail";
      dataGridView1.Columns[4].Name = "Pin";
      dataGridView1.Columns[5].Name = "Comment";
      dataGridView1.Columns[6].Name = "Web address";
      dataGridView1.Columns[7].Name = "Password";

      using (StreamReader f = new StreamReader("data"))
      {
        while (!f.EndOfStream)
        {
          string line = f.ReadLine();
          string[] data = line ? .Split('\t');
          dataGridView1.Rows.Add(data);
        }
      }

      /*object[] row = { "1", "Aion [nexus]", "raphx", "darhemenator@gmail.com", "123456", "Probably never using ever again.", "https://en.aion.gameforge.com/website/", "idk" };
      dataGridView1.Rows.Add(row);
      row = new object[] { "2", "Product 2", "2000" };
      dataGridView1.Rows.Add(row);
      row = new object[] { "3", "Product 3", "3000" };
      dataGridView1.Rows.Add(row);
      row = new object[] { "4", "Product 4", "4000" };
      dataGridView1.Rows.Add(row);
      int a = 5;
      _i = a;
      /*
       *       DataGridViewLinkColumn lnk = new DataGridViewLinkColumn();
            dataGridView1.Columns.Add(lnk);
            lnk.HeaderText = "Link Data";
            lnk.Name = "Http://csharp.net-informations.com";
            lnk.Text = "Http://csharp.net-informations.com";
            lnk.UseColumnTextForLinkValue = true;
       
      OleDbConnection MyConnection;
      DataSet DtSet = new DataSet();
      OleDbDataAdapter MyCommand;
      MyConnection = new System.Data.OleDb.OleDbConnection(@"provider=Microsoft.Jet.OLEDB.4.0;Data Source='d:\downloads\a.xls';Extended Properties=Excel 8.0;");
      MyCommand = new System.Data.OleDb.OleDbDataAdapter("SELECT * FROM [Sheet1$]", MyConnection);
      MyCommand.TableMappings.Add("Table", "Net-informations.com");
      try
      {
        MyCommand.Fill(DtSet);

        dataGridView1.DataSource = DtSet.Tables[0];
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
      MyConnection.Close(); */
    }

    private void Form1_SizeChanged(object sender, EventArgs e)
    {
      dataGridView1.Size = new Size(Width, Height);
    }

    private void ReadFile()
    {
      
    }

    private void SaveDoc()
    {
      using (StreamWriter f = new StreamWriter("data"))
      {
        for (int i = 0; i < dataGridView1.RowCount - 1; ++i)
        {
          for (int j = 0; j < dataGridView1.ColumnCount; ++j)
          {
            f.Write(dataGridView1[j, i].Value);
            f.Write(j + 1 < dataGridView1.ColumnCount ? "\t" : "\n");
          }
        }
      }
    }

    private void Form1_KeyDown(object sender, KeyEventArgs e)
    {
      if (e.Modifiers == Keys.Control && e.KeyCode == Keys.S)
      {
        SaveDoc();
      }
    }
  }
}
