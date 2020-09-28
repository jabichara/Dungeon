using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Measurers
{
    public class ActionTimeMeasurer
    {
		public static long Measure(Action action)
		{
			var watch = new Stopwatch();
			watch.Start();
			action.Invoke();
			watch.Stop();
			return watch.ElapsedMilliseconds;
		}
	}
}
