using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Parsers
{
    public class InfixConvParser
    {
        /// <summary>
        /// Parse from text to expression items.
        /// </summary>
        /// <remarks>
        /// Example: 
        /// Input: "a+b-100
        ///         a=12
        ///         b=13"
        /// Returns: { (Number, 12), (Operation, Plus), (Number, 13), 
        /// (Operation, Minus), (Number, 100) }
        /// </remarks>
        public List<ExpressionItem> Parse(string[] input)
        {

            throw new Exception();
        }
    }

    public class ExpressionItem
    {
        ItemType Type { get; set; }
        double NumberValue { get; set; }
        Operation OperationType { get; set; }
        Bracket BraketType { get; set; }

        public ExpressionItem(ItemType type, Operation operation)
        {
            Type = type;
            OperationType = operation;
        }

        public ExpressionItem(ItemType type, Bracket bracket)
        {
            Type = type;
            BraketType = bracket;
        }

        public ExpressionItem(ItemType type, double numberValue)
        {
            Type = type;
            NumberValue = numberValue;
        }
    }

    public enum ItemType
    {
        Number,
        Bracket,
        Operation
    }

    public enum Bracket
    {
        LeftBracket,
        RightBracket
    }

    public enum Operation
    {
        Plus,
        Minus,
        Multiply,
        Divide,
        Power,
        Logarithm,
        Cosine,
        Sine,
        SquareRoot
    }
}
