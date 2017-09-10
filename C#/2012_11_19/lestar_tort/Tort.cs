using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Tort
    {
        private int szamlalo;
        private int nevezo;

        public Tort()
        {
            this.szamlalo = 0;
            this.nevezo = 1;
        }

        public Tort(int sz, int n)
        {
            this.szamlalo = sz;
            this.nevezo = n;
        }

        public int euk(int sz, int n)
        {
            int m = sz % n;
            while (m != 0)
            {
                sz = n;
                n = m;
                m = sz % n;
            }
        
            return n;
        }

        public void egyszerusit()
        {
            if (this.nevezo < this.szamlalo)
            {
                this.szamlalo = this.szamlalo / (euk(this.szamlalo, this.nevezo));
                this.nevezo = this.nevezo / (euk(this.szamlalo, this.nevezo));
                
            }
            else
            {
                this.szamlalo = this.szamlalo / (euk(this.nevezo, this.szamlalo));
                this.nevezo = this.nevezo / (euk(this.nevezo, this.szamlalo));
            }
        }

        public Tort szorzas(Tort b)
        {
            int szaml;
            int nevez;
            Tort c = new Tort();
            szaml = this.szamlalo * b.szamlalo;
            nevez = this.nevezo * b.nevezo;
            c.szamlalo = szaml;
            c.nevezo = nevez;
            c.egyszerusit();
            return c;
        }

        public string kiir()
        {
            egyszerusit();
            string s = this.szamlalo.ToString();
            return s;
        }
    }
}
