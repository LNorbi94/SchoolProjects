using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lestar_statikussor
{
    public partial class frm_stat : Form
    {
        Sor<int> sor = new Sor<int>();
        
        public frm_stat()
        {
            InitializeComponent();
        }

        private void bt_kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_stat_Load(object sender, EventArgs e)
        {
            dg_ki.RowCount = 3;
            dg_ki.ColumnCount = 11;
            dg_ki.Rows[0].Height = 25;
            dg_ki.Rows[1].Height = 25;
            dg_ki.Rows[2].Height = 25;
            dg_ki.Rows[0].Cells[0].Value = "SE";
            dg_ki.Rows[1].Cells[0].Value = "SOR";
            dg_ki.Rows[2].Cells[0].Value = "SV";
            dg_ki.Rows[2].Cells[1].Value = "^";
            dg_ki.Rows[0].Cells[1].Value = "-";
            for (int i = 0; i < 11; i++)
			{
                dg_ki.Columns[i].Width = 40;
                
			}
        }

        private void bt_berak_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int elem = r.Next(100);
            if (sor.Telee())
            {
                MessageBox.Show("A sor tele van!");
            }
            else {
            sor.Sorba(elem);
            sor.kiir(dg_ki);
            }
        }

        private void bt_uj_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                dg_ki.Rows[1].Cells[i+1].Value = "0";
                dg_ki.Rows[0].Cells[i+1].Value = "";
                dg_ki.Rows[2].Cells[i+1].Value = "";
            }
            for (int i = 0; i < 11; i++)
            {
                sor.Sorbol();
                sor.setn();
            }
            dg_ki.Rows[2].Cells[1].Value = "^";
            dg_ki.Rows[0].Cells[1].Value = "-";
            bt_berak.Enabled = true;
            bt_kivesz.Enabled = true;
        }

        private void bt_kivesz_Click(object sender, EventArgs e)
        {
            if (sor.Urese())
            {
                MessageBox.Show("A sor üres!");
            }
            else {
                lb_utoljara.Text = "Az utoljára kivett elem: "+sor.Sorbol();
                if (sor.getn() > 9)
                {
                    dg_ki.Rows[0].Cells[sor.getn()].Value = "";
                    dg_ki.Rows[0].Cells[1].Value = "-";
                }
                else {
                if (sor.getn() == 0)
                {
                    dg_ki.Rows[0].Cells[sor.getn()+1].Value = "-";
                }
                else {
                dg_ki.Rows[0].Cells[sor.getn()].Value = "";
                dg_ki.Rows[0].Cells[sor.getn()+1].Value = "-";
                }
                }
            }
        }
    }
}