using System;
using System.IO;

namespace Primes_Count
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Press any button to start the process of counting the numbers in the primes document!");
            Console.ReadKey();
            Console.WriteLine("Now starting!\nIt can take a while so be prepared to wait if the file is large.");

            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string fullDocPath = Path.Combine(docPath, "primes.txt");

            UInt64 counter = 0;
            if (File.Exists(fullDocPath))
            {
                using (StreamReader sr = File.OpenText(fullDocPath))
                {
                    string s = String.Empty;
                    while ((s = sr.ReadLine()) != null)
                    {
                        counter++;
                    }
                }
                Console.WriteLine(counter);
                Console.WriteLine("Keep in mind this only counts the lines.");
            }
            else
            {
                Console.WriteLine("Hey so, the file doesn't exist. It should be located at " + fullDocPath + " so if you moved it, neither programs can work.");
            }
            Console.ReadKey();
        }
    }
}