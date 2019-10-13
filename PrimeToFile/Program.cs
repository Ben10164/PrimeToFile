using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
using System.IO;
using Org.BouncyCastle;

namespace PrimeToFile
{
    class Program
    {
        static void Main(string[] args)
        {
            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullDocPath = Path.Combine(docPath, "primes.txt");

            if (File.Exists(fullDocPath))
            {
                //Nothing LOL
            }
            else
            {
                File.Create(fullDocPath).Close();
            }

            if (new FileInfo(fullDocPath).Length == 0)
            {
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "primes.txt"), true))
                {
                    outputFile.WriteLine(2);
                }
            }

            List<UInt64> Primes = new List<UInt64>();

            string[] lines = System.IO.File.ReadAllLines(fullDocPath);
            string last = File.ReadLines(Path.Combine(docPath, "primes.txt")).Last();

            foreach (string line in lines)
            {
                Primes.Add(Convert.ToUInt64(line, 10));
            }


            Console.WriteLine("Now finished importing previous Prime Numbers from \nthe file located at: \n" + fullDocPath+ "\n");
            Console.WriteLine(last + " is the last Prime Number calculated, \nThe program will now check more numbers \nstarting on: " + (Convert.ToInt64(last) + 1) +"\n");
            Console.WriteLine("Btw, coded by Ben Puryear (17, github.com/Ben10164) \n");
            Console.WriteLine("Press any button to continue!");

            Console.ReadKey();

            for (UInt64 i = UInt64.Parse(last) + 1; i > 0; i++)
            {
                if (isPrime(i, Primes))
                {
                    Console.WriteLine(i);
                    using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "primes.txt"), true))
                    {
                        outputFile.WriteLine(i);
                    }
                    Primes.Add(i);
                }
            }
            Console.ReadKey();
        }

        static bool isPrime(UInt64 num, List<UInt64> Primes)
        {
            foreach (UInt64 Factor in Primes)
            {
                if (Factor * Factor > num)
                {
                    break;
                }
                
                if (num % Factor == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
