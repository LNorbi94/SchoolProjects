using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace vektor1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] v = new int[20];
            Random r = new Random();
            for (int i = 0; i < v.Length; i++)
            {
                v[i] = r.Next(100);
            }
            foreach (int elem in v)
            {
                Console.Write(elem.ToString()+" ");
            }
            Console.WriteLine("\nA vektor rendezetten:");
            Array.Sort(v);
            foreach (int elem in v)
            {
                Console.Write(elem.ToString() + " ");
            }
            Console.ReadLine();
        }
    }
}
