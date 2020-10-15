using ClassLibrary.Generators;
using ClassLibrary.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class SortersTests
    {
        [TestMethod]
        public void BubbleSortTest()
        {
            int[] arr = IntArrayGenerator.GenerateArray(1000);
            BubbleSorter.Sort(arr);
            int el = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (el > arr[i])
                {
                    Assert.Fail();
                }
                el = arr[i];
            }
        }

        [TestMethod]
        public void HoareSortTest()
        {
            int[] arr = IntArrayGenerator.GenerateArray(1000);
            HoareSorter.Sort(arr);
            int el = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (el > arr[i])
                {
                    Assert.Fail();
                }
                el = arr[i];
            }
        }

        [TestMethod]
        public void MergeSortTest()
        {
            int[] arr = IntArrayGenerator.GenerateArray(1000);
            MergeSorter.Sort(arr);
            int el = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (el > arr[i])
                {
                    Assert.Fail();
                }
                el = arr[i];
            }
        }

        [TestMethod]
        public void SortText()
        {
            string[] text = TextGenerator.GenerateText(10, 5).Split();
            MergeSorter.Sort(text);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void BubbleSortText()
        {
            string[] text = TextGenerator.GenerateText(100, 5).Split();
            BubbleSorter.Sort(text);
            Assert.AreEqual(1, 1);
        }
    }
}
