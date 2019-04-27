using System;

namespace NameSorter.ConsoleApp
{
    class Program
    {
        private static void InvokeCommand(string[] commands)
        {
            Console.WriteLine("====================================");
            Console.WriteLine("          Name Sorter v1");
            Console.WriteLine("      By: Mirza Ghulam Rasyid");
            Console.WriteLine("====================================\n");
            Console.WriteLine("Usage:");
            Console.WriteLine("1. Default Command (Ascending Order)");
            Console.WriteLine("   NameSorter.exe 'Target-File.txt'");
            Console.WriteLine("2. Ascending Order Command");
            Console.WriteLine("   NameSorter.exe 'Target-File.txt' ASC");
            Console.WriteLine("3. Descending Order Command");
            Console.WriteLine("   NameSorter.exe 'Target-File.txt' DESC");

            new Handler().ParseCommand(commands);
        }
        static void Main(string[] args)
        {

            InvokeCommand(args);
        }
    }
}
