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
        List<List<Label>> labels = new List<List<Label>>();
        Random r = new Random();
        const int SIZE = 20;

        public szinnegyzet()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < SIZE; i++)
            {
                List<Label> temp = new List<Label>();
                for (var j = 0; j < SIZE; j++)
                {
                    Label l = new Label();
                    l.Parent = szinnegyzet.ActiveForm;
                    l.Top = 25 * i;
                    l.Left = 25 * j;
                    l.Width = 25;
                    l.Height = 25;
                    l.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                    temp.Add(l);
                }
                labels.Add(temp);
            }
        }

        private void kilep_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            labels.ForEach(
                x => x.ForEach(
                    y => y.Dispose()
                    )
            );
        }

        private void random_szinezes_Click(object sender, EventArgs e)
        {
            labels.ForEach(
                x => x.ForEach(
                    y => y.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))
                )
            );
        }

        private void zold_kek_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                List<Label> temp = labels.ElementAt(i);
                for (int j = 0; j < temp.Count; j++)
                {
                    temp.ElementAt(j).BackColor = Color.FromArgb(0, 196 - j * i, j * i);
                }
            }
        }

        private void szurke_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                labels.ElementAt(i).ForEach(
                    y => y.BackColor = Color.FromArgb(i * 255 / 15, i * 255 / 15, i * 255 / 15)
                );
            }
        }

        private void piros_fekete_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                List<Label> temp = labels.ElementAt(i);
                for (int j = 0; j < temp.Count; j++)
                {
                    if (j * i >= 150)
                    {
                        temp.ElementAt(j).BackColor = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        temp.ElementAt(j).BackColor = Color.FromArgb(150 - j * i, 0, 0);
                    }
                }
            }
        }

        private void piros_fekete_kek_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                List<Label> temp = labels.ElementAt(i);
                for (int j = 0; j < temp.Count; j++)
                {
                    if (j * i >= 150)
                    {
                        temp.ElementAt(j).BackColor = Color.FromArgb(0, 0, 0);
                    }
                    else
                    {
                        temp.ElementAt(j).BackColor = Color.FromArgb(150 - j * i, 0, 0);
                    }
                }
            }
        }

        private void kek_skala_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                List<Label> temp = labels.ElementAt(i);
                for (int j = 0; j < temp.Count; j++)
                {
                    temp.ElementAt(j).BackColor = Color.FromArgb(j * i + 10, i, j * i);
                }
            }
        }

        private void piros_zold_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < labels.Count; i++)
            {
                List<Label> temp = labels.ElementAt(i);
                for (int j = 0; j < temp.Count; j++)
                {
                    temp.ElementAt(j).BackColor = Color.FromArgb(196 - j * i, j * i, 0);
                }
            }
        }
    }
}
