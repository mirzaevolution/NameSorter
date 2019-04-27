using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Library.Test.UnitTests
{
  
    public class FakeNameSorter : INameSorter
    {
        public Task<List<string>> SortNames(string path)
        {
            if (string.IsNullOrEmpty(path))
                throw new FileNotFoundException("File is not found");
            List<string> list = new List<string>()
            { "TTTA SDF AAB", "ABC BBC ABB", "AAB BBAC ABBC", "ABC BAC", "AASAS NBA" };
            return Task.FromResult(list);
            
        }
    }
}
