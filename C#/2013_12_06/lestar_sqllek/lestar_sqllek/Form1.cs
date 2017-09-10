using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;

namespace lestar_sqllek
{
    public partial class sqllek : Form
    {
        string[] tomb = new string[20];
        int n;
        string constring;
        OleDbConnection dbc;
        string path;

        public sqllek()
        {
            InitializeComponent();
        }

        private void mehet_Click(object sender, EventArgs e)
        {
            StreamReader fi = File.OpenText("lek1.txt");
            while (!fi.EndOfStream)
            {
                tomb[n] = fi.ReadLine();
                n++;
            }
            fi.Close();
            OpenFileDialog f = new OpenFileDialog();
            if (f.ShowDialog() == DialogResult.OK)
            {
                path = f.FileName;
            }
            constring = "Provider=Microsoft.Jet.OleDB.4.0;data source=" + path;
            dbc = new OleDbConnection(constring);
            dbc.Open();
            
            for (int i = 0; i < n; i++)
            {
                lek.Items.Add(tomb[i]);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            OleDbCommand myOleDbCommand = dbc.CreateCommand();
            myOleDbCommand.CommandText = tomb[lek.SelectedIndex];
            try
            {
                OleDbDataReader sdr = myOleDbCommand.ExecuteReader();
                while (sdr.Read())
                {
                    string sor = "";
                    for (int j = 0; j < sdr.FieldCount; j++)
                    {
                        sor += sdr[j] + "; ";
                    }
                    be.Items.Add(sor);
                }
                sdr.Close();
            }
            catch (Exception h)
            {
                MessageBox.Show("A lekérdezés nem futott le, a következő miatt: \n" + h.Message);
            }
        }
    }
}
