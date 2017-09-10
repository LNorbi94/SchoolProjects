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
        int n;
        public osztalyzatok()
        {
            InitializeComponent();
        }

        private void bt_mehet_Click(object sender, EventArgs e)
        {
            bt_mehet.Enabled = false;
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
                    str += "\t" + elem.atlag;
                    be.Items.Add(str);
                }
	        }
	        catch (Exception hiba)
	        {
                MessageBox.Show("Hiba:" + hiba);
	        }
        }
    }
}
