using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace PrimeToFile
{
    class Program
    {
        const int kMaxArrSize = 134212856;

        static void Main(string[] args)
        {

            // Set a variable to the Documents path.
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullDocPath = Path.Combine(docPath, "primes.txt");

            if (!File.Exists(fullDocPath))
            {
                File.Create(fullDocPath).Close();
            }

            if (new FileInfo(fullDocPath).Length == 0)
            {
                using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                {
                    outputFile.WriteLine(2);
                    outputFile.WriteLine(3);
                }
            }
            Console.WriteLine("Successfully found file.");

            Console.WriteLine("Now starting the proccess of converting strings from the file into UInt64s.\n");

            List<UInt64> Primes = new List<UInt64>();
            string[] lines = File.ReadLines(fullDocPath).Take(kMaxArrSize).ToArray();
            Console.WriteLine("Successfully read in the first array of numbers as string.\n");

                foreach (string line in lines)
                {
                    try
                    {
                        Primes.Add(Convert.ToUInt64(line, 10));
                    }
                    catch
                    {
                        Console.WriteLine("Could not convert " + line + " to a UInt64 number.\nIf it is two different prime numbers that are combined, go into the file and seperate them into different lines.");
                    }
                }
            Console.WriteLine("Successfully converted the first array to UInt64 numbers.\n");

            List<UInt64> Primes2 = new List<UInt64>();
            string[] lines2 = File.ReadLines(fullDocPath).Skip(kMaxArrSize).ToArray();
            Console.WriteLine("Successfully read in the second array of numbers as string.\n");

            foreach (string line in lines2)
            {
                try
                {
                    Primes2.Add(Convert.ToUInt64(line, 10));
                }
                catch
                {
                    Console.WriteLine("Could not convert " + line + " to a UInt64 number.\nIf it is two different prime numbers that are combined, go into the file and seperate them into different lines.");
                }
            }
            Console.WriteLine("Successfully converted the second array to UInt64 numbers.\n");

            string last = File.ReadLines(fullDocPath).Last();

            Console.WriteLine("Now finished importing previous Prime Numbers from \nthe file located at: \n" + fullDocPath+ "\n");
            Console.WriteLine(last + " is the last Prime Number calculated, \nThe program will now check more numbers \nstarting on: " + (Convert.ToInt64(last) + 2) +"\n");
            Console.WriteLine("Btw, coded by Ben Puryear (17, github.com/Ben10164) \n");
            Console.WriteLine("Press any button to continue!");

            Console.ReadKey();

            for (UInt64 i = UInt64.Parse(last) + 2; i > 0; i+=2)
            {
                if (Primes.Count < kMaxArrSize)
                {
                    if (isPrime(i, Primes, Primes2))
                    {
                        Console.WriteLine(i);
                        using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                        {
                            outputFile.WriteLine(i);
                        }
                        Primes.Add(i);
                    }
                }
                else
                {
                    if (isPrime(i, Primes, Primes2))
                    {
                        Console.WriteLine(i);
                        using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                        {
                            outputFile.WriteLine(i);
                        }
                        Primes2.Add(i);
                    }
                }
            }
            Console.ReadKey();
        }

        static bool isPrime(UInt64 num, List<UInt64> Primes, List<UInt64> Primes2)
        {
            foreach (UInt64 Factor in Primes)
            {
                if (num % Factor == 0)
                {
                    return false;
                }

                if (Factor * Factor > num)
                {
                    return true;
                }
            }
            //assumes all numbers in the first array are before the second, making checking the second not needed
            if (Primes.Count >= kMaxArrSize)
            {
                foreach (UInt64 Factor in Primes2)
                {
                    if (num % Factor == 0)
                    {
                        return false;
                    }

                    if (Factor * Factor > num)
                    {
                        return true;
                    }
                }
            }
            return true;
        }
    }
}
