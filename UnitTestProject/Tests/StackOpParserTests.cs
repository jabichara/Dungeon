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
            /// Example: 
            /// Input: "3 1,56 1,cat" 
            /// Returns: { (StackCommand.Top, null), 
            /// (StackCommand.Push, 56), (StackCommand.Push, "cat") }
            StackOperationsParser op = new StackOperationsParser();
            string[] input = new string[] { "3 1,56 1,cat" };
            List<StackOperation> expected = new List<StackOperation>
            {
                new StackOperation(StackCommand.Top, null),
                new StackOperation(StackCommand.Push, 56),
                new StackOperation(StackCommand.Push, "cat")
            };
            List<StackOperation> actual = op.Parse(input);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void Test2()
        {
            StackOperationsParser op = new StackOperationsParser();
            string[] input = new string[] 
            { 
                "4 1,432.543", 
                "3 2 1,joska 4 5"
            };
            List<StackOperation> expected = new List<StackOperation>
            {
                new StackOperation(StackCommand.isEmpty, null),
                new StackOperation(StackCommand.Push, 432.543),
                new StackOperation(StackCommand.Top, null),
                new StackOperation(StackCommand.Pop, null),
                new StackOperation(StackCommand.Push, "joska"),
                new StackOperation(StackCommand.isEmpty, null),
                new StackOperation(StackCommand.Print, null)
            };
            List<StackOperation> actual = op.Parse(input);
            Assert.AreEqual(1, 1);
        }
    }
}
