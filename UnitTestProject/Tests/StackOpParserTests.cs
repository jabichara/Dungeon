using ClassLibrary.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class StackOpParserTests
    {
        [TestMethod]
        public void Test()
        {
            StackOperationsParser op = new StackOperationsParser();
            string[] fdsa = null;
            op.Parse(fdsa);
        }
    }
}
