using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Oroklodes
{
    public partial class oroklodes : Form
    {
        public oroklodes()
        {
            InitializeComponent();
        }

        private void bt_kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rB_negyzet_CheckedChanged(object sender, EventArgs e)
        {
            if (rB_negyzet.Checked == true)
            {
                b.Enabled = false;
                c.Enabled = false;
                d.Enabled = false;
                tb_magas.Enabled = false;
            }
            if (rB_teglalap.Checked == true)
            {
                b.Enabled = true;
                c.Enabled = false;
                d.Enabled = false;
                tb_magas.Enabled = false;
            }
            if (rB_trapez.Checked == true)
            {
                b.Enabled = true;
                c.Enabled = true;
                d.Enabled = true;
                tb_magas.Enabled = true;
            }
        }

        private void bt_mehet_Click(object sender, EventArgs e)
        {
            if (rB_negyzet.Checked == true)
            {
               negyzet valami = new negyzet(int.Parse(a.Text));
               kerulet.Text = valami.kerulet().ToString();
               terulet.Text = valami.terulet().ToString(); 
            }
            if (rB_teglalap.Checked == true)
            {
               teglalap valami = new teglalap(int.Parse(a.Text), int.Parse(b.Text));
               kerulet.Text = valami.kerulet().ToString();
               terulet.Text = valami.terulet().ToString();      
            }
            if (rB_trapez.Checked == true)
            {
                
            }
            
        }
    }
}