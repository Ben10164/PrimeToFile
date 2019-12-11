using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PrimeToFile
{
    internal class Program
    {
        private const int MaxArrSize = 100000000 / 2;

        public static void ConvertToArray(List<List<UInt64>> PrimesList, string fullDocPath)
        {
            Console.WriteLine("Now starting the process of converting strings from the file into UInt64s.\n");

            List<List<UInt64>> PrimesListTemp = new List<List<UInt64>>();

            List<UInt64> Primes = new List<UInt64>();
            List<UInt64> Primes2 = new List<UInt64>();
            List<UInt64> Primes3 = new List<UInt64>();
            List<UInt64> Primes4 = new List<UInt64>();
            List<UInt64> Primes5 = new List<UInt64>();
            List<UInt64> Primes6 = new List<UInt64>();
            List<UInt64> Primes7 = new List<UInt64>();
            List<UInt64> Primes8 = new List<UInt64>();
            List<UInt64> Primes9 = new List<UInt64>();
            List<UInt64> Primes10 = new List<UInt64>();
            List<UInt64> Primes11 = new List<UInt64>();
            List<UInt64> Primes12 = new List<UInt64>();
            List<UInt64> Primes13 = new List<UInt64>();
            List<UInt64> Primes14 = new List<UInt64>();
            List<UInt64> Primes15 = new List<UInt64>();
            List<UInt64> Primes16 = new List<UInt64>();
            List<UInt64> Primes17 = new List<UInt64>();
            List<UInt64> Primes18 = new List<UInt64>();
            List<UInt64> Primes19 = new List<UInt64>();
            List<UInt64> Primes20 = new List<UInt64>();
            List<UInt64> Primes21 = new List<UInt64>();
            List<UInt64> Primes22 = new List<UInt64>();
            List<UInt64> Primes23 = new List<UInt64>();
            List<UInt64> Primes24 = new List<UInt64>();
            List<UInt64> Primes25 = new List<UInt64>();
            List<UInt64> Primes26 = new List<UInt64>();
            List<UInt64> Primes27 = new List<UInt64>();
            List<UInt64> Primes28 = new List<UInt64>();
            List<UInt64> Primes29 = new List<UInt64>();
            List<UInt64> Primes30 = new List<UInt64>();

            PrimesListTemp.Add(Primes);
            PrimesListTemp.Add(Primes2);
            PrimesListTemp.Add(Primes3);
            PrimesListTemp.Add(Primes4);
            PrimesListTemp.Add(Primes5);
            PrimesListTemp.Add(Primes6);
            PrimesListTemp.Add(Primes7);
            PrimesListTemp.Add(Primes8);
            PrimesListTemp.Add(Primes9);
            PrimesListTemp.Add(Primes10);
            PrimesListTemp.Add(Primes11);
            PrimesListTemp.Add(Primes12);
            PrimesListTemp.Add(Primes13);
            PrimesListTemp.Add(Primes14);
            PrimesListTemp.Add(Primes15);
            PrimesListTemp.Add(Primes16);
            PrimesListTemp.Add(Primes17);
            PrimesListTemp.Add(Primes18);
            PrimesListTemp.Add(Primes19);
            PrimesListTemp.Add(Primes20);
            PrimesListTemp.Add(Primes21);
            PrimesListTemp.Add(Primes22);
            PrimesListTemp.Add(Primes23);
            PrimesListTemp.Add(Primes24);
            PrimesListTemp.Add(Primes25);
            PrimesListTemp.Add(Primes26);
            PrimesListTemp.Add(Primes27);
            PrimesListTemp.Add(Primes28);
            PrimesListTemp.Add(Primes29);
            PrimesListTemp.Add(Primes30);

            string[] lines = new string[100000000 / 2];
            bool temp = true;

            for (int pos = 0; pos < PrimesListTemp.Count && temp; pos++)
            {
                PrimesList.Add(PrimesListTemp[pos]);
                lines = File.ReadLines(fullDocPath).Skip(MaxArrSize * pos).Take(MaxArrSize).ToArray();

                foreach (string line in lines)
                {
                    try
                    {
                        PrimesList[pos].Add(Convert.ToUInt64(line, 10));
                    }
                    catch
                    {
                        Console.WriteLine("Could not convert " + line + " to a UInt64 number.\nIf it is two different prime numbers that are combined, go into the file and separate them into different lines.");
                    }
                }
                Console.WriteLine("PrimesList[" + pos + "] was just imported");

                if (pos > 0)
                {
                    try
                    {
                        if (PrimesList[pos].First() == PrimesList[pos-1].First())
                        {
                            break;
                        }
                    }
                    catch
                    {
                        break;
                    }
                }
            }
            Array.Clear(lines, 0, lines.Length);
        }

        public static void FindFolder(string fullDocPath)
        {
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
        }

        public static void Organize(List<List<UInt64>> PrimesList, UInt64 i)
        {
            for (int listNum = 0; listNum < PrimesList.Count; listNum++)
            {
                if (PrimesList[listNum].Count < MaxArrSize)
                {
                    PrimesList[listNum].Add(i);
                }
            }
        }

        public static void WriteDesc(string fullDocPath, string last)
        {
            Console.WriteLine("\nNow finished importing previous Prime Numbers from \nthe file located at: \n" + fullDocPath + "\n");
            Console.WriteLine(last + " is the last Prime Number calculated, \nThe program will now check more numbers \nstarting on: " + (Convert.ToInt64(last) + 2) + "\n");
            Console.WriteLine("BTW, coded by Ben Puryear (17, github.com/Ben10164) \n");
            Console.WriteLine("Press any button to continue!");
        }

        private static bool IsPrime(UInt64 num, List<List<UInt64>> Primes)
        {
            for (int listNum = 0; listNum < Primes.Count; listNum++)
            {
                foreach (UInt64 Factor in Primes[listNum])
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
            //This should never happen...
            return true;
        }

        private static void Main()
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullDocPath = Path.Combine(docPath, "primes.txt");
            List<List<UInt64>> PrimesList = new List<List<UInt64>>();

            FindFolder(fullDocPath);

            ConvertToArray(PrimesList, fullDocPath);

            string last = File.ReadLines(fullDocPath).Last();

            WriteDesc(fullDocPath, last);

            Console.ReadKey();
            Console.WriteLine();

            for (UInt64 i = UInt64.Parse(last) + 2; i > 0; i += 2)
            {
                if (IsPrime(i, PrimesList))
                {
                    Console.WriteLine(i);
                    using (StreamWriter outputFile = new StreamWriter(fullDocPath, true))
                    {
                        outputFile.WriteLine(i);
                    }
                    Organize(PrimesList, i);
                }
            }
            Console.ReadKey();
        }
    }
}