using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Measurers;
using ClassLibrary.SortingAlgorithms;
using ClassLibrary.Generators;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            for (int i = 0; i < 100; i++)
            {
                int[] array = IntArrayGenerator.GenerateArray(10000);
                Console.WriteLine("попытка " + i + ", время выполнения - " +
                    ActionTimeMeasurer.Measure(new Action(() => 
                    BubbleSorter.BubbleSort(array))));
            }
            Console.ReadKey();
        }
    }
}
