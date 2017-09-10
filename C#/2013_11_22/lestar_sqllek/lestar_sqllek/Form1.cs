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
            StreamReader fi = File.OpenText("lek.txt");
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
            OleDbCommand oDc = dbc.CreateCommand();
            oDc.CommandText = tomb[int.Parse(tBhany.Text)];
            try
            {
                int sor = oDc.ExecuteNonQuery();    
                MessageBox.Show("A lekérdezés sikeres volt. " + sor.ToString() + " sor változott.");
            }
            catch (Exception hiba)
            {
                MessageBox.Show("0 sor változtattam, mert"+System.Environment.NewLine + hiba);
            }
            
        }
    }
}
