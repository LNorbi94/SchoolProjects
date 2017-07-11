using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1
{
    public partial class iskstat : Form
    {
        struct Record
        {
            public int azonos;
            public int osztaly;
            public int hianyzas;
            public string osztalysz;
            public string nev;
        }
        Record[] v = new Record[250];
        Record[] a = new Record[250];
        Record[] b = new Record[250];
        Record[] c = new Record[250];
        int n, db, dbb, dbc;

        public iskstat()
        {
            InitializeComponent();
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void feltoltes(ref Record[] v, ref int n)
        {
            n = 0;
            StreamReader f = File.OpenText("iskolas.txt");
            while (!f.EndOfStream && n<=250)
            {
                    v[n].azonos = int.Parse(f.ReadLine());
                    v[n].nev = f.ReadLine();
                    string[] darabol = f.ReadLine().Split(' ');
                    v[n].osztaly = int.Parse(darabol[0]);
                    v[n].osztalysz = darabol[1];
                    v[n].hianyzas = int.Parse(darabol[2]);
                    n++;
            }
        }

        private void megjelenites(ref Record[] v, int n, ref DataGridView dg_alap)
        {
            dg_alap.ColumnCount = 5;
            dg_alap.RowCount = n;
            dg_alap.RowHeadersWidth = 50;
            dg_alap.Columns[0].HeaderCell.Value = "Azonosító";
            dg_alap.Columns[1].HeaderCell.Value = "Név";
            dg_alap.Columns[2].HeaderCell.Value = "Évfolyam";
            dg_alap.Columns[3].HeaderCell.Value = "Osztály";
            dg_alap.Columns[4].HeaderCell.Value = "Hiányzás";
            dg_alap.TopLeftHeaderCell.Value = "Sorszám";
            for (int i = 0; i < 5; i++)
            {
                dg_alap.Columns[i].Width = 55;
                
            }
            for (int i = 0; i < n; i++)
            {
                dg_alap.Rows[i].HeaderCell.Value = (i + 1) + ".";
                dg_alap.Rows[i].Cells[0].Value = v[i].azonos;
                dg_alap.Rows[i].Cells[1].Value = v[i].nev;
                dg_alap.Rows[i].Cells[2].Value = v[i].osztaly;
                dg_alap.Rows[i].Cells[3].Value = v[i].osztalysz;
                dg_alap.Rows[i].Cells[4].Value = v[i].hianyzas;
            }
        }

        private void feltolt_Click(object sender, EventArgs e)
        {
            feltoltes(ref v, ref n);
            megjelenites(ref v, n, ref dg_alap);
        }

        private void hianyzas(ref Record[] v, int n, ref int db, ref int dbb)
        {
            db = 0;
            dbb = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].hianyzas > 29)
                {
                    a[db] = v[i];
                    db++;
                }
                else
                {
                    b[dbb] = v[i];
                    dbb++;
                }
            }
        }

        private void hianyzasok_Click(object sender, EventArgs e)
        {
            hianyzas(ref v, n, ref db, ref dbb);
            megjelenites(ref a, db, ref dg_h1);
            megjelenites(ref b, dbb, ref dg_h2);
        }

        private void adotto(ref Record[] v, int n, ref int dbc)
        {
            dbc = 0;
            for (int i = 0; i < n; i++)
            {
                if ((v[i].osztaly == int.Parse(a1.Text)) && (v[i].osztalysz == a2.Text))
                {
                    c[dbc] = v[i];
                    dbc++;
                }  
            }
        }

        private void adott_Click(object sender, EventArgs e)
        {
            adotto(ref v, n, ref dbc);
            megjelenites(ref c, dbc, ref dg_adott);
        }

        private void osztalyiras_Click(object sender, EventArgs e)
        {
            StreamWriter f = File.CreateText("osztaly_" + a1.Text + a2.Text + ".txt");
            foreach(Record i in c) {
               f.WriteLine(i.azonos);
               f.WriteLine(i.nev);
               f.WriteLine(i.osztaly);
            }
            f.Close();
        }
    }
}
