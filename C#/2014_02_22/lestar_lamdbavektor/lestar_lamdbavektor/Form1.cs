using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lestar_lamdbavektor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[] array = new int[7];


        private void button1_Click(object sender, EventArgs e)
        {
            array[0] = 3;
            array[1] = 2;
            array[2] = 6;
            array[3] = 1;
            array[4] = 9;
            array[5] = 5;
            array[6] = 7;
            Array.ForEach(array, x => elemek.Items.Add(x));
        }

        private void bt_otnel_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x > 5))
            {
                int szam = array.First(x => x > 5);
                ki.Items.Add(szam);
            }
            else
            {
                ki.Items.Add("Nincs ilyen elem.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x > 50))
            {
                int szam = array.First(x => x > 50);
                ki.Items.Add(szam);
            }
            else
            {
                ki.Items.Add("Nincs ilyen elem.");
            }
        }

        private void bt_ot_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x > 5))
            {
                int[] szam = array.Where(x => x > 5).ToArray();
                Array.ForEach(szam, x => ki.Items.Add(x));
            }
            else
            {
                ki.Items.Add("Nincs egy ilyen elem se.");
            }
        }

        private void bt_otvennel_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x > 50))
            {
                int[] szam = array.Where(x => x > 50).ToArray();
                Array.ForEach(szam, x => ki.Items.Add(x));
            }
            else
            {
                ki.Items.Add("Nincs egy ilyen elem se.");
            }
        }

        private void bt_kettohat_Click(object sender, EventArgs e)
        {
            Array.ForEach(array.Where(x => x <= 6 && x >= 2).ToArray(), x => ki.Items.Add(x));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x % 2 == 0))
            {
                int szam = array.First(x => x % 2 == 0);
                ki.Items.Add(szam);
            }
            else
            {
                ki.Items.Add("Nincs páros szám.");
            }
        }

        private void bt_parosutolso_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x % 2 == 0))
            {
                int szam = array.Last(x => x % 2 == 0);
                ki.Items.Add(szam);
            }
            else
            {
                ki.Items.Add("Nincs páros szám.");
            }
        }

        private void bt_parossz_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x % 2 == 0))
            {
                int[] szam = array.Where(x => x % 2 == 0).ToArray();
                Array.ForEach(szam, x => ki.Items.Add(x));
            }
            else
            {
                ki.Items.Add("Nincs páros szám.");
            }
        }

        private void bt_negyzet_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            Array.ForEach(array, x => ki.Items.Add(x * x));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            Array.ForEach(array, x => ki.Items.Add(x * x * x));
        }

        private void button11_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            int osszeg = array.Sum();
            ki.Items.Add(osszeg);
        }

        private void bt_negyzeto_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            int osszeg = array.Sum(x => x*x);
            ki.Items.Add(osszeg);
        }

        private void bt_paroso_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            int osszeg = array.Where(x => x % 2 == 0).Sum();
            ki.Items.Add(osszeg);
        }

        private void bt_atlag_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            double osszeg = array.Average();
            ki.Items.Add(osszeg);
        }

        private void bt_patlag_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            double osszeg = array.Where(x => x % 2 == 0).Average();
            ki.Items.Add(osszeg);
        }

        private void bt_parosszam_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            int osszeg = array.Where(x => x % 2 == 0).Count();
            ki.Items.Add(osszeg);
        }

        private void bt_legn_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            int legn = array.Max();
            ki.Items.Add(legn);
        }

        private void bt_legnhely_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            List<int> Lista = array.ToList();
            int ind = Lista.IndexOf(Lista.Max());
            ki.Items.Add(ind);
        }

        private void bt_legnp_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            int legn = array.Where(x => x % 2 == 0).Max();
            ki.Items.Add(legn);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            ki.Items.Clear();
            if (array.Any(x => x < 0))
            {
                int legn = array.Where(x => x < 0).Max();
                ki.Items.Add(legn);
            }
            else
            {
                ki.Items.Add("Nincs negatív szám.");
            }
        }
    }
}
