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
            List<ExpressionItem> output = new List<ExpressionItem>();
            foreach (string str in input)
            {
                str.Trim();
                str.ToLower();
            }
            char[] ex = input[0].ToCharArray();
            for (int i = 0; i < ex.Length; i++)
            {
                //(+, -, *, :, ^, ln, cos, sin, sqrt)
                switch (ex[i])
                {
                    case '+':
                        output.Add(new ExpressionItem(ItemType.Operation, Operation.Plus));
                        break;
                    case '-':
                        output.Add(new ExpressionItem(ItemType.Operation, Operation.Minus));
                        break;
                    case '*':
                        output.Add(new ExpressionItem(ItemType.Operation, Operation.Multiply));
                        break;
                    case ':':
                        output.Add(new ExpressionItem(ItemType.Operation, Operation.Divide));
                        break;
                    case '^':
                        output.Add(new ExpressionItem(ItemType.Operation, Operation.Power));
                        break;
                    case 'l':
                        //ln
                        if ((ex[i + 1]) == 'n')
                        {
                            i += 1;
                            output.Add(new ExpressionItem(ItemType.Operation, Operation.Logarithm));
                        }
                        else
                        {
                            AddValue('l', input, output);
                        }
                        break;
                    case 'c':
                        //cos
                        if ((ex[i + 1]) == 'o' && (ex[i + 2]) == 's')
                        {
                            i += 2;
                            output.Add(new ExpressionItem(ItemType.Operation, Operation.Cosine));
                        }
                        else
                        {
                            AddValue('l', input, output);
                        }
                        break;
                    case 's':
                        //sin
                        //sqrt
                        if ((ex[i + 1]) == 'i' && (ex[i + 2]) == 'n')
                        {
                            i += 2;
                            output.Add(new ExpressionItem(ItemType.Operation, Operation.Sine));
                        }
                        else if ((ex[i + 1]) == 'q' && (ex[i + 2]) == 'r' && (ex[i + 3]) == 't')
                        {
                            i += 3;
                            output.Add(new ExpressionItem(ItemType.Operation, Operation.SquareRoot));
                        }
                        else
                        {
                            AddValue('s', input, output);
                        }
                        break;
                    case '(':
                        output.Add(new ExpressionItem(ItemType.Bracket, Bracket.LeftBracket));
                        break;
                    case ')':
                        output.Add(new ExpressionItem(ItemType.Bracket, Bracket.RightBracket));
                        break;
                    default:
                        //number
                        if (char.IsNumber(ex[i]))
                        {
                            StringBuilder sb = new StringBuilder();
                            while (i < ex.Length && (char.IsNumber(ex[i]) || ex[i] == '.'))
                            {
                                sb.Append(ex[i]);
                                i++;
                            }
                            i--;
                            output.Add(new ExpressionItem(ItemType.Number,
                                double.Parse(sb.ToString())));
                        }
                        else
                        {

                            AddValue(ex[i], input, output);
                        }
                        break;
                }
            }
            return output;
        }

        void AddValue(char variable, string[] input, List<ExpressionItem> output)
        {
            for (int i = 1; i < input.Length; i++)
            {
                if (input[i][0] == variable)
                {
                    output.Add(new ExpressionItem(ItemType.Number,
                        double.Parse(input[i].Substring(2))));
                    break;
                }
            }
        }
    }

    public class ExpressionItem
    {
        ItemType Type { get; set; }
        double? NumberValue { get; set; } = null;
        Operation? OperationType { get; set; } = null;
        Bracket? BraketType { get; set; } = null;

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
