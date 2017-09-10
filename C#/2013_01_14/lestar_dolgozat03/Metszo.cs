using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lestar_dolgozat03
{
    class Metszo : SzureteloEmber
    {
        private int vodor;

        public Metszo()
        {
            this.nev = "";
            this.erkez = 0;
            this.vodor = 0;
        }

        public Metszo(string nev_, int erkez_, int vodor_):base(nev_, erkez_)
        {
            this.nev = nev_;
            this.erkez = erkez_;
            this.vodor = vodor_;
        }

        new private Boolean viszebort()
        {
            Boolean viszbort = false;
            if (this.erkez < 6 && this.vodor > 30)
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
