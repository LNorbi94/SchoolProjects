using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lestar_dolgozat
{
    class Program
    {
        static List<float> v = new List<float>();
        static int tobbmintatlag;
        static int hiba;

        static void Main(string[] args)
        {
            
            do
            {
                Console.WriteLine("Adja meg a következő értéket:");
                string szoveg = Console.ReadLine();
                if (szoveg == "*")
                {
                    hiba = 1;
                }
                else
                {
                    v.Add(float.Parse(szoveg));
                }
            } while (v.Count != 15 && hiba != 1);
            for (int i = 0; i < v.Count; i++)
            {
                Console.Write(v[i]+" ");
            }
            v.Sort();
            Console.WriteLine();
            Console.WriteLine("Rendezve:");
            for (int i = 0; i < v.Count; i++)
            {
                Console.Write(v[i]+" ");
            }
            Console.WriteLine();
            float atlag = v.Sum() / v.Count;
            for (int i = 0; i < v.Count; i++)
            {
                if (v[i] > atlag)
                {
                   tobbmintatlag++; 
                }
            }
            Console.WriteLine("Az átlagnál többször mért értékek összesen: "+tobbmintatlag);
            Console.WriteLine("A legkissebb mért érték: "+v.Min());
            Console.ReadLine();
        }
    }
}