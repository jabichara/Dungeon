using ClassLibrary.Generators;
using ClassLibrary.Measurers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class GeneratorsTests
    {
        [TestMethod]
        public void TestMethod1()
        {
            int[] arr = IntArrayGenerator.GenerateArray(10000);
            Assert.AreEqual(1, 1);
        }
    }
}
