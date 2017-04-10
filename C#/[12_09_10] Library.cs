using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        struct Record
        {
            public string cim;
            public int ar;
            public int db;
        }
        int n;
        int n1;
        int osszes;
        const int maxn = 100;
        new Record[] v = new Record[maxn];
        new Record[] b = new Record[maxn];

        public Form1()
        {
            InitializeComponent();
        }

        private void feltoltes(ref Record[] v, ref int n)
        {
            StreamReader f = File.OpenText("konyvek.txt");
            while (!f.EndOfStream && n <= maxn)
            {
                string[] darabol = f.ReadLine().Split(new char[] { ' ' }, 3);
                v[n].ar = int.Parse(darabol[0]);
                v[n].db = int.Parse(darabol[1]);
                v[n].cim = darabol[2];
                n++;
            }
        }

        private void megjelenites(ref Record[] v, int n, ref DataGridView dg_tanulok)
        {
            dg_tanulok.RowCount = n;
            dg_tanulok.ColumnCount = 3;
            dg_tanulok.Columns[0].Width = 200;
            dg_tanulok.Columns[1].Width = 100;
            dg_tanulok.Columns[2].Width = 100;
            for (int i = 0; i < 3; i++)
            {
                dg_tanulok.Columns[0].HeaderText = "Cím";
                dg_tanulok.Columns[1].HeaderText = "Ár (Ft)";
                dg_tanulok.Columns[2].HeaderText = "Raktáron (db)";
            }
            dg_tanulok.RowHeadersWidth = 105;
            for (int i = 0; i < n; i++)
            {
                dg_tanulok.Rows[i].HeaderCell.Value = (i + 1) + ". könyv";
            }
            for (int i = 0; i < n; i++)
            {
                dg_tanulok.Rows[i].Cells[0].Value = v[i].cim;
                dg_tanulok.Rows[i].Cells[1].Value = v[i].ar;
                dg_tanulok.Rows[i].Cells[2].Value = v[i].db;
            }
        }

        private void osszegzes(ref Record[] v, int n, ref int osszes)
        {
            osszes = 0;
            for (int i = 0; i < n; i++)
            {
                osszes += v[i].ar * v[i].db;
            }

        }

        private bool kifogyott1(ref Record[] v, int n)
        {
            bool l = false;
            for (int i = 0; i < n; i++)
            {
                if (v[i].db == 0)
	            {
                    l = true;
	            }
            }
            return l;
        }

        private int adotalatt(ref Record[] v, int n)
        {
            int db = 0;
            int adott = int.Parse(adott_ar.Text);
            for (int i = 0; i < n; i++)
            {
                if (v[i].ar < adott)
                {
                    db++;
                }
            }
            return db;
        }

        private void adotfelett(ref Record[] v, int n, ref Record[] b, ref int n1)
        {
            int adott = int.Parse(adott_ar.Text);
            for (int i = 0; i < n; i++)
            {
                if (v[i].ar > adott)
                {
                    b[n1].ar = v[i].ar;
                    b[n1].cim = v[i].cim;
                    b[n1].db = v[i].db;
                    n1++;
                }
            }
        }

        private int legdragabb1(ref Record[] v, int n)
        {
            int sor = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].ar > v[sor].ar)
                {
                    sor = i;
                }
            }
            return sor;
        }

        private void csere(ref Record a, ref Record b)
        {
            Record s;
            s = a;
            a = b;
            b = s;
        }

        private void rendez1(ref Record[] v, int n)
        {
            for (int i = 0; i < n-1; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (v[j].cim.CompareTo(v[i].cim) < 0)
                    {
                        csere(ref v[j], ref v[i]);
                    }
                }
            }

        }


        private void feltolt_Click(object sender, EventArgs e)
        {
            feltoltes(ref v, ref n);
            megjelenites(ref v, n, ref dg_1);
        }

        private void ossz_Click(object sender, EventArgs e)
        {
            osszegzes(ref v, n, ref osszes);
            ki.Text = "A raktárkészlet összértéke: "+ osszes.ToString();
        }

        private void kifogy_Click(object sender, EventArgs e)
        {
            if (kifogyott1(ref v, n) == true)
            {
                ki.Text = "Van olyan könyv, ami kifogyott.";
            }
            else
	        {
                ki.Text = "Nincs egy könyv se ami kifogyott volna.";
	        }
        }

        private void aralatt_Click(object sender, EventArgs e)
        {
            ki.Text = adotalatt(ref v, n) + "-féle könyv kapható " + adott_ar.Text + "Ft alatt.";
        }

        private void ar_felett_Click(object sender, EventArgs e)
        {
            adotfelett(ref v, n, ref b, ref n1);
            megjelenites(ref b, n1, ref dg_2);
        }

        private void legdragabb_Click(object sender, EventArgs e)
        {
            ki.Text = "A legdrágább könyv ára: " + v[legdragabb1(ref v, n)].ar + " Ft. Sorszáma: " + (legdragabb1(ref v, n)+1);
        }

        private void rendez_Click(object sender, EventArgs e)
        {
            rendez1(ref v, n);
            megjelenites(ref v, n, ref dg_1);
            keres.Enabled = true;
        }
        
    }
}
