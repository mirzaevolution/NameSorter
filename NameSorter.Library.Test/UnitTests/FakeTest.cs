using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NameSorter.Library.Test.UnitTests
{
    [TestClass]
    public class FakeTest
    {
        private DefaultNameSorter _nameSorter;
        
        public FakeTest()
        {
            _nameSorter = new DefaultNameSorter(new FakeNameSorter());
        }

        [TestMethod]
        public void SortNames()
        {
            List<string> expectedList = new List<string>()
            { "TTTA SDF AAB", "ABC BBC ABB", "AAB BBAC ABBC", "ABC BAC", "AASAS NBA" };
            CollectionAssert.AreEqual(expectedList, _nameSorter.SortNames(@"Fake-Unsorted-List.txt").Result);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void TestThrowException()
        {
            _nameSorter.SortNames("");
        }
    }
}
