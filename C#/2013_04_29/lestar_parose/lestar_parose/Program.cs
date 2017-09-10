using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace parose
{
    class Program
    {
        static void Main(string[] args)
        {
            int szam;
            Console.WriteLine("Egy számról eldöntöm, hogy páros vagy páratlan. \nAdd meg a számot:");
            szam = int.Parse(Console.ReadLine());
            if (szam % 2 == 0)
            {
                Console.WriteLine("Ez egy páros szám.");
            }
            else
            {
                Console.WriteLine("Ez egy páratlan szám.");
            }
            Console.ReadLine();
        }
    }
}
