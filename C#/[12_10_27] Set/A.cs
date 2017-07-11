using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class A
    {
        private int n;
        private int talalt;
        private const int MAX = 100;
        private int[] elemek;

        public A()
        {
            n = 0;
            elemek = new int[MAX];
        }

        public int Elemszam
        {
            get
            {
                return n;
            }
        }

        public bool ElemE(int elem)
        {
            int i = -1;
            bool l = false;
            while (i < n - 1 && !l)
            {
                i++;
                if (elemek[i] == elem)
                {
                    l = true;
                }
            }
            talalt = i;
            return l;
        }

        public void Halmazba(int elem)
        {
            if (!ElemE(elem) && n < MAX)
            {
                elemek[n++] = elem;
            }
        }

        public void Halmazbol(int elem)
        {
            if (ElemE(elem))
            {
                elemek[talalt] = elemek[n - 1];
                n--;
            }
        }

        public string Kiir()
        {
            string s = "{ ";
            for (int i = 0; i < n; i++)
            {
                s += elemek[i].ToString();
                s += "; ";
            }
            s += " }";
            return s;
        }
    }
}
