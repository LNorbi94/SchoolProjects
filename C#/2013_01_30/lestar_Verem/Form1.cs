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
        public frm_verem()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void bt_mehet_Click(object sender, EventArgs e)
        {
            Verem<char> stack = new Verem<char>(255);
            string str = eredeti.Text;
            stack.Clear();
            for (int i = 0; i < str.Length; i++)
            {
                stack.Push(str[i]);
            }
            char temp;
            string reversed = "";
            for (int i = 0; i < str.Length; i++)
            {
                stack.Pop(out temp);
                reversed += temp;
            }
            megcserelt.Text = reversed;
        }

        private void bt_kilep_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
