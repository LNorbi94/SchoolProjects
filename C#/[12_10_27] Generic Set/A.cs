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
            }
        }

        public void Halmazbol(T elem)
        {
            if (ElemE(elem))
            {
                elemek[talalt] = elemek[n - 1];
                n--;
            }
        }

        public static A<T> operator +(A<T> a, A<T> b)
        {
            A<T> c = new A<T>();
            int i = 0;
            int j = 0;
            while (i < a.n && j < b.n)
            {
                int x = a.elemek[i].CompareTo(b.elemek[j]);
                if (x < 0) { c.elemek[c.n] = a.elemek[i++]; }
                else if (x > 0) { c.elemek[c.n] = b.elemek[j++]; }
                else { c.elemek[c.n] = a.elemek[i++]; j++; }
                c.n++;
            }
            while (i < a.n)
            {
                c.elemek[c.n++] = a.elemek[i++];
            }
            while (j < b.n)
            {
                c.elemek[c.n++] = b.elemek[j++];
            }
            return c;
        }

        public static A<T> operator *(A<T> a, A<T> b)
        {
            A<T> c = new A<T>();
            int i = 0;
            int j = 0;
            while (i < a.n && j < b.n)
            {
                int x = a.elemek[i].CompareTo(b.elemek[j]);
                if (x < 0) { i++; }
                else if (x > 0) { j++; }
                else { c.elemek[c.n++] = a.elemek[i++]; j++; }
            }
            return c;
        }

        public static A<T> operator -(A<T> a, A<T> b)
        {
            A<T> c = new A<T>();
            int i = 0;
            int j = 0;
            while (i < a.n && j < b.n)
            {
                int x = a.elemek[i].CompareTo(b.elemek[j]);
                if (x < 0) { c.elemek[c.n++] = a.elemek[i++]; j++; }
                else if (x > 0) { j++; }
                else { i++; }
            }
            return c;
        }

        public string Kiir()
        {
            Rendez();
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
