using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lestar_dolgozat03
{
    class Hordo : SzureteloEmber
    {
        private int puttony;

        public Hordo()
        {
            this.nev = "";
            this.erkez = 0;
            this.puttony = 0;
        }

        public Hordo(string nev_, int erkez_, int puttony_):base(nev_, erkez_)
        {
            this.nev = nev_;
            this.erkez = erkez_;
            this.puttony = puttony_;
        }

        new private Boolean viszebort()
        {
            Boolean viszbort = false;
            if (this.erkez < 8 && this.puttony > 150)
            {
                viszbort = true;
            }
            return viszbort;
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
            return s;
        }
    }
}
