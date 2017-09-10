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

namespace lestar_sqlaccess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection dataConnection = new OleDbConnection(@"Provider=Microsoft.JET.OLEDB.4.0;Data Source=F:\mintaadatbázis.mdb");
            dataConnection.Open();
            OleDbCommand dataCommand = dataConnection.CreateCommand();
            dataCommand.CommandText = "SELECT Tulaj_neve, Típus FROM Autók";
            IDataReader dr = dataCommand.ExecuteReader();
            while (dr.Read())
            {
                be.Items.Add("Tulaj neve: " + dr["Tulaj_neve"] + ", Típusa: " + dr["Típus"]);
            }
            dataConnection.Close();
        }
    }
}
