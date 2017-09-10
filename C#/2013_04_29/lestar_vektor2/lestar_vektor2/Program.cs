using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lestar_vektor2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[5];
            for (int i = 0; i < v.Length; i++)
            {
                Console.WriteLine("Kérem a(z) "+(i+1)+". számot:");
                v[i] = int.Parse(Console.ReadLine());
            }
            kiir(v);
            Array.Sort(v);
            Console.WriteLine("\nA vektor rendezetten:");
            kiir(v);
            Console.ReadLine();
        }

        static void kiir(int[] v)
        {
            foreach (int elem in v)
            {
                Console.Write(elem.ToString() + " ");
            }
        }
    }
}
