using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class halmaz : Form
    {
        public halmaz()
        {
            InitializeComponent();
        }

        A<int> h = new A<int>();
        A<int> h2 = new A<int>();

        private void hozzaad_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (h.ElemE(int.Parse(textbox_a.Text)))
                {
                    MessageBox.Show("Ilyen szám már van a halmazban!");
                }
                else
                {
                    h.Halmazba(int.Parse(textbox_a.Text));
                    a.Items.Add(h.Kiir());
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Hiányzó, vagy nem jó adat.");
            }
            textbox_a.Clear();
        }

        private void kiv_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (h2.ElemE(int.Parse(textbox_b.Text)))
                {
                    MessageBox.Show("Ilyen szám már van a halmazban!");
                }
                else
                {
                    h2.Halmazba(int.Parse(textbox_b.Text));
                    b.Items.Add(h2.Kiir());
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Hiányzó, vagy nem jó adat.");
            }
            textbox_b.Clear();
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            A<int> osszead = new A<int>();
            osszead = h + h2;
            unio_eredmeny.Text = osszead.Kiir();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            A<int> metszet = new A<int>();
            metszet = h * h2;
            metszet_eredmeny.Text = metszet.Kiir();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            A<int> kivonas = new A<int>();
            kivonas = h - h2;
            label1.Text = kivonas.Kiir();
        }
    }
}
