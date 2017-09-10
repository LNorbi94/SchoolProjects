using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lestar_dolgozat03
{
    class SzureteloEmber
    {
        protected string nev;
        protected int erkez;

        public SzureteloEmber()
        {
            this.nev = "";
            this.erkez = 0;
        }

        public SzureteloEmber(string nev_, int erkez_)
        {
            this.nev = nev_;
            this.erkez = erkez_;
        }

        private Boolean viszebort()
        {
            bool visze = false;
            if (this.erkez < 7)
            {
                visze = true;
            }
            return visze;
        }

        public override string ToString()
        {
            string s = "";
            s = this.nev + ", " + this.erkez + "-kor érkezik, ";
            if (viszebort() == true)
            {
                s+= "visz bort.";
            }
            else {
                s+= "nem visz bort.";
            }
            return base.ToString();
        }

    }
}
