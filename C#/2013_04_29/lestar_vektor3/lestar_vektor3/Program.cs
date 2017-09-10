using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace lestar_vektor3
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayList v = new ArrayList();
            int elem;
            Console.WriteLine("0 végjelig vektorfeltöltés");
            do
            {
                Console.WriteLine("Add meg a következő elemet:");
                elem = int.Parse(Console.ReadLine());
                if (elem != 0)
                {
                    v.Add(elem); 
                }
            } while (elem != 0);

            foreach (int item in v)
            {
                Console.Write(item.ToString()+" ");
            }
            Console.ReadLine();
        }
    }
}
