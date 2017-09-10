using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lestar_szinesnegyzet
{
    public partial class szinnegyzet : Form
    {
        Label[,] l = new Label[15,15];
        Random r = new Random();

        public szinnegyzet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i,j] = new Label();
            l[i,j].Parent = szinnegyzet.ActiveForm;
            l[i,j].Top = 25*i;
            l[i,j].Left = 25 * j;
            l[i,j].Width = 25;
            l[i,j].Height = 25;
            l[i,j].BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            }
            }
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i,j].Dispose();
            }
            }
        }

        private void random_szinezes_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i,j].BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            }
            }
        }

        private void zold_kek_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            
            }
            }
        }

        private void szurke_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i, j].BackColor = Color.FromArgb(i*(255/15),i*(255/15),i*(255/15));
            }
            }
        }

        private void piros_fekete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i, j].BackColor = Color.FromArgb(j*i,j,i);
            }
            }
        }

        private void piros_fekete_kek_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i, j].BackColor = Color.FromArgb(i*(255/15),i,j*(255/15));
            }
            }
        }

        private void kek_skala_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
            for (int j = 0; j < 15; j++)
            {
            l[i, j].BackColor = Color.FromArgb(i,i,j*(255/15));
            }
            }
        }
    }
}
