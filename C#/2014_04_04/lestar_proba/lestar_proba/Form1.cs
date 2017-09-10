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

namespace lestar_proba
{
    public partial class lestar_nevnap : Form
    {
        struct nevn
        {
            public int honap;
            public int nap;
        }

        struct Rekord
        {
            public string nev;
            public List<nevn> fonevnap;
            public List<nevn> nevnapok;
            public int db;
        }

        List<Rekord>lista = new List<Rekord>();

        public lestar_nevnap()
        {
            InitializeComponent();
        }

        private void bt_feltoltes_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader f = File.OpenText("nevnapok.txt");
                while (!f.EndOfStream)
                {
                    int db = 0;
                    Rekord adat = new Rekord();
                    adat.fonevnap = new List<nevn>();
                    adat.nevnapok = new List<nevn>();
                    string[] tomb = f.ReadLine().Split(' ');
                    adat.nev = tomb[0];
                    for (int i = 1; i < tomb.Count(); i++)
                    {
                        if (tomb[i].EndsWith("*") || tomb.Count() < 2)
                        {
                            nevn nevnapokr = new nevn();
                            string[] tombi = tomb[i].Split('.');
                            nevnapokr.honap = int.Parse(tombi[0]);
                            nevnapokr.nap = int.Parse(tombi[1].TrimEnd('*'));
                            adat.fonevnap.Add(nevnapokr);
                            db++;
                        }
                        else
                        {
                            nevn nevnapokr = new nevn();
                            string[] tombk = tomb[i].Split('.');
                            nevnapokr.honap = int.Parse(tombk[0]);
                            nevnapokr.nap = int.Parse(tombk[1].TrimEnd('*'));
                            adat.nevnapok.Add(nevnapokr);
                            db++;
                        }
                    }
                    adat.db = db;
                    lista.Add(adat);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Hiba történt!" + System.Environment.NewLine+error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            int db = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (lista[i].nev.EndsWith("a"))
                {
                    listBox1.Items.Add(lista[i].nev);
                    db++;
                }
            }
            listBox1.Items.Add("Számuk: " + db);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (lista.Any(x => x.nev == tb.Text))
            {
                Rekord adat = lista.Find(x => x.nev == tb.Text);
                listBox1.Items.Add(adat.nev);
                string nevnapok = "";
                Array.ForEach(adat.nevnapok.ToArray(), x => nevnapok += x.honap + "." + x.nap+" ");
                if (nevnapok != "") { listBox1.Items.Add(nevnapok); }
                string fonevnapok = "";
                Array.ForEach(adat.fonevnap.ToArray(), x => fonevnapok += x.honap + "." + x.nap+" ");
                if (fonevnapok != "") { listBox1.Items.Add("Főnévnap(ok): " + fonevnapok); }
            }
            else
            {
                MessageBox.Show("Ilyen név nincs.");
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int hnap = 0;
            int np = int.Parse(nap.Text);
            switch (honap.Text)
            {
                case "január": hnap = 1; break;
                case "február": hnap = 2; break;
                case "március": hnap = 3; break;
                case "április": hnap = 4; break;
                case "május": hnap = 5; break;
                case "június": hnap = 6; break;
                case "július": hnap = 7; break;
                case "augusztus": hnap = 8; break;
                case "szeptember": hnap = 9; break;
                case "október": hnap = 10; break;
                case "november": hnap = 11; break;
                case "december": hnap = 12; break;
                default: ; break;
            }
            for (int i = 0; i < lista.Count(); i++)
            {
                for (int j = 0; j < lista[i].fonevnap.Count(); j++)
                {
                    if (lista[i].fonevnap[j].nap == np && lista[i].fonevnap[j].honap == hnap)
                    {
                        listBox1.Items.Add("Van ilyen névnap, mégpedig: " + lista[i].nev);
                    }
                }
                for (int k = 0; k < lista[i].nevnapok.Count(); k++)
                {
                    if (lista[i].nevnapok[k].nap == np && lista[i].nevnapok[k].honap == hnap)
                    {
                        listBox1.Items.Add("Van ilyen névnap, mégpedig: " + lista[i].nev);
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Rekord adat = lista.Find(x => x.db == lista.Max(y => y.db));
            listBox1.Items.Add(adat.nev + " rendelkezik a legtöbb névnappal.");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            for (int m = 0; m < lista.Count(); m++)
			{
                for (int i = 1; i < 13; i++)
                {
                    if (lista[m].nevnapok.Any(x => x.honap == i) || lista[m].fonevnap.Any(x => x.honap == i))
                    {
                        for (int j = 1; j < 32; j++)
                        {
                            if (lista[m].nevnapok.Any(x => x.nap == j) || lista[m].fonevnap.Any(x => x.nap == j))
                            {
                                for (int l = 0; l < lista[m].nevnapok.Count(); l++)
                                {
                                    if (lista[m].nevnapok[l].honap == i && lista[m].nevnapok[l].nap == j)
                                    {
                                        listBox1.Items.Add(i + "." + j);
                                        listBox1.Items.Add(lista[m].nev);
                                    }
                                } 
                                for (int o = 0; o < lista[m].fonevnap.Count(); o++)
                                {
                                    if (lista[m].fonevnap[o].honap == i && lista[m].fonevnap[o].nap == j)
                                    {
                                        listBox1.Items.Add(lista[m].nev);
                                    }
                                }
                            }
                        }  
                    }
                }
			}
        }
    }
}
