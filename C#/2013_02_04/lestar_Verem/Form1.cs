using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Verem
{
    public partial class frm_verem : Form
    {
        Verem<char> stack = new Verem<char>(255);
        int i = 0;

        public frm_verem()
        {
            InitializeComponent();
        }

        private void bt_mehet_Click(object sender, EventArgs e)
        {
            eredeti.Enabled = false;
            string str = eredeti.Text;
            if (str.Length < i+1)
            {
                MessageBox.Show("Vége a szövegnek!");
            }
            else
            {
                stack.Push(str[i]);
                dg.ColumnCount = i+2;
                dg.Columns[i+1].Width = 35;
                dg.Columns[i+1].HeaderCell.Value = (i+1)+".";
                dg.Rows[0].Cells[i].Value = "";
                dg.Rows[0].Cells[i+1].Value = "^";
                dg.Rows[1].Cells[i+1].Value = str[i];
                i++;
            }
        }

        private void bt_kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_verem_Load(object sender, EventArgs e)
        {
            dg.RowCount = 2;
            dg.ColumnCount = 1;
            dg.Columns[0].Width = 35;
            dg.Rows[0].HeaderCell.Value = "Verem mutató";
            dg.Rows[1].HeaderCell.Value = "A verem";
            dg.Columns[0].HeaderCell.Value = "0.";
            dg.Rows[0].Cells[0].Value = "^";
            dg.Rows[1].Cells[0].Value = "X";
        }

        private void bt_verembol_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                MessageBox.Show("Kiürült a verem!");
            }
            else {
            char temp;
            string reversed = "";
            stack.Pop(out temp);
            reversed = megcserelt.Text;
            reversed += temp;
            megcserelt.Text = reversed;
            dg.ColumnCount = i;
            dg.Rows[0].Cells[i-1].Value = "^";
            i--;
            }
        }
    }
}
