using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WindowsFormsApplication1
{
    class A<T> where T:IComparable<T>
    {
        private int n;
        private int talalt;
        private const int MAX = 100;
        private T[] elemek;

        public A()
        {
            n = 0;
            elemek = new T[MAX];
        }

        public int Elemszam
        {
            get
            {
                return n;
            }
        }

        public bool ElemE(T elem)
        {
            int i = 0;
            int u = n - 1;
            int e = 0;
            bool l = false;
            while (!l && e <= u)
            {
                i = (e + u) / 2;
                int x = elemek[i].CompareTo(elem);
                if (x < 0)
                {
                    e = i + 1;
                }
                else if (x > 0)
                {
                    u = i - 1;
                }
                else
                {
                    l = true;
                }
            }
            talalt = i;
            return l;
        }

        public void Halmazba(T elem)
        {
            if (!ElemE(elem) && n < MAX)
            {
                elemek[n++] = elem;
                Rendez();
            }
        }

        public void Halmazbol(T elem)
        {
            if (ElemE(elem))
            {
                elemek[talalt] = elemek[n - 1];
                n--;
                Rendez();
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

        private static void csere(ref T x, ref T y)
        {
            T s = x;
            x = y;
            y = s;
        }

        private void MinKiv(int i, out int ind)
        {
            ind = i;
            for (int j = i + 1; j < n; j++)
            {
                if (elemek[j].CompareTo(elemek[ind]) < 0)
                {
                    ind = j;
                }
            }
        }

        private void Rendez()
        {
            for (int i = 0; i < n - 1; i++)
            {
                int ind;
                MinKiv(i, out ind);
                if (i != ind)
                {
                    csere(ref elemek[i], ref elemek[ind]);
                }
            }
        }
    }
}
