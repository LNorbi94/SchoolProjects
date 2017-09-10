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
    public partial class Form1 : Form
    {
        Label[] l = new Label[100];
        Random r = new Random();

        public Form1()
        {
            InitializeComponent();
        }

        private void cimke_elhelyezese_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 15; i++)
            {
                l[i] = new Label();
                l[i].Parent = Form1.ActiveForm;
                l[i].BackColor = Color.FromArgb(r.Next(0, 256), r.Next(0, 256), r.Next(0, 256));
                l[i].Top = r.Next(10, 380);
                l[i].Left = r.Next(20, 400);
                l[i].Width = 30;
                l[i].Height = 30;
                l[i].Click += klikk;
            }
        }

        private void klikk(object sender, EventArgs e)
        {
            (sender as Label).Text = "X";
            (sender as Label).ForeColor = Color.White;
            (sender as Label).Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            (sender as Label).TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            (sender as Label).BackColor = Color.Black;
        }
    }
}
