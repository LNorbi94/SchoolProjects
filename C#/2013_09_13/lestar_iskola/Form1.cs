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

namespace lestar_iskola
{
    public partial class iskola : Form
    {
        struct Rekord
        {
            public int azon;
            public string nev;
            public int evf;
            public char oszt;
            public int hiany;
        }
        const int maxn = 1000;
        int n, m, z;
        Rekord[] v = new Rekord[maxn];

        public iskola()
        {
            InitializeComponent();
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tizenegya.Enabled = true;
            hianyzas.Enabled = true;
            StreamReader f = File.OpenText("iskolas.txt");
            while (!f.EndOfStream)
            {
                v[n].azon = int.Parse(f.ReadLine());
                v[n].nev = f.ReadLine();
                string[] tomb = f.ReadLine().Split(' ');
                v[n].evf = int.Parse(tomb[0]);
                v[n].oszt = char.Parse(tomb[1]);
                v[n].hiany = int.Parse(tomb[2]);
                n++;
            }
            tanulodg.RowCount = n;
            tanulodg.ColumnCount = 5;
            tanulodg.Columns[0].HeaderText = "Azonosító";
            tanulodg.Columns[0].Width = 60;
            tanulodg.Columns[1].HeaderText = "Név";
            tanulodg.Columns[1].Width = 133;
            tanulodg.Columns[2].HeaderText = "Évfolyam";
            tanulodg.Columns[2].Width = 60;
            tanulodg.Columns[3].HeaderText = "Osztály";
            tanulodg.Columns[3].Width = 60;
            tanulodg.Columns[4].HeaderText = "Hiányzás";
            tanulodg.Columns[4].Width = 60;
            tanulodg.TopLeftHeaderCell.Value = "Sorszám";
            for (int i = 0; i < n; i++)
            {
                tanulodg.Rows[i].HeaderCell.Value = (i + 1) + ".";
                tanulodg.Rows[i].Cells[0].Value = v[i].azon;
                tanulodg.Rows[i].Cells[1].Value = v[i].nev;
                tanulodg.Rows[i].Cells[2].Value = v[i].evf;
                tanulodg.Rows[i].Cells[3].Value = v[i].oszt;
                tanulodg.Rows[i].Cells[4].Value = v[i].hiany;
            }
        }

        private void tizenegya_Click(object sender, EventArgs e)
        {
            adg.RowCount = 19;
            adg.ColumnCount = 5;
            adg.Columns[0].HeaderText = "Azonosító";
            adg.Columns[0].Width = 60;
            adg.Columns[1].HeaderText = "Név";
            adg.Columns[1].Width = 157;
            adg.Columns[2].HeaderText = "Évfolyam";
            adg.Columns[2].Width = 60;
            adg.Columns[3].HeaderText = "Osztály";
            adg.Columns[3].Width = 60;
            adg.Columns[4].HeaderText = "Hiányzás";
            adg.Columns[4].Width = 60;
            adg.TopLeftHeaderCell.Value = "Sorszám";
            for (int i = 0; i < n; i++)
            {
                if (v[i].evf == 11 && v[i].oszt == 'a')
                {
                adg.Rows[m].HeaderCell.Value = (m + 1) + ".";
                adg.Rows[m].Cells[0].Value = v[i].azon;
                adg.Rows[m].Cells[1].Value = v[i].nev;
                adg.Rows[m].Cells[2].Value = v[i].evf;
                adg.Rows[m].Cells[3].Value = v[i].oszt;
                adg.Rows[m].Cells[4].Value = v[i].hiany;
                m++;
                }
            }
        }

        private void hianyzas_Click(object sender, EventArgs e)
        {
            if (z == 0)
            {
                Form Hianyzasok = new Form();
                Hianyzasok.Show();
                z = 1;
                Hianyzasok.Width = 1000;
                Hianyzasok.Height = 701;

            }
            else
            {
                MessageBox.Show("Már létre lett hozva a form!");
            }
        }
    }
}
