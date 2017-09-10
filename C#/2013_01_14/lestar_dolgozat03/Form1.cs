using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lestar_dolgozat03
{
    public partial class orok_dolg : Form
    {
        public orok_dolg()
        {
            InitializeComponent();
        }

        private void rB_daralo_EnabledChanged(object sender, EventArgs e)
        {
            if (rB_daralo.Checked == true)
            {
                lb_valtozik.Text = "Berúgott-e?";
                lb_megj.Visible = true;
            }
            if (rB_metszo.Checked == true)
            {
                lb_valtozik.Text = "Mennyi vödör?";
                lb_megj.Visible = false;
            }
            if (rB_hordo.Checked == true)
            {
                lb_valtozik.Text = "Mennyi puttony?";
                lb_megj.Visible = false;
            }
        }

        private void bt_mehet_Click(object sender, EventArgs e)
        {
            if (rB_daralo.Checked == true)
            {
                Daralo daralo_o = new Daralo(tB_nev.Text, int.Parse(tB_erk.Text), int.Parse(tB_valtozik.Text));
                tB_adat.Text = daralo_o.ToString();
            }
            if (rB_metszo.Checked == true)
            {
                Metszo metszo_o = new Metszo(tB_nev.Text, int.Parse(tB_erk.Text), int.Parse(tB_valtozik.Text));
                tB_adat.Text = metszo_o.ToString();
            }
            if (rB_hordo.Checked == true)
            {
                Hordo hordo_o = new Hordo(tB_nev.Text, int.Parse(tB_erk.Text), int.Parse(tB_valtozik.Text));
                tB_adat.Text = hordo_o.ToString();
            }
        }
    }
}
