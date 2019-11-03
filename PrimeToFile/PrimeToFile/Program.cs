using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrimeToFile
{
    internal class Program
    {
        private const int kMaxArrSize = 134212856;

        private static bool isPrime(UInt64 num, List<List<UInt64>> Primes)
        {
            foreach (UInt64 Factor in Primes[0])
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
                foreach (UInt64 Factor in Primes[1])
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

            //assumes all numbers in the first array are before the second, making checking the second not needed
            if (Primes.Count >= kMaxArrSize * 2)
            {
                foreach (UInt64 Factor in Primes[2])
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

        private static void Main(string[] args)
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

            Console.WriteLine("Now starting the process of converting strings from the file into UInt64s.\n");

            List<List<UInt64>> PrimesList = new List<List<UInt64>>();

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
                    Console.WriteLine("Could not convert " + line + " to a UInt64 number.\nIf it is two different prime numbers that are combined, go into the file and separate them into different lines.");
                }
            }
            Console.WriteLine("Successfully converted the first array to UInt64 numbers.\n");

            PrimesList.Add(Primes);

            List<UInt64> Primes2 = new List<UInt64>();
            lines = File.ReadLines(fullDocPath).Skip(kMaxArrSize).ToArray();
            Console.WriteLine("Successfully read in the second array of numbers as string.\n");

            foreach (string line in lines)
            {
                try
                {
                    Primes2.Add(Convert.ToUInt64(line, 10));
                }
                catch
                {
                    Console.WriteLine("Could not convert " + line + " to a UInt64 number.\nIf it is two different prime numbers that are combined, go into the file and separate them into different lines.");
                }
            }
            Console.WriteLine("Successfully converted the second array to UInt64 numbers.\n");

            PrimesList.Add(Primes2);

            List<UInt64> Primes3 = new List<UInt64>();
            lines = File.ReadLines(fullDocPath).Skip(kMaxArrSize * 2).ToArray();
            Console.WriteLine("Successfully read in the third array of numbers as string.\n");

            foreach (string line in lines)
            {
                try
                {
                    Primes3.Add(Convert.ToUInt64(line, 10));
                }
                catch
                {
                    Console.WriteLine("Could not convert " + line + " to a UInt64 number.\nIf it is two different prime numbers that are combined, go into the file and separate them into different lines.");
                }
            }
            Console.WriteLine("Successfully converted the third array to UInt64 numbers.\n");

            PrimesList.Add(Primes3);

            string last = File.ReadLines(fullDocPath).Last();


            Console.WriteLine("Now finished importing previous Prime Numbers from \nthe file located at: \n" + fullDocPath + "\n");
            Console.WriteLine(last + " is the last Prime Number calculated, \nThe program will now check more numbers \nstarting on: " + (Convert.ToInt64(last) + 2) + "\n");
            Console.WriteLine("BTW, coded by Ben Puryear (17, github.com/Ben10164) \n");
            Console.WriteLine("Press any button to continue!");

            Console.ReadKey();

            for (UInt64 i = UInt64.Parse(last) + 2; i > 0; i += 2)
            {
                if (Primes.Count < kMaxArrSize)
                {
                    if (isPrime(i, PrimesList))
                    {
                        Console.WriteLine(i);
                        using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                        {
                            outputFile.WriteLine(i);
                        }
                        Primes.Add(i);
                    }
                }
                else if (Primes.Count >= kMaxArrSize && Primes2.Count < kMaxArrSize)
                {
                    if (isPrime(i, PrimesList))
                    {
                        Console.WriteLine(i);
                        using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                        {
                            outputFile.WriteLine(i);
                        }
                        Primes2.Add(i);
                    }
                }
                else if (Primes.Count >= kMaxArrSize && Primes2.Count >= kMaxArrSize && Primes3.Count < kMaxArrSize)
                {
                    if (isPrime(i, PrimesList))
                    {
                        Console.WriteLine(i);
                        using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                        {
                            outputFile.WriteLine(i);
                        }
                        Primes3.Add(i);
                    }
                }
            }
            Console.ReadKey();
        }
    }
}