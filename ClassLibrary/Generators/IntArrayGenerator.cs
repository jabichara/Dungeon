using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Generators
{
    public class IntArrayGenerator
    {
		readonly static Random rnd = new Random();

		public static int[] GenerateSortedArray(int length)
		{
			var array = new int[length];
			for (int i = 1; i < array.Length; i++)
				array[i] = array[i - 1] + rnd.Next(10000) + 1;
			return array;
		}

		public static int[] GenerateArray(int length)
		{
			var array = new int[length];
			for (int i = 0; i < array.Length; i++)
				array[i] = rnd.Next();
			return array;
		}
	}
}
