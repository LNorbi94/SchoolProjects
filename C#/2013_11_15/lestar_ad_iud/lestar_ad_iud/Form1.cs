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

namespace lestar_ad_iud
{
    public partial class abiud : Form
    {
        public abiud()
        {
            InitializeComponent();
        }

        string constring;
        OleDbConnection dbc;
        OleDbCommand com;
        string path;
        int ind;
        DataTable dbt;

        private void button3_Click(object sender, EventArgs e)
        {
            OleDbCommand oDc = dbc.CreateCommand();
            oDc.CommandText = "UPDATE " + lBtabla.SelectedItem + " " + frissTB.Text;
            int sor = oDc.ExecuteNonQuery();
            MessageBox.Show(sor.ToString() + " sort töröltem");
        }

        private void csat_Click(object sender, EventArgs e)
        {
            panel.Visible = true;
            torolTB.Text = "WHERE ";
            frissTB.Text = "SET " + System.Environment.NewLine + "WHERE ";
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                path = f.FileName;
            }
            constring = "Provider=Microsoft.Jet.OleDB.4.0;data source=" + path;
            dbc = new OleDbConnection(constring);
            dbc.Open();
            DataTable tables = dbc.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow row in tables.Rows)
            {
                
                lBtabla.Items.Add(row[2].ToString());
            }
        }

        private void lBtabla_SelectedIndexChanged(object sender, EventArgs e)
        {
            lBmezo.Items.Clear();
            lBertek.Items.Clear();
            dbt = dbc.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, lBtabla.SelectedItem, null });
            foreach (DataRow mezonevek in dbt.Rows)
            {
                lBmezo.Items.Add(mezonevek["COLUMN_NAME"]);
                lBertek.Items.Add("NULL");
            }
        }

        private void lBtabla_DoubleClick(object sender, EventArgs e)
        {
        }

        private void lBmezo_Click(object sender, EventArgs e)
        {
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void lBmezo_SelectedIndexChanged(object sender, EventArgs e)
        {
            ind = lBmezo.SelectedIndex;
            string input = Microsoft.VisualBasic.Interaction.InputBox("Add meg az új értéket:", "Beszúrás", "", -1, -1);
            lBertek.Items[ind] = input;
        }

        private void beszur_Click(object sender, EventArgs e)
        {
            string mezok = "(";
            foreach (var item in lBmezo.Items)
            {
                mezok += item + ",";
            }
            mezok = mezok.Substring(0, mezok.Length - 1);
            mezok += ")";
            string ertekek = "(";
            string param = "";
            int p = 0;
            string[] parameterek = new string[20];
            foreach (var item in lBertek.Items)
            {
                ertekek += item + ", ";
                parameterek[p] = "@p" + p.ToString();
                p++;
                param += "@p" + p.ToString() + ",";
            }
            ertekek = ertekek.Substring(0, ertekek.Length - 2);
            ertekek += ")";
            param = param.Substring(0, param.Length - 1);
            com = dbc.CreateCommand();
            com.CommandText = "INSERT INTO " + lBtabla.SelectedItem + "" + mezok + " VALUES (" + param + ")";
            for (int i = 0; i < lBertek.Items.Count; i++)
            {
                com.Parameters.AddWithValue(parameterek[i], lBertek.Items[i]);
            }

            int sor = com.ExecuteNonQuery();
            MessageBox.Show(sor.ToString() + " sort szúrtam be");
        }

        private void torol_Click(object sender, EventArgs e)
        {
            OleDbCommand oDc = dbc.CreateCommand();
            oDc.CommandText = "DELETE FROM " + lBtabla.SelectedItem + " " + torolTB.Text;
            try
            {
                int sor = oDc.ExecuteNonQuery();
                MessageBox.Show(sor.ToString() + " sort töröltem");
            }
            catch (Exception h)
            {
                MessageBox.Show("0 sort töröltem, mert "+h);
            }
        }

        private void abiud_FormClosed(object sender, FormClosedEventArgs e)
        {
            dbc.Close();
        }
    }
}
