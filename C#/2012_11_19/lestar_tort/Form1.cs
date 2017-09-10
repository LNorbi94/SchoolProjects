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
    public partial class frm_tort : Form
    {
        public frm_tort()
        {
            InitializeComponent();
        }

        private void bt_szoroz_Click(object sender, EventArgs e)
        {
            Tort a = new Tort(int.Parse(a_szaml.Text), int.Parse(a_nevez.Text));
            Tort b = new Tort(int.Parse(b_szaml.Text), int.Parse(b_nevez.Text));
            Tort c = new Tort();
            //c = a.szorzas(b);
            //a.egyszerusit();
            //b.egyszerusit();
            er_szaml.Text = a.kiir();
        }
    }
}
