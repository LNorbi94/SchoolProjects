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

namespace Horgaszverseny
{
    public partial class horgaszverseny : Form
    {
        struct Rekord
        {
            public string nev;
            public int halak_szama;
            public int halak_kg;
            public double ido;
        }

        const int maxn = 100;
        Rekord[] v = new Rekord[maxn];
        public int n;

        public horgaszverseny()
        {
            InitializeComponent();
        }

        private void feltolt_Click(object sender, EventArgs e)
        {
            n = 0;
            StreamReader f = File.OpenText("adatok.txt");
            if (File.Exists("adatok.txt"))
            {
                while (!f.EndOfStream)
                {
                    v[n].nev = f.ReadLine();
                    string sor = f.ReadLine();
                    string[] text = new string[200];
                    text = sor.Split(' ');
                    v[n].halak_szama = int.Parse(text[0]);
                    v[n].halak_kg = int.Parse(text[1]);
                    v[n].ido = double.Parse(text[2]);
                    n++;
                }
            }
            for (int i = 0; i < n; i++)
            {
                be.Items.Add(v[i].nev+" - Fogott halak száma: "+v[i].halak_szama+", Összes KG: "+v[i].halak_kg+", Összes idő: "+v[i].ido);
            }
        }

        private void legtobb_Click(object sender, EventArgs e)
        {
            int legtobb = 0;
            for (int i = 0; i < n; i++)
            {
                if (v[i].halak_kg > v[legtobb].halak_kg)
                {
                    legtobb = i;
                }
            }
            be.Items.Add("");
            be.Items.Add("Legtöbb halat KG-ban fogó ember neve: "+v[legtobb].nev);
        }

        private void atlag_Click(object sender, EventArgs e)
        {
            double osszes = 0;
            for (int i = 0; i < n; i++)
            {
                osszes += v[i].ido;
            }
            double atlag = osszes / n;
            
            be.Items.Add("");
            be.Items.Add("Átlagos versenyben töltött idő: " + atlag+", Kerekítve: "+ Math.Round(atlag, 2));
        }
    }
}
