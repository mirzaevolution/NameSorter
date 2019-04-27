using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NameSorter.Library.BuiltIns;

namespace NameSorter.Library.Test.LibraryTests
{
    [TestClass]
    public class RealDataTest
    {
        [TestMethod]
        public void AscSortTest()
        {
            //Change this location based on your need
            string path = @"D:\unsorted-list.txt";

            //This static list of names taken from sample
            List<string> expectedResult = new List<string>
            {
                "Hailey Avie Annakin",
                "Erna Dorey Battelle",
                "Selle Bellison",
                "Flori Chaunce Franzel",
                "Orson Milka Iddins",
                "Odetta Sue Kaspar",
                "Roy Ketti Kopfen",
                "Madel Bordie Mapplebeck",
                "Debra Micheli",
                "Leonerd Adda Mitchell Monaghan"
            };

            AscendingNameSorter ascendingNameSorter = new AscendingNameSorter();


            List<string> actualResult = ascendingNameSorter.SortNames(path).Result;

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void DescSortTest()
        {

            //Change this location based on your need
            string path = @"D:\unsorted-list.txt";

            //This static list of names taken from sample
            List<string> expectedResult = new List<string>
            {
                "Leonerd Adda Mitchell Monaghan",
                "Debra Micheli",
                "Madel Bordie Mapplebeck",
                "Roy Ketti Kopfen",
                "Odetta Sue Kaspar",
                "Orson Milka Iddins",
                "Flori Chaunce Franzel",
                "Selle Bellison",
                "Erna Dorey Battelle",
                "Hailey Avie Annakin"
            };

            DescendingNameSorter descendingNameSorter = new DescendingNameSorter();

            List<string> actualResult = descendingNameSorter.SortNames(path).Result;

            CollectionAssert.AreEqual(expectedResult, actualResult);
        }

    }
}
