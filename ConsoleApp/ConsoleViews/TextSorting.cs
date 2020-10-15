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
    public class TextSorting
    {
        public static void Show()
        {
            int[] arr = new int[]
            {
                100, 500, 
                1000, 2000, 5000
            };

            foreach (int i in arr)
            {
                Console.WriteLine("Длина массива - " + i);

                string[] array = TextGenerator.GenerateText(i).Split();
                Console.WriteLine("сортировка пузырьком O(n^2) " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    BubbleSorter.Sort(array))));

                array = TextGenerator.GenerateText(i).Split();
                Console.WriteLine("сортировка вставками O(log(n)) " + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() =>
                    MergeSorter.Sort(array))));

                GC.Collect();
                Console.WriteLine();
            }

            Console.ReadKey();
        }
    }
}
