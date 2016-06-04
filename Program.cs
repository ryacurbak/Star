using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Star
{
    class Program
    {
        static bool _end = false;

        static void Main(string[] args)
        {
            Thread starGen = new Thread(new ThreadStart(StarGen));

            starGen.Start();

            bool off = false;

            while(!off)
            {
                if(_end)
                {
                    starGen.Abort();
                    off = true;
                }
            }
        }

        static void StarGen()
        {
            Console.WriteLine("Enter a number:");
            int number = ScanInt();
            int k = 0;
            int m = number;
            for (int i = 0; i < number; i++)
            {
                for (int j = 1; j <= number; j++)
                {
                    while (k < j)
                    {
                        Console.Write("*");
                        k++;
                    }
                    Console.WriteLine("");
                    k = 0;
                }
                for (int j = 1; j < number; j++)
                {
                    while (m > j)
                    {
                        Console.Write("*");
                        m--;
                    }
                    Console.WriteLine("");
                    m = number;
                }
            }
            Console.ReadKey();
            _end = true;
        }

        // Scanners
        static string Scan()
        {
            return Console.ReadLine();
        }

        static int ScanInt()
        {
            int input;
            if (int.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }
            else
            {
                return 0;
            }
        }

        static double ScanDouble()
        {
            double input;
            if (double.TryParse(Console.ReadLine(), out input))
            {
                return input;
            }
            else
            {
                return 0.0;
            }
        }
    }
}
