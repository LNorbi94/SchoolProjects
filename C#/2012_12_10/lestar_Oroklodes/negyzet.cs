using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oroklodes
{
    class negyzet : negyszog
    {
        public negyzet()
        {
            this.a = 0;
        }

        public negyzet(int ax)
        {
            this.a = ax;
        }

        public int kerulet()
        {
            int ker = 4 * this.a;
            return ker;
        }

        public int terulet()
        {
            int ter = this.a * this.a;
            return ter;
        }
    }
}