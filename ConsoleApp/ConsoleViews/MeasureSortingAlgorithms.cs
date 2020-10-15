using ClassLibrary.Generators;
using ClassLibrary.Measurers;
using ClassLibrary.Algorithms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleViews
{
    public class MeasureSortingAlgorithms
    {
        public static void Show()
        {
            int[] arr = new int[] 
            {
                10000, 20000, 30000, 40000, 50000,
                100000, 200000, 500000,
                1000000, 2000000, 5000000, 10000000,
                100000000
            };

            foreach (int i in arr)
            {
                Console.WriteLine("Длина массива - " + i);

                int[] array = IntArrayGenerator.GenerateArray(i);
                Console.WriteLine("быстрая сортировка " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    HoareSorter.Sort(array))));

                array = IntArrayGenerator.GenerateArray(i);
                Console.WriteLine("встроенная сортировка " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    Array.Sort(array))));

                array = IntArrayGenerator.GenerateArray(i);
                Console.WriteLine("сортировка слиянием " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    MergeSorter.Sort(array))));
                GC.Collect();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
