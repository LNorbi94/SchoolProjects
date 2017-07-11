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

namespace lestar_lift
{
    public partial class frm_lift : Form
    {
        int szint = 0;
        int maxszint = 0;
        int csapatok = 0;
        int igenyek = 0;
        int random = 0;
        struct Rekord
        {
            public int ora;
            public int perc;
            public int masodperc;
            public int sorszam;
            public int start;
            public int cel;
        }
        List<Rekord> lista = new List<Rekord>();

        public frm_lift()
        {
            InitializeComponent();
        }

        private void bt_feltolt_Click(object sender, EventArgs e)
        {
            try
            {
                bt_szint.Enabled = true;
                bt_utolso.Enabled = true;
                bt_mm.Enabled = true;
                bt_fel.Enabled = true;
                bt_nemhasznalt.Enabled = true;
                bt_vetett.Enabled = true;
                bt_random.Enabled = true;
                StreamReader f = File.OpenText("igeny.txt");
                maxszint = int.Parse(f.ReadLine());
                csapatok = int.Parse(f.ReadLine());
                igenyek = int.Parse(f.ReadLine());
                while (!f.EndOfStream)
                {
                    Rekord adat;
                    string[] tomb = f.ReadLine().Split(' ');
                    adat.ora = int.Parse(tomb[0]);
                    adat.perc = int.Parse(tomb[1]);
                    adat.masodperc = int.Parse(tomb[2]);
                    adat.sorszam = int.Parse(tomb[3]);
                    adat.start = int.Parse(tomb[4]);
                    adat.cel = int.Parse(tomb[5]);
                    lista.Add(adat);
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Hiba történt!" + System.Environment.NewLine + error);
            }
        }

        private void bt_szint_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(tb_szint.Text) <= maxszint)
                {
                    szint = int.Parse(tb_szint.Text);
                    MessageBox.Show("A beolvasás megtörtént!");
                    bt_szint.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Nincs ilyen szint!");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Hiba történt!" + System.Environment.NewLine + error);
            }
        }

        private void bt_utolso_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            Rekord adat = lista.Last();
            be.Items.Add("3. feladat");
            be.Items.Add("=================================");
            be.Items.Add("");
            be.Items.Add("A lift a(z) "+adat.cel+". szinten áll az utolsó igény teljesítése után.");
        }

        private void bt_mm_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            int max, min = 0;
            if (lista.Max(x => x.cel) > lista.Max(x => x.start))
            {
                max = lista.Max(x => x.cel);
            }
            else
            {
                max = lista.Max(x => x.start);
            }
            if (lista.Min(x => x.cel) < lista.Min(x => x.start))
            {
                min = lista.Min(x => x.cel);
            }
            else
            {
                min = lista.Min(x => x.start);
            }
            Rekord adat = lista.Last();
            be.Items.Add("4. feladat");
            be.Items.Add("=================================");
            be.Items.Add("");
            be.Items.Add("A legalacsonyabb érintett emelet a megfigyelés során: " + min + ". emelet.");
            be.Items.Add("A legmagasabb érintett emelet a megfigyelés során: " + max + ". emelet.");
        }

        private void bt_fel_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            int fel = 0;
            int felunelkul = 0;
            for (int i = 0; i < lista.Count(); i++)
            {
                if (1 <= i && lista[i].start > lista[i - 1].cel)
                {
                    felunelkul++;
                }
                if (lista[i].cel > lista[i].start)
                {
                    fel++;
                }
            }
            be.Items.Add("5. feladat");
            be.Items.Add("=================================");
            be.Items.Add("");
            be.Items.Add("A lift " + felunelkul + " alkalommal ment fel utas nélkül.");
            be.Items.Add("A lift " + fel + " alkalommal ment fel utassal.");
        }

        private void bt_nemhasznalt_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            string kiir = "";
            for (int i = 0; i < csapatok; i++)
            {
                if (!lista.Any(x => x.sorszam == i))
                {
                    kiir += (i+1) + " ";
                }
            }
            be.Items.Add("6. feladat");
            be.Items.Add("=================================");
            be.Items.Add("");
            be.Items.Add("A következő csapatok nem használták a liftet:");
            be.Items.Add(kiir);
        }

        private void bt_vetett_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            List<Rekord> rovidlista;
            rovidlista = lista.FindAll(x => x.sorszam == random);
            bool szabalytalan = false;
            int start = 0;
            int cel = 0;
            for (int i = 0; i < rovidlista.Count(); i++)
            {
                if (i >= 1 && rovidlista[i].start != rovidlista[i-1].cel)
                {
                    szabalytalan = true;
                    start = rovidlista[i - 1].cel;
                    cel = rovidlista[i].start;
                }
            }
            if (szabalytalan)
            {
                be.Items.Add("7. feladat");
                be.Items.Add("=================================");
                be.Items.Add("");
                be.Items.Add("Gyalog mentek a(z) "+start+". és "+cel+". emelet között");
            }
            else
            {
                be.Items.Add("7. feladat");
                be.Items.Add("=================================");
                be.Items.Add("");
                be.Items.Add("Nem bizonyítható szabálytalanság!");
            }
        }

        private void bt_random_Click(object sender, EventArgs e)
        {
            Random rand1 = new Random();
            random = rand1.Next(csapatok);
            MessageBox.Show("A generálás megtörtént! ("+random+")");
           
        }
    }
}
