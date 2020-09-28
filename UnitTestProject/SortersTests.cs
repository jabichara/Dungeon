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
    public class SortersTests
    {
        [TestMethod]
        public void BubbleSortTest()
        {
            int[] arr = IntArrayGenerator.GenerateArray(1000);
            BubbleSorter.BubbleSort(arr);
            int el = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (el == arr[i])
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
            HoareSorter.HoareSort(arr);
            int el = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (el == arr[i])
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
            MergeSorter.MergeSort(arr);
            int el = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (el == arr[i])
                {
                    Assert.Fail();
                }
                el = arr[i];
            }
        }
    }
}
