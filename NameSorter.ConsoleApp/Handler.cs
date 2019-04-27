using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NameSorter.Library;
using NameSorter.Library.BuiltIns;

namespace NameSorter.ConsoleApp
{
    /// <summary>
    /// Constant Fields
    /// </summary>
    public class Constants
    {
        public static readonly string ASCENDING_ORDER = "ASC";
        public static readonly string DESCENDING_ORDER = "DESC";
    }

    /// <summary>
    /// Handler class for handling parsing command and executing desired sorting algorithm
    /// </summary>
    public class Handler
    {
    
        /// <summary>
        /// Parses the command and invoke the Name Sorter algorithm to sort the names
        /// </summary>
        /// <param name="commands">Command line command</param>
        public void ParseCommand(string[] commands)
        {
            DefaultNameSorter sorter;

            //Default command. It is ascending order
            if(commands.Length==1)
            {
                //Get the target file name
                string path = commands[0];

                sorter = new DefaultNameSorter(new AscendingNameSorter());
                Sort(sorter, path, Constants.ASCENDING_ORDER).Wait();
            }
            else if(commands.Length==2)
            {
                //Get the target file name
                string path = commands[0];

                //Get the sort order
                string sortOrder = commands[1];


                if(sortOrder.Equals(Constants.ASCENDING_ORDER,StringComparison.CurrentCultureIgnoreCase))
                {
                    sorter = new DefaultNameSorter(new AscendingNameSorter());
                    Sort(sorter, path, Constants.ASCENDING_ORDER).Wait();
                }
                else if (sortOrder.Equals(Constants.DESCENDING_ORDER, StringComparison.CurrentCultureIgnoreCase))
                {
                    sorter = new DefaultNameSorter(new DescendingNameSorter());
                    Sort(sorter, path, Constants.DESCENDING_ORDER).Wait();
                }
                else
                {
                    Console.WriteLine("Sort order command is invalid. Possible values are: ASC and DESC (case-insensitive)");
                }
            }
            else
            {
                Console.WriteLine("\n[!] Please enter a valid command");
            }
        }


        private async Task Sort(DefaultNameSorter sorter, string path, string order)
        {
            if(!File.Exists(path))
            {
                Console.WriteLine($"`{path}` is not found");
            }
            List<string> sortedNames = await sorter.SortNames(path);
            if(sortedNames.Count>0)
            {
                StringBuilder fileContents = new StringBuilder();
                Console.WriteLine("\n");
                Console.WriteLine("Sorted List of Names:\n");
                foreach(string name in sortedNames)
                {
                    Console.WriteLine(name);
                    fileContents.AppendLine(name);
                }
                string filenameWithoutExtension = Path.GetFileNameWithoutExtension(path);
                string baseDirectory = Path.GetDirectoryName(path);
                string newFileName = string.Concat(filenameWithoutExtension, $"-[{order.ToLower()}-order]", Path.GetExtension(path));
                string newPath = Path.Combine(baseDirectory, newFileName);
                try
                {
                    File.WriteAllText(path: newPath, contents: fileContents.ToString());
                    Console.WriteLine($"\nSorted list of names saved at: {newPath}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"\nFailed to save the sorted list of names.");
                    Console.WriteLine($"Reason: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("\nFile doesn't contain any character");
            }
        }
       
    }
}
