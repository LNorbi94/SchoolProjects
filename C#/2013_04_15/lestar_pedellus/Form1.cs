using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lestar_pedellus
{
    public partial class iskola : Form
    {
        public iskola()
        {
            InitializeComponent();
        }
                const int meret = 14;
        TextBox[,] tb = new TextBox[meret, meret];
        int ri, rj;
        int ui, uj;
        int szel, mag;
        int pont = 0;

        private bool jolepes()
        {
            return ((Math.Abs(uj - rj) == 1 && Math.Abs(ui - ri) == 2) || (Math.Abs(uj - rj) == 2 && Math.Abs(ui - ri) == 1));
        }

        private bool nincslehetoseg()
        {
            bool nl = (tb[ui - 2, uj - 1].BackColor == Color.Black) && (tb[ui + 2, uj - 1].BackColor == Color.Black) && 
            (tb[ui - 1, uj - 2].BackColor == Color.Black) && (tb[ui + 1, uj - 2].BackColor == Color.Black);
            nl = nl && (tb[ui + 1, uj + 2].BackColor == Color.Black) && (tb[ui - 1, uj + 2].BackColor == Color.Black) && 
            (tb[ui - 2, uj + 1].BackColor == Color.Black) && (tb[ui + 2, uj + 1].BackColor == Color.Black);
            return nl;
        }

        private void Klikk(object sender, EventArgs e)
        {
            ui = (sender as TextBox).Top / mag;
            uj = (sender as TextBox).Left / szel;
            if (ui != ri && uj != rj && tb[ui, uj].BackColor == Color.Yellow && jolepes())
            {
                tb[ui, uj].BackColor = Color.Blue;
                tb[ri, rj].BackColor = Color.Black;
                pont ++;
                lb_pont.Text = pont.ToString();
                if (pont == 99) MessageBox.Show("Gratulálok nyertél!","Üzenet");
                else
                {
                    ri = ui; rj = uj;
                    if (nincslehetoseg()) MessageBox.Show("Ma éjjel néhány lámpa világítani fog.","Üzenet");
                }

            }
        }

        private void iskola_Load(object sender, EventArgs e)
        {
            szel = p_hatter.Width / meret;
            mag = p_hatter.Height / meret;
            for (int i = 0; i < meret; i++)
            {
                for (int j = 0; j < meret; j++)
                {
                    tb[i, j] = new TextBox();
                    tb[i, j].Parent = p_hatter;
                    tb[i, j].Width = szel - 2;
                    tb[i, j].Height = mag - 2;
                    tb[i, j].Left = j * szel;
                    tb[i, j].Top = i * mag;
                    tb[i, j].ReadOnly=true;
                    tb[i, j].BackColor = Color.Yellow;
                    tb[i, j].Click += Klikk;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < meret; j++)
                {
                    tb[i, j].Visible = false;
                    tb[i, j].BackColor = Color.Black;
                    tb[i + meret - 2, j].Visible = false;
                    tb[i + meret - 2, j].BackColor = Color.Black;
                }
            }

            for (int i = 0; i < meret; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tb[i, j].Visible = false;
                    tb[i, j].BackColor = Color.Black;
                    tb[i, j + meret - 2].Visible = false;
                    tb[i, j + meret - 2].BackColor = Color.Black;
                }
            }
            ri = 2;
            rj = 2;
            tb[ri, rj].BackColor = Color.Blue;
        }
    }
}
