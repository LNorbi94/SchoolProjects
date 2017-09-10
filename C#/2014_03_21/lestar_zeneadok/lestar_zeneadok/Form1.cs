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

namespace lestar_zeneadok
{
    public partial class frm_zeneadok : Form
    {
        struct Rekord
        {
            public int ado;
            public int perc;
            public int masodperc;
            public string eloado;
            public string cim;
        }
        List<Rekord> Lista = new List<Rekord>();
        int zeneszam;

        public frm_zeneadok()
        {
            InitializeComponent();
        }

        private void bt_fel_Click(object sender, EventArgs e)
        {
            StreamReader f = File.OpenText("musor.txt");
            zeneszam = int.Parse(f.ReadLine());
            while (!f.EndOfStream)
            {
                string[] s = f.ReadLine().Split(' ');
                Rekord elem;
                elem.ado = int.Parse(s[0]);
                elem.perc = int.Parse(s[1]);
                elem.masodperc = int.Parse(s[2]);
                string cim = "";
                for (int i = 3; i < s.Count(); i++)
                {
                    cim += s[i]+" ";
                }
                string[] c = cim.Split(':');
                elem.eloado = c[0];
                elem.cim = c[1];
                Lista.Add(elem);
            }
            Array.ForEach(Lista.ToArray(), x => be_text.Items.Add(x.ado+", Hossz: "+x.perc+":"+x.masodperc+" perc, Előadó: "+x.eloado+", Cím: "+x.cim));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            be.Items.Clear();
            be.Items.Add("2. feladat");
            be.Items.Add("====================");
            be.Items.Add("");
            int egy = 0;
            int ketto = 0;
            int harom = 0;
            for (int i = 0; i < Lista.Count(); i++)
            {
                switch (Lista[i].ado)
                {
                    case 1: egy++; break;
                    case 2: ketto++; break;
                    case 3: harom++; break;
                    default:
                        break;
                }
            }
            be.Items.Add("Az egyes adón " + egy + " szám szólt összesen.");
            be.Items.Add("A kettes adón " + ketto + " szám szólt összesen.");
            be.Items.Add("A hármas adón " + harom + " szám szólt összesen.");
        }

        private void bt_eric_Click(object sender, EventArgs e)
        {
            Rekord elem = Lista.First(x => x.eloado == "Eric Clapton" && x.ado == 1);
            int elso = Lista.IndexOf(elem);
            Rekord elem2 = Lista.Last(x => x.eloado == "Eric Clapton" && x.ado == 1);
            int utolso = Lista.IndexOf(elem2);
            int ido = 0;
            for (int i = elso; i < utolso; i++)
            {
                if (Lista[i].ado == 1)
                {
                    ido += (Lista[i].perc*60)+Lista[i].masodperc;
                }
            }
            be.Items.Clear();
            be.Items.Add("3. feladat");
            be.Items.Add("====================");
            be.Items.Add("");
            be.Items.Add(ido / 3600+":"+(ido % 3600) / 60+":"+ido % 60);
        }
    }
}
