using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class Random
    {
        [TestMethod]
        public void Kavo()
        {
            int i = 0;
            if (i++ == 1)
                i = 10;
            Assert.AreEqual(3, i);
        }
    }
}
