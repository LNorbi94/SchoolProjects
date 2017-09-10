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

namespace Homerseklet
{
    public partial class homerseklet : Form
    {
        int[,] matr = new int[100, 100];
        int n, m, z;
        public homerseklet()
        {
            InitializeComponent();
        }

        private void feltolt_Click(object sender, EventArgs e)
        {
            StreamReader f = File.OpenText("homerseklet.txt");
            string[] text1 = new string[200];
            string sor1 = f.ReadLine();
            text1 = sor1.Split(' ');
            n = int.Parse(text1[0]);
            m = int.Parse(text1[1]);
            while (!f.EndOfStream)
            {
                string[] text = new string[200];
                string sor = f.ReadLine();
                text = sor.Split(' ');
                matr[z, 0] = int.Parse(text[0]);
                matr[z, 1] = int.Parse(text[1]);
                matr[z, 2] = int.Parse(text[2]);
                matr[z, 3] = int.Parse(text[3]);
                matr[z, 4] = int.Parse(text[4]);
                z++;
            }
            be.ColumnCount = m;
            be.RowCount = n;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    be.Rows[i].Cells[j].Value = matr[i, j];
                }
            }
        }

        private void tizfok_Click(object sender, EventArgs e)
        {
            int hanyszor = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matr[i, j] < 10)
                    {
                        hanyszor++;
                    }
                }
            }
            be2.Items.Add("Összesen " + hanyszor + "x mértek 10 fok alatti hőmérsékletet.");
        }

        private void legmelegebb_Click(object sender, EventArgs e)
        {
            int legmelegebb = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matr[i, j] > legmelegebb)
                    {
                        legmelegebb = matr[i, j];
                    }
                }
            }
            be2.Items.Add("Legmelegebb mért érték: "+legmelegebb+"fok");
        }

        private void volte_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (matr[i, j] == int.Parse(volteertek.Text))
                    {
                        be2.Items.Add("Volt, a(z) " + (j+1) + ". napon, és a(z) " + (i+1) + ". mérésnél.");
                    }
                }
            }
        }

        private void atlaghomerseklet_Click(object sender, EventArgs e)
        {
            int h = 0;
            int k = 0;
            int sz = 0;
            int cs = 0;
            int p = 0;
            for (int i = 0; i < n; i++)
            {
                h += matr[i, 0];
                k += matr[i, 1];
                sz += matr[i, 2];
                cs += matr[i, 3];
                p += matr[i, 4];
            }
            be2.Items.Add("A mért átlaghőmérsékletek - Hétfőn: " + (h / 10) + ", Kedden: " + (k / 10) + ", ");
            be2.Items.Add("Szerdán: "+(sz/10)+", Csütörtökön:"+(cs/10)+", Pénteken: "+(p/10));
        }
    }
}
