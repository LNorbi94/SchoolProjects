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

        private void hozzaad_bt_Click(object sender, EventArgs e)
        {
            try
            {
                if (h.ElemE(int.Parse(had_tb.Text)))
                {
                    MessageBox.Show("Ilyen szám már van a halmazban!");
                }
                else
                {
                    h.Halmazba(int.Parse(had_tb.Text));
                    listbox.Items.Add(h.Kiir());
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Hiányzó, vagy nem jó adat.");
            }
            had_tb.Clear();
        }

        private void kiv_bt_Click(object sender, EventArgs e)
        {
            try
            {
            if (h.ElemE(int.Parse(kiv_tb.Text)))
            {
                h.Halmazbol(int.Parse(kiv_tb.Text));
                listbox.Items.Add(h.Kiir());
            }
            else
            {
                MessageBox.Show("Nincs ilyen elem a halmazban!");
            }
            }
            catch (FormatException)
            {
                MessageBox.Show("Hiányzó, vagy nem jó adat.");
            }
            kiv_tb.Clear();
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
