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

namespace lestar_majuserettsegi
{
    public partial class valasztasok : Form
    {
        struct Rekord
        {
            public int kerulet;
            public int szavazat;
            public string nev;
            public string part;
        }
        List<Rekord> Lista = new List<Rekord>();
        double szavazat = 12345;
        double szavazott;

        public valasztasok()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                StreamReader f = File.OpenText("szavazatok.txt");
                while (!f.EndOfStream)
                {
                    string[] szoveg = f.ReadLine().Split(' ');
                    Rekord adat;
                    adat.kerulet = int.Parse(szoveg[0]);
                    adat.szavazat = int.Parse(szoveg[1]);
                    adat.nev = szoveg[2]+" "+szoveg[3];
                    adat.part = szoveg[4];
                    Lista.Add(adat);
                }
                Array.ForEach(Lista.ToArray(), x => be.Items.Add("Választókerület: " + x.kerulet + "\t Szavazatok száma: " + x.szavazat+"\t Párt neve: "+x.part+"\t Jelölt neve: " + x.nev));
                feltolt.Enabled = false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Hiba történt!"+System.Environment.NewLine+error);
            }
        }

        private void elso_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            be.Items.Add("2. feladat");
            be.Items.Add("A helyhatósági választáson "+Lista.Count+" képviselő jelölt indult.");
        }

        private void masodik_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            be.Items.Add("3. feladat");
            Rekord adat = Lista.Find(x => x.nev == tB.Text);
            if (Lista.Any(x => x.nev == tB.Text))
            {
                be.Items.Add("A(z) "+adat.nev+" nevű képviselőnek összesen "+adat.szavazat+" számú szavazata volt.");
            }
            else
            {
                be.Items.Add("Ilyen nevű képviselő jelölt nem szerepel a nyilvántartásban!");
            }
        }

        private void harmadik_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            szavazott = Lista.Sum(x => x.szavazat);
            double arany = (szavazott / szavazat)*100;
            be.Items.Add("4. feladat");
            be.Items.Add("A választáson "+szavazott+" állampolgár, a jogosultak "+arany.ToString("F2")+" százaléka vett részt.");
        }

        private void negyedik_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            szavazott = Lista.Sum(x => x.szavazat);
            be.Items.Add("5. feladat");
            double GYEP = Lista.Where(x => (x.part == "GYEP")).Sum(x => x.szavazat);
            double HEP = Lista.Where(x => x.part == "HEP").Sum(x => x.szavazat);
            double TISZ = Lista.Where(x => x.part == "TISZ").Sum(x => x.szavazat);
            double ZEP = Lista.Where(x => x.part == "ZEP").Sum(x => x.szavazat);
            double fuggetlen = Lista.Where(x => x.part == "-").Sum(x => x.szavazat);
            double arany1 = (GYEP / szavazott) * 100;
            double arany2 = (HEP / szavazott) * 100;
            double arany3 = (TISZ / szavazott) * 100;
            double arany4 = (ZEP / szavazott) * 100;
            double arany5 = (fuggetlen / szavazott) * 100;
            be.Items.Add("Gyümölcsevők pártja = " + arany1.ToString("F2") + "%");
            be.Items.Add("Húsevők pártja = " + arany2.ToString("F2") + "%");
            be.Items.Add("Tejivók szövetsége = " + arany3.ToString("F2") + "%");
            be.Items.Add("Zöldségevők pártja = " + arany4.ToString("F2") + "%");
            be.Items.Add("Független jelöltek = " + arany5.ToString("F2") + "%");
        }

        private void otodik_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            be.Items.Add("6. feladat");
            int max = Lista.Max(x => x.szavazat);
            Array.ForEach(Lista.Where(x => x.szavazat == max).ToArray(), x => be.Items.Add(x.nev+"\t"+x.part));
        }

        private void hatodik_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            be.Items.Add("7. feladat");
            for (int i = 0; i < 8; i++)
            {
                int max = Lista.Where(x => x.kerulet == (i+1)).Max(x => x.szavazat);
                Rekord adat = Lista.Find(x => x.szavazat == max);
                be.Items.Add("Választókerület: " + adat.kerulet + "\t Párt rövidítése: " + adat.part + "\t Képviselő neve: " + adat.nev);
            }
        }
    }
}
