using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oroklodes
{
    class teglalap: negyszog
    {
        public teglalap()
        {
            this.a = 0;
            this.b = 0;
        }

        public teglalap(int ax, int bx)
        {
            this.a = ax;
            this.b = bx;
        }

        public int kerulet()
        {
            int ker = 2 * (this.a + this.b);
            return ker;
        }

        public int terulet()
        {
            int ter = this.a * this.b;
            return ter;
        }
    }
}
