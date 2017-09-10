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

namespace lestar_listadolg
{
    public partial class lestar_listadolg : Form
    {
        public lestar_listadolg()
        {
            InitializeComponent();
        }

        struct Lstr
        {
            public string nev;
            public int ervenyes;
            public int ervenytelen;
            public int osszes;
        }
        Lstr versenyzok;
        List<Lstr> Lista = new List<Lstr>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                bt_ervenytelen.Enabled = true;
                bt_feltolt.Enabled = false;
                bt_legalabb.Enabled = true;
                bt_legm.Enabled = true;
                bt_osszes.Enabled = true;
                bt_sort.Enabled = true;
                bt_legtobb.Enabled = true;
                bt_voltetobb.Enabled = true;
                StreamReader f = File.OpenText("alkoto.txt");
                while (!f.EndOfStream)
                {
                    versenyzok.nev = f.ReadLine();
                    string szavazat = f.ReadLine();
                    string[] szavazatok = szavazat.Split(' ');
                    versenyzok.ervenytelen = int.Parse(szavazatok[0]);
                    versenyzok.ervenyes = int.Parse(szavazatok[1]);
                    versenyzok.osszes = int.Parse(szavazatok[0]) + int.Parse(szavazatok[1]);
                    Lista.Add(versenyzok);
                }
                foreach (Lstr elem in Lista)
                {
                    be.Items.Add(elem.nev+" (Összes szavazat: "+elem.osszes+", érvényes: "+elem.ervenyes+", érvénytelen: "+elem.ervenytelen+")");
                }
            }
            catch (Exception h)
            {
                MessageBox.Show("Hiba történt!"+System.Environment.NewLine+h);
            }
        }

        private void bt_osszes_Click(object sender, EventArgs e)
        {
            int osszes = Lista.Sum(x => x.ervenyes);
            ki.Items.Add("Az érvényes szavazatok száma: "+osszes);
        }

        private void bt_ervenytelen_Click(object sender, EventArgs e)
        {
            double atlag = Lista.Average(x => x.ervenytelen);
            ki.Items.Add("Az érvénytelen szavazatok átlaga: "+atlag);
        }

        private void bt_legtobb_Click(object sender, EventArgs e)
        {
            int max = Lista.Max(x => x.ervenyes);
            int maxind = Lista.FindIndex(x => x.ervenyes.Equals(max));
            ki.Items.Add("A legtöbb érvényes szavazatot kapta: " + Lista[maxind].nev);
            ki.Items.Add("Érvényes szavazatok száma: " + max);
            ki.Items.Add("Érvénytelen szavazatok száma: " + Lista[maxind].ervenytelen);
        }

        private void bt_voltetobb_Click(object sender, EventArgs e)
        {
            bool volt = Lista.Any(x => x.ervenytelen > 10);
            if (volt == false)
            {
                ki.Items.Add("Nem volt 10-nél több érvénytelen");
            }
            else
            {
                int tiz = Lista.FindIndex(x => x.ervenytelen > 10);
                ki.Items.Add("Volt, mégpedig "+Lista[tiz].nev);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Lstr[] nincs = Lista.Where(x => x.ervenytelen == 0).ToArray();
            int max = nincs.Max(x => x.ervenyes);
            int maxind = Lista.FindIndex(x => x.ervenyes.Equals(max));
            ki.Items.Add(Lista[maxind].nev);
        }

        private void bt_sort_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            IEnumerable<Lstr> rendezett = Lista.AsQueryable().OrderByDescending(x => x.ervenyes);
            foreach (Lstr elem in rendezett)
            {
                ki.Items.Add(elem.nev + " ("+elem.ervenyes+" szavazat)");
            }
        }

        private void bt_legalabb_Click(object sender, EventArgs e)
        {
            Array.ForEach(Lista.Where(x => x.ervenyes > 50).ToArray(), x => ki.Items.Add(x.nev + " (" + x.ervenyes + " szavazat)"));
        }
    }
}