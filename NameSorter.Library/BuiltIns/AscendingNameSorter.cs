using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace NameSorter.Library.BuiltIns
{
    /// <summary>
    /// Built-In Name Sorter that sorts list of names in ascending order
    /// </summary>
    public class AscendingNameSorter : INameSorter
    {
        /// <summary>
        /// Sort list of names in ascending order from a file
        /// </summary>
        /// <param name="path">Path of the file that contains list of names</param>
        /// <returns>Sorted names list in ascending order</returns>
        public async Task<List<string>> SortNames(string path)
        {
            //If file not found, then throw an exception
            if (!File.Exists(path))
                throw new FileNotFoundException("Target file is not found");

            //Get list of names from a file. It uses asynchronous technique to invoke file system function
            List<string> names = await GetListOfNames(path);

            /* The Algorithm:
             * 1. Take the last name from the name
             * 2. Sort the list based on the last name (deferred)
             * 3. Take the givename from the name
             * 4. Sort the list based on the given name
             * 5. Return the sorted list
             */

            return  names
                    .OrderBy(a => a.Split(' ').LastOrDefault())
                    .ThenBy(b => Regex.Match(b, @"\w+(?>\s\w+)", RegexOptions.Compiled | RegexOptions.IgnoreCase).Value??string.Empty)
                    .ToList();
        }


        private async Task<List<string>> GetListOfNames(string path)
        {
            try
            {
                List<string> result = new List<string>();

                //Invokes the selected file and reads line by line, store it in a list, then returns the list back to the caller
                using (StreamReader reader = new StreamReader(path))
                {
                    while (reader.Peek() > 0)
                    {
                        result.Add(await reader.ReadLineAsync());
                    }
                }
                return result;
            }
            catch(Exception ex)
            {
                Trace.WriteLine(ex);
                return new List<string>();
            }
        }
    }
}
