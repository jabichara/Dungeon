using ClassLibrary.Generators;
using ClassLibrary.SortingAlgorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class TextSortTests
    {
        [TestMethod]
        public void SortText()
        {
            string[] text = TextGenerator.GenerateText(10, 5).Split();
            MergeSorter.Sort(text);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void BubbleSort()
        {
            string[] text = TextGenerator.GenerateText(100, 5).Split();
            BubbleSorter.Sort(text);
            Assert.AreEqual(1, 1);
        }
    }
}
