using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Oroklodes
{
    class negyszog
    {
        protected int a, b, c, d;

        public negyszog()
        {
            this.a = 0;
            this.b = 0;
            this.c = 0;
            this.d = 0;
        }

        public negyszog(int ax, int bx, int cx, int dx)
        {
            this.a = ax;
            this.b = bx;
            this.c = cx;
            this.d = dx;
        }

        public int kerulet()
        {
            int kerulet = this.a + this.b + this.c + this.d;
            return kerulet;
        }

        public string NemToString()
        {
            string s = "";
            s += a.ToString();
            s += b.ToString();
            s += c.ToString();
            s += d.ToString();
            return s;
        }
    }
}