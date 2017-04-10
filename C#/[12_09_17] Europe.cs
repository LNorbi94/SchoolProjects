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
    public partial class europa : Form
    {
        struct Record
        {
            public string nev;
            public int terulet;
        }
        int n;
        const int maxn = 100;
        new Record[] v = new Record[maxn];

        public europa()
        {
            InitializeComponent();
        }

        private void feltoltes(ref Record[] v, ref int n)
        {
            string fajl = ffnev.Text;
            StreamReader f = File.OpenText(fajl);
            while (!f.EndOfStream && n <= maxn)
            {
                v[n].nev = f.ReadLine();
                v[n].terulet = int.Parse(f.ReadLine());
                n++;
            }

        }

        private void megjelenites(ref Record[] v, int n)
        {
            lista1.Items.Add("Országnév:                      Területe");
            lista1.Items.Add("                   négyzetkilóméterben:");
            for (int i = 0; i < n; i++)
            {
                lista1.Items.Add(v[i].nev + "       ( " + v[i].terulet+" )");
            }
        }

        private double atlag(ref Record[] v, int n)
        {
            double atlag = 0;
            double osszeg = 0;
            for (int i = 0; i < n; i++)
            {
                osszeg += v[i].terulet;
            }
            atlag = osszeg / n;
            return atlag;
        }

        private int szazenagy(ref Record[] v, int n)
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].terulet > 100000)
                {
                    db++;
                }
            }
            return db;
        }

        private int maximszaz(ref Record[] v, int n)
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].terulet <= 100000)
                {
                    db++;
                }
            }
            return db;
        }

        private int min(ref Record[] v, int n)
        {
            int min = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].terulet < v[min].terulet)
                {
                    min = i;
                }
            }
            return min;
        }

        private int max(ref Record[] v, int n)
        {
            int max = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].terulet > v[max].terulet)
                {
                    max = i;
                }
            }
            return max;
        }

        private int keres1(ref Record[] v, int n)
        {
            int talal = 0;
            for (int i = 0; i < n; i++)
			{
                if (v[i].nev == orszag.Text)
	            {
                    talal = i;
	            }
			}
            return talal;
        }

        private void betolt_Click(object sender, EventArgs e)
        {
            feltoltes(ref v, ref n);
            megjelenites(ref v, n);
            teruletatl.Enabled = true;
            megszamol.Enabled = true;
            minmaxkiv.Enabled = true;
            keres.Enabled = true;
        }

        private void teruletatl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("A területek átlaga: " + atlag(ref v, n) + " négyzetkilóméter");
        }

        private void megszamol_Click(object sender, EventArgs e)
        {
            if (tobbmintszaz.Checked == true)
            {
                MessageBox.Show("A 100.000-nél nagyobb területű országok száma: "+szazenagy(ref v, n));
            }
            else
            {
                MessageBox.Show("A legfeljebb 100.000 területű országok száma: " + maximszaz(ref v, n));
            }
        }

        private void minmaxkiv_Click(object sender, EventArgs e)
        {
            if (minvmax.Text == "Minimum")
            {
                MessageBox.Show(v[min(ref v, n)].nev + ", területe: " + v[min(ref v, n)].terulet);
            }
            else
            {
                MessageBox.Show(v[max(ref v, n)].nev + ", területe: " + v[max(ref v, n)].terulet);
            }
        }

        private void keres_Click(object sender, EventArgs e)
        {
            int kereses = keres1(ref v, n);
            if (kereses > 0)
            {
                MessageBox.Show(v[kereses].nev + " területe: " + v[kereses].terulet);
            }
            else
            {
                MessageBox.Show("Nincs ilyen ország.");
            }
        }
    }
}
