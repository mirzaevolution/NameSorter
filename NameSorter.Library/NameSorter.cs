using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace NameSorter.Library
{

    /// <summary>
    /// Generic class that handles Name Sorting based on build-in Name Sorter
    /// </summary>
    public class NameSorter
    {
        /// <summary>
        /// A class that implements INameSorter interface that will perform sorting and saving data purposes
        /// </summary>
        private INameSorter _nameSorter;


        /// <summary>
        /// Main constructor that uses Dependency Injection
        /// </summary>
        /// <param name="nameSorter">Instance of the class that implements INameSorter interface</param>
        public NameSorter(INameSorter nameSorter)
        {
            if (nameSorter == null)
                throw new ArgumentNullException(nameof(nameSorter), "Instance of the INameSorter cannot be null");
            this._nameSorter = nameSorter;
        }


        /// <summary>
        /// Sort names by using registered Name Sorter class that implements INameSorter interface..
        /// </summary>
        /// <param name="path">Path of the file that contains list of names</param>
        /// <returns>Sorted names list</returns>
        public List<string> SortNames(string path)
        {
            return this._nameSorter.SortNames(path);
        }
    }
}
