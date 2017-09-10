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

namespace lestar_lista2
{
    public partial class list2 : Form
    {
        int hkfelett;
        List<int> lista = new List<int>();

        public list2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            feltolt.Enabled = false;
            bt_csokken.Enabled = true;
            bt_felett.Enabled = true;
            bt_huszonharom.Enabled = true;
            bt_legn.Enabled = true;
            bt_osszes.Enabled = true;
            bt_torolegy.Enabled = true;
            bt_torolketto.Enabled = true;
            keres.Enabled = true;
            StreamReader f = File.OpenText("lista_adat.txt");
            while (!f.EndOfStream)
            {
                lista.Add(int.Parse(f.ReadLine()));
            }
            for (int i = 0; i < lista.Count; i++)
            {
                be.Items.Add(lista[i]);
            }
        }

        private void bt_legn_Click(object sender, EventArgs e)
        {
            be.Items.Add("Legnagyobb dobott pont: "+lista.Max()+", helye: "+lista.IndexOf(lista.Max()));
        }

        private void keres_Click(object sender, EventArgs e)
        {
            if (lista.Contains(47))
            {
                be.Items.Add("Van 47 a listában.");
            }
            else
            {
                be.Items.Add("Nincs 47 a listában.");
            }
        }

        private void bt_osszes_Click(object sender, EventArgs e)
        {
            be.Items.Add("Összes dobott pont: "+lista.Sum());
        }

        private void bt_csokken_Click(object sender, EventArgs e)
        {
            lista.Sort();
            lista.Reverse();
            be.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            { be.Items.Add(lista[i]); }
        }

        private void bt_huszonharom_Click(object sender, EventArgs e)
        {
            if (lista.Contains(23))
            {
                be.Items.Add("Van 23 a listában.");
            }
            else
            {
                be.Items.Add("Nincs 23 a listában.");
            }
        }

        private void bt_torolegy_Click(object sender, EventArgs e)
        {
            lista.Remove(33);
            be.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            { be.Items.Add(lista[i]); }
        }

        private void bt_torolketto_Click(object sender, EventArgs e)
        {
            lista.RemoveAt(3);
            be.Items.Clear();
            for (int i = 0; i < lista.Count; i++)
            { be.Items.Add(lista[i]); }
        }

        private void bt_felett_Click(object sender, EventArgs e)
        {
            hkfelett = 0;
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i] > 32)
                {
                    hkfelett++;
                }
            }
            be.Items.Add(hkfelett + " darab dobás volt 32 felett.");
        }
    }
}
