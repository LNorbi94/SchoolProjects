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

namespace lestar_list
{
    public partial class osztalyzatok : Form
    {
        struct tomb
        {
            public string nev;
            public int[] osztalyzatok;
            public double atlag;
        }
        List<tomb> lista = new List<tomb>();
        tomb tanulok;
        int n, m;
        double ossz_atlag;
        Boolean hanyag;
        double legjobb;
        string legjobb_id;
        List<string> jelesek = new List<string>();
        List<string> peldasak = new List<string>();

        public osztalyzatok()
        {
            InitializeComponent();
        }

        private void bt_mehet_Click(object sender, EventArgs e)
        {
            hanyag = false;
            ossz_atlag = 0;
            bt_mehet.Enabled = false;
            bt_atl.Enabled = true;
            bt_hanyag.Enabled = true;
            bt_jeles.Enabled = true;
            bt_legjobb.Enabled = true;
            bt_peldas.Enabled = true;
            try 
	        {
                n = 0;
                StreamReader f = File.OpenText("osztaly.txt");
                f.ReadLine();
                while (!f.EndOfStream)
                {
                    double osszeg = 0;
                    int j = 0;
                    string s = f.ReadLine();
                    string[] k = s.Split(' ');
                    tanulok.nev = k[0]+" "+k[1];
                    tanulok.osztalyzatok = new int[k.Count()-2];
                    for (int i = 2; i < k.Count(); i++)
                    {
                        if (tanulok.osztalyzatok[1] == 2) { hanyag = true; }
                        tanulok.osztalyzatok[j] = int.Parse(k[i]);
                        osszeg += double.Parse(k[i]);
                        j++;
                    }
                    tanulok.atlag = osszeg / (k.Count() - 2);
                    lista.Add(tanulok);
                    n++;
                }
                foreach (tomb elem in lista)
                {
                    string str = elem.nev + "\t"; ;
                    for (int i = 0; i < elem.osztalyzatok.Count(); i++)
                    {
                        str += elem.osztalyzatok[i] + " ";
                    }
                    if (elem.osztalyzatok[0] == 5 && elem.osztalyzatok[1] == 5) { peldasak.Add(elem.nev); }
                    str += "\t" + elem.atlag;
                    if (elem.atlag > legjobb) { legjobb = elem.atlag; legjobb_id = elem.nev; }
                    if (elem.atlag >= 4.5) { jelesek.Add(elem.nev); m++;  }
                    ossz_atlag += elem.atlag;
                    be.Items.Add(str);
                }
	        }
	        catch (Exception hiba)
	        {
                MessageBox.Show("Hiba:" + System.Environment.NewLine + hiba);
	        }
        }

        private void bt_hanyag_Click(object sender, EventArgs e)
        {
            bt_hanyag.Enabled = false;
            if (hanyag == true)
            {
                ki.Items.Add(" ");
                ki.Items.Add("Volt hanyag szorgalmú diák. :(");
            }
            else
            {
                ki.Items.Add(" ");
                ki.Items.Add("Nem volt hanyag szorgalmú diák! :)");
            }
        }

        private void bt_atl_Click(object sender, EventArgs e)
        {
            bt_atl.Enabled = false;
            ki.Items.Add(" ");
            ki.Items.Add("Az osztály átlaga: "+(ossz_atlag/n));
        }

        private void bt_legjobb_Click(object sender, EventArgs e)
        {
            bt_legjobb.Enabled = false;
            ki.Items.Add(" ");
            ki.Items.Add("Legjobb tanuló: " + legjobb_id);
        }

        private void bt_jeles_Click(object sender, EventArgs e)
        {
            bt_jeles.Enabled = false;
            ki.Items.Add(" ");
            ki.Items.Add("Jeles tanulók:");
            foreach (var item in jelesek)
            {
                ki.Items.Add(item);
            }
        }

        private void bt_peldas_Click(object sender, EventArgs e)
        {
            bt_peldas.Enabled = false;
            ki.Items.Add(" ");
            ki.Items.Add("Példás tanulók:");
            foreach (var item in peldasak)
            {
                ki.Items.Add(item);
            }
        }
    }
}