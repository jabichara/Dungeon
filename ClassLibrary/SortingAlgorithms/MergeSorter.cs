using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.SortingAlgorithms
{
    public class MergeSorter
    {
        #region IntSorter
        static int[] temporaryArray;

        public static void Sort(int[] array)
        {
            temporaryArray = new int[array.Length];
            MergeSort(array, 0, array.Length - 1);
        }

        static void Merge(int[] array, int start, int middle, int end)
        {
            var leftPtr = start;
            var rightPtr = middle + 1;
            var length = end - start + 1;
            for (int i = 0; i < length; i++)
            {
                if (rightPtr > end || (leftPtr <= middle && array[leftPtr] < array[rightPtr]))
                {
                    temporaryArray[i] = array[leftPtr];
                    leftPtr++;
                }
                else
                {
                    temporaryArray[i] = array[rightPtr];
                    rightPtr++;
                }
            }
            for (int i = 0; i < length; i++)
                array[i + start] = temporaryArray[i];
        }

        static void MergeSort(int[] array, int start, int end)
        {
            if (start == end) return;
            var middle = (start + end) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);
            Merge(array, start, middle, end);

        }
        #endregion

        #region StringSorter
        static string[] temporaryStringArray;

        public static void Sort(string[] array)
        {
            temporaryStringArray = new string[array.Length];
            MergeSort(array, 0, array.Length - 1);
        }

        static void Merge(string[] array, int start, int middle, int end)
        {
            var leftPtr = start;
            var rightPtr = middle + 1;
            var length = end - start + 1;
            for (int i = 0; i < length; i++)
            {
                if (rightPtr > end || (leftPtr <= middle && 
                    String.Compare(array[leftPtr], array[rightPtr]) < 0))
                {
                    temporaryStringArray[i] = array[leftPtr];
                    leftPtr++;
                }
                else
                {
                    temporaryStringArray[i] = array[rightPtr];
                    rightPtr++;
                }
            }
            for (int i = 0; i < length; i++)
                array[i + start] = temporaryStringArray[i];
        }

        static void MergeSort(string[] array, int start, int end)
        {
            if (start == end) return;
            var middle = (start + end) / 2;
            MergeSort(array, start, middle);
            MergeSort(array, middle + 1, end);
            Merge(array, start, middle, end);

        }
        #endregion
    }
}
