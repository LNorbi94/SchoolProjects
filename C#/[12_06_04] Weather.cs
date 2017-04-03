using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;


namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        int n;
        int m;
        int mikor = 0;
        int[,] v;

        public Form1()
        {
            InitializeComponent();
        }

        private void feltoltes(ref int[,] v, ref int n, ref int m)
        {
            StreamReader f = File.OpenText("homerseklet.txt");
            string[] darabol = f.ReadLine().Split(' ');
            n = int.Parse(darabol[0]);
            m = int.Parse(darabol[1]);
            v = new int[n, m];
            for (int i = 0; i < n; i++)
            {
                string[] darabol2 = f.ReadLine().Split(' ');
                for (int j = 0; j < m; j++)
                {
                    
                    v[i, j] = int.Parse(darabol2[j]);
                }
            }
        }

        private void megjelenites(ref int[,] v, int n, int m)
        {
            dgki.RowCount = n;
            dgki.ColumnCount = m;
            for (int i = 0; i < n; i++)
            {
                dgki.Rows[i].HeaderCell.Value = (i + 1) + ". nap";
            }
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    dgki.Rows[i].Cells[j].Value = v[i, j];
                }
            }
        }

        private int tizalatt(ref int[,] v, int n, int m)
        {
            int db = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (v[i,j] < 10)
                    {
                        db++;
                    }
                }
                
            }
            return db;
        }

        private int legmelegebb(ref int[,] v, int n, int m)
        {
            int ind = 0;
            int indj = 0;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (v[i,j] > v[ind,indj])
                    {
                        ind = i;
                        indj = j;
                    }
                }
                
            }
            return ind;
        }

        private bool adott(ref int[,] v, int n, int m)
        {
            bool l = false;
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    if (v[i, j] == int.Parse(be.Text))
                    {
                        l = true;
                        mikor = i;
                    }
                } 
            }
            return l;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            feltoltes(ref v, ref n, ref m);
            megjelenites(ref v, n, m);
        }

        private void tiz_Click(object sender, EventArgs e)
        {
            int db = tizalatt(ref v, n, m);
            MessageBox.Show(db + "x mértek 10 fok alatti hőmérsékletet.");
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ind = legmelegebb(ref v, n, m);
            MessageBox.Show("A legmelegebb a(z) "+(ind+1)+". napon volt.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool l = adott(ref v, n , m);
            if (l == true)
	            {
                    MessageBox.Show((mikor+1) + ". napon volt ennyi a hőmérséklet.");
	            }
            else
            {
                MessageBox.Show("Egyik nap se volt ennyi.");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Nem mértek átlaghőmérsékletet.");
        }
    }
}
