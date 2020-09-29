using ClassLibrary.Measurers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UnitTestProject
{
    [TestClass]
    public class MeasurerTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            long time = ActionTimeMeasurer.Measure(new Action(() => { Thread.Sleep(1000); }));
            Assert.AreEqual(1000, time);
        }

        [TestMethod]
        public void TestMethod2()
        {
            long time = ActionTimeMeasurer.Measure(new Action(() => { Thread.Sleep(100); }));
            Assert.AreEqual(100, time);
        }

        [TestMethod]
        public void TestMethod3()
        {
            long time = ActionTimeMeasurer.Measure(new Action(() => { Thread.Sleep(18000); }));
            Assert.AreEqual(18000, time);
        }
    }
}
