using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp.Folder;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual(1, Jojon.Increase(0));
        }

        [TestMethod]
        public void TestMethod2()
        {
            Assert.AreEqual(5, Jojon.Increase(4));
        }

        [TestMethod]
        public void TestMethod3()
        {
            Assert.AreEqual(100, Jojon.Increase(1));
        }
    }
}
