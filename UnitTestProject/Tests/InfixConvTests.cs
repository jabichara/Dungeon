using ClassLibrary.Algorithms;
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
    public class InfixConvTests
    {
        [TestMethod]
        public void Test()
        {
            InfixСonversion ic = new InfixСonversion();
            List<ExpressionItem> ei = new List<ExpressionItem>
            {
                //"ln(12)*(13+cos(90))",
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
            ei = new List<ExpressionItem>
            {
                //cos(a+b/sqrt(d^2))
                //a = 45
                //b = 450
                //d = 10
                new ExpressionItem(ItemType.Operation, Operation.Cosine),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 45),
                new ExpressionItem(ItemType.Operation, Operation.Plus),
                new ExpressionItem(ItemType.Number, 450),
                new ExpressionItem(ItemType.Operation, Operation.Divide),
                new ExpressionItem(ItemType.Operation, Operation.SquareRoot),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 10),
                new ExpressionItem(ItemType.Operation, Operation.Power),
                new ExpressionItem(ItemType.Number, 2),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
            };
            List<ExpressionItem> qe = ic.InfixToPostfix(ei);
            Assert.AreEqual(1, 1);
        }

        [TestMethod]
        public void Test2()
        {
            InfixСonversion ic = new InfixСonversion();
            List<ExpressionItem> ei = new List<ExpressionItem>
            {
                //"cos(130+140/sqrt(13^2))",
                new ExpressionItem(ItemType.Operation, Operation.Cosine),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 45),
                new ExpressionItem(ItemType.Operation, Operation.Plus),
                new ExpressionItem(ItemType.Number, 450),
                new ExpressionItem(ItemType.Operation, Operation.Divide),
                new ExpressionItem(ItemType.Operation, Operation.SquareRoot),
                new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket),
                new ExpressionItem(ItemType.Number, 10),
                new ExpressionItem(ItemType.Operation, Operation.Power),
                new ExpressionItem(ItemType.Number, 2),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
                new ExpressionItem(ItemType.Bracket, Bracket.RightBracket),
            };
            ei = ic.InfixToPostfix(ei);
            double calc = ic.CalculateValue(ei);
            Assert.AreEqual(1, 1);
        }
    }
}
