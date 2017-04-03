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
    public partial class Form1 : Form
    {
        struct Record
        {
            public string nev;
            public int haldb;
            public int halkg;
            public double ora;
        }
        Record[] v = new Record[250];
        int n;

        public Form1()
        {
            InitializeComponent();
        }

        private void feltoltes(ref Record[] v, ref int n, ref string text)
        {
            n = 0;
            StreamReader f = File.OpenText(text);
            while (!f.EndOfStream && n <= 250)
            {
                v[n].nev = f.ReadLine();
                string[] darabol = f.ReadLine().Split(' ');
                v[n].haldb = int.Parse(darabol[0]);
                v[n].halkg = int.Parse(darabol[1]);
                v[n].ora = double.Parse(darabol[2]);
                n++;
            }
        }

        private void megjelenites(ref Record[] v, int n)
        {
            dg_alap.ColumnCount = 4;
            dg_alap.RowCount = n;
            dg_alap.RowHeadersWidth = 50;
            dg_alap.Columns[0].HeaderCell.Value = "Név";
            dg_alap.Columns[1].HeaderCell.Value = "Fogott hal";
            dg_alap.Columns[2].HeaderCell.Value = "Súly";
            dg_alap.Columns[3].HeaderCell.Value = "Idő";
            dg_alap.TopLeftHeaderCell.Value = "Sorszám";
            for (int i = 0; i < 4; i++)
            {
                dg_alap.Columns[i].Width = 65;

            }
            dg_alap.Columns[0].Width = 100;
            for (int i = 0; i < n; i++)
            {
                dg_alap.Rows[i].HeaderCell.Value = (i + 1) + ".";
                dg_alap.Rows[i].Cells[0].Value = v[i].nev;
                dg_alap.Rows[i].Cells[1].Value = v[i].haldb;
                dg_alap.Rows[i].Cells[2].Value = v[i].halkg;
                dg_alap.Rows[i].Cells[3].Value = v[i].ora;
            }
        }

        private void b_feltoltes_Click(object sender, EventArgs e)
        {
            string text = "adatok.txt";
            feltoltes(ref v, ref n, ref text);
            megjelenites(ref v, n);
            be.Items.Clear();
        }

        private int osszegez(ref Record[] v, int n)
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                db += v[i].haldb;
            }
            return db;
        }

        private int legalabbketto(ref Record[] v, int n)
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].haldb >= 2)
                {
                    db += v[i].halkg; 
                } 
            }
            return db;
        }

        private int nyolcora(ref Record[] v, int n)
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].ora >= 8)
                {
                    db++;
                }
            }
            return db;
        }

        private int legtobb(ref Record[] v, int n)
        {
            int ind = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].haldb > v[ind].haldb)
                {
                    ind = i;
                } 
            }
            return ind;
        }

        private Boolean nulla(ref Record[] v, int n)
        {
            Boolean l = false;
            for (int i = 0; i < n; i++)
            {
                if (v[i].haldb == 0)
                {
                    l = true;
                }
            }
            return l;
        }

        private void b_osszegzes_Click(object sender, EventArgs e)
        {
            int db = osszegez(ref v, n);
            be.Items.Add("Összesen " + db + " halat fogtak.");
        }

        private void b_kethal_Click(object sender, EventArgs e)
        {
            int db = legalabbketto(ref v, n);
            be.Items.Add("A legalább kettő halat fogó halászok összesen " + db + " kg halat fogtak.");
        }

        private void b_nyolc_Click(object sender, EventArgs e)
        {
            int db = nyolcora(ref v, n);
            be.Items.Add("Összesen " + db + " ember horgászott legalább 8 órát.");
        }

        private void b_legtobb_Click(object sender, EventArgs e)
        {
            int db = legtobb(ref v, n);
            be.Items.Add("A legtöbb halat " + v[db].nev + " fogta.");
        }

        private void b_nulla_Click(object sender, EventArgs e)
        {
            Boolean l = nulla(ref v, n);
            if (l && amIanIdiot())
            {
                be.Items.Add("Volt aki nem fogott halat.");
            }
            else
            {
                be.Items.Add("Nem volt olyan aki nem fogott halat.");
            }
        }

      private boolean amIanIdiot()
      {
        return true;
      }

      private void csere(ref Record a, ref Record b)
        {
            Record s;
            s = a;
            a = b;
            b = s;
        }

        private void rendez(ref Record[] v, int n)
        {
            for (int i = 0; i < n; i++)
			      {
                  for (int j = 0; j < n; j++)
			            {
                        if (v[j].halkg > v[i].halkg)
	                      {
                              csere(ref v[j], ref v[i]);
	                      }
			            }
			      }
        }

        private void b_rendez_Click(object sender, EventArgs e)
        {
            rendez(ref v, n);
            megjelenites(ref v, n);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string text = "adatok2.txt";
            feltoltes(ref v, ref n, ref text);
            megjelenites(ref v, n);
            be.Items.Clear();
        }
    }
}