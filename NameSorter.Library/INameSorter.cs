using System.Collections.Generic;

namespace NameSorter.Library
{
    /// <summary>
    /// Name sorter interface
    /// </summary>
    public interface INameSorter
    {
        /// <summary>
        /// Sort list of names that read from given file name path
        /// </summary>
        /// <param name="path">Path of the file</param>
        /// <returns>List of name sorted by lastname and the by given name</returns>
        List<string> SortNames(string path);
    }
}
