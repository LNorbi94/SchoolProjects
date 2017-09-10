using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lestar_statikussor
{
    class Sor<T>
    {
        private int soreleje;
        private int sorveg;
        private int n;
        private T[] tomb;
        private const int max = 11;

        public int getn()
        {
            return soreleje;
        }

        public void setn()
        {
            soreleje = sorveg = n = 0;
        }

        public Sor()
        {
            this.soreleje = 0;
            this.sorveg = 0;
            this.n = 0;
            this.tomb = new T[max];
        }

        public bool Urese()
        {
            return this.n == 0;
        }

        public bool Telee()
        {
            return this.n == max;
        }

        public void Sorba(T elem)
        {
            if (!Telee())
            {
                this.tomb[sorveg] = elem;
                sorveg = ((sorveg+1)%max);
                n++;
            }
        }

        public T Sorbol()
        {
            if (!Urese())
            {
                T e = tomb[soreleje];
                n--;
                soreleje = ((soreleje+1)%max);
                return e;
            }
            else
            {
                return default(T);
            }
        }

        public void kiir(DataGridView dg)
        {
            int i = soreleje;
            while (i != sorveg)
            {
                if (i + 2 > 10)
                {
                    dg.Rows[2].Cells[i+1].Value = "";
                    dg.Rows[2].Cells[1].Value = "^";
                }
                else {
               dg.Rows[2].Cells[i+1].Value = "";
               dg.Rows[2].Cells[i+2].Value = "^";
                }
               dg.Rows[1].Cells[i+1].Value = tomb[i].ToString();
               i = (i+1)%max;
            }
        }
    }
}
