using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lestar_dolgozat03
{
    class Daralo : SzureteloEmber
    {
        private int berugott;

        public Daralo()
        {
            this.nev = "";
            this.erkez = 0;
            this.berugott = 0;
        }

        public Daralo(string nev_, int erkez_, int berugott_):base(nev_, erkez_)
        {
            this.nev = nev_;
            this.erkez = erkez_;
            this.berugott = berugott_;
        }

        new private Boolean viszebort()
        {
            Boolean viszbort = false;
            if (this.erkez < 10 && this.berugott == 0)
            {
                viszbort = true;
            }
            return viszbort;
        }

        public override string ToString()
        {
            string s = "";
            s = this.nev + ", " + this.erkez + "-kor érkezik, ";
            if (this.berugott == 0)
            {
                s+= "józan, ";
            }
            else {
                s+= "berúgott, ";
            }
            if (viszebort() == true)
            {
                s+= "visz bort.";
            }
            else {
                s+= "nem visz bort.";
            }
            return s;
        }
    }
}
