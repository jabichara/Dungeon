using ClassLibrary.Structures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class StackTests
    {
        [TestMethod]
        public void Test()
        {
            StackRealization<object> sr = new StackRealization<object>();
            string str = "fdsa";
            int i = 5243;
            sr.Push(str);
            sr.Push(i);
            Assert.AreEqual(i, sr.Top());
        }

        [TestMethod]
        public void Test2()
        {
            StackRealization<object> sr = new StackRealization<object>();
            string str = "fdsa";
            sr.Push(str);
            Assert.AreEqual(str, sr.Pop()); 
        }

        [TestMethod]
        public void Test3()
        {
            StackRealization<object> sr = new StackRealization<object>();
            Assert.ThrowsException<NullReferenceException>(new Action(() => sr.Pop()));
        }

        [TestMethod]
        public void Test4()
        {
            StackRealization<object> sr = new StackRealization<object>();
            string str = "fdsa";
            int i = 5243;
            sr.Push(str);
            sr.Push(i);
            object[] afsd = sr.Print();
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void Test5()
        {
            StackRealization<object> sr = new StackRealization<object>();
            Assert.AreEqual(true, sr.IsEmpty());
        }
    }
}
