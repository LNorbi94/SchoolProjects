using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApplication1
{
    public partial class access : Form
    {
        public access()
        {
            InitializeComponent();
        }

        string file;

        private void button1_Click(object sender, EventArgs e)
        {
            tablak.Visible = true;
            OpenFileDialog of = new OpenFileDialog();
            DialogResult result = of.ShowDialog();
            if (result == DialogResult.OK)
            {
                file = of.FileName;
                OleDbConnection dataConnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source="+file);
                DataTable userTables = null;
                string[] restrictions = new string[4];
                restrictions[3] = "Table";
                dataConnection.Open();
                userTables = dataConnection.GetSchema("Tables", restrictions);
                for (int i = 0; i < userTables.Rows.Count; i++)
                {
                    tablak.Items.Add(userTables.Rows[i][2].ToString());
                }
                dataConnection.Close();
            }
        }

        private void tablak_SelectedValueChanged(object sender, EventArgs e)
        {
            mezok.Visible = true;
            mezok.Items.Clear();
            OleDbConnection dataConnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=" + file);
            dataConnection.Open();
            var cmd = new OleDbCommand("Select * from "+tablak.SelectedItem, dataConnection);
            var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly);
            var table = reader.GetSchemaTable();
            var nameCol = table.Columns["ColumnName"];
            foreach (DataRow row in table.Rows)
            {
                mezok.Items.Add(row[nameCol]);
            }
            dataConnection.Close();
        }

        private void mezok_SelectedValueChanged(object sender, EventArgs e)
        {
            be.Visible = true;
            be.Items.Clear();
            OleDbConnection dataConnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source="+file);
            dataConnection.Open();
            OleDbCommand dataCommand = dataConnection.CreateCommand();
            string cmd = "";
            for (int i = 0; i < mezok.SelectedItems.Count; i++)
            {
                if (i+1==mezok.SelectedItems.Count)
                {
                    cmd += mezok.SelectedItems[i];
                }
                else { cmd += mezok.SelectedItems[i] + ", "; }
                
            }
            dataCommand.CommandText = "SELECT "+cmd+" FROM "+tablak.SelectedItem;
            IDataReader dr = dataCommand.ExecuteReader();
            while (dr.Read())
            {
                string ize = "";
                for (int i = 0; i < mezok.SelectedItems.Count; i++)
                {
                    if (i + 1 == mezok.SelectedItems.Count)
                    {
                        ize += mezok.SelectedItems[i] + ": " + dr.GetValue(i);
                    }
                    else
                    {
                        ize += mezok.SelectedItems[i] + ": " + dr.GetValue(i) + ", ";
                    }
                }
                be.Items.Add(ize);
            }
            dataConnection.Close();
        }
    }
}