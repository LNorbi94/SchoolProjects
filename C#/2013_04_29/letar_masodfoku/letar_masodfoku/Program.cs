using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace letar_masodfoku
{
    class Program
    {
        static void Main(string[] args)
        {
            int a, b, c;
            double d, x1, x2;
            Console.WriteLine("Add meg az a tag eggyütthatóját");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az b tag eggyütthatóját");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Add meg az c tag eggyütthatóját");
            c = Convert.ToInt32(Console.ReadLine());
            d = b * b - 4 * a * c;
            if (d < 0)
            {
                Console.WriteLine("Nincs valós megoldás");
            }
            else
            {
                x1 = (-b + Math.Sqrt(d)) / 2 * a;
                x2 = (-b - Math.Sqrt(d)) / 2 * a;
                Console.WriteLine(x1 + " " + x2);
            }
            Console.ReadLine();
        }
    }
}
