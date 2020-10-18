using ClassLibrary.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestProject.Tests
{
    [TestClass]
    public class InfixConvParserTests
    {
        [TestMethod]
        public void Test()
        {
            /// Example: 
            /// Input: "a+b-100
            ///         a=12
            ///         b=13"
            /// Returns: { (Number, 12), (Operation, Plus), (Number, 13), 
            /// (Operation, Minus), (Number, 100) }
            /// </remarks>
            InfixConvParser icp = new InfixConvParser();
            string[] input = new string[] 
            { 
                "a+b-100",
                "a=12",
                "b=13"
            };
            List<ExpressionItem> expected = new List<ExpressionItem>
            {
                new ExpressionItem(ItemType.Number, 12),
                new ExpressionItem(ItemType.Operation, Operation.Plus),
                new ExpressionItem(ItemType.Number, 13),
                new ExpressionItem(ItemType.Operation, Operation.Minus),
                new ExpressionItem(ItemType.Number, 100)
            };
            List<ExpressionItem> actual = icp.Parse(input);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Test2()
        {
            InfixConvParser icp = new InfixConvParser();
            string[] input = new string[]
            {
                "ln(a)*(b+cos(90))",
                "a=12",
                "b=13"
            };
            List<ExpressionItem> expected = new List<ExpressionItem>
            {
                new ExpressionItem(ItemType.Operation, Operation.Logarithm),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 12),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
                new ExpressionItem(ItemType.Operation, Operation.Multiply),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 13),
                new ExpressionItem(ItemType.Operation, Operation.Plus),
                new ExpressionItem(ItemType.Operation, Operation.Cosine),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 90),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
            };
            List<ExpressionItem> actual = icp.Parse(input);
            Assert.AreEqual(expected, actual);
        }
    }
}
