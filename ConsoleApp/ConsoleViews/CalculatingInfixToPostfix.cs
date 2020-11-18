using ClassLibrary.Algorithms;
using ClassLibrary.Parsers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleViews
{
    class CalculatingInfixToPostfix
    {
        public static void Show()
        {
            string pathToFolder = Directory.GetCurrentDirectory()
                .Replace(@"bin\Debug", "") + @"FilesSecond\";
            string[] text = File.ReadAllLines(pathToFolder + "input" + ".txt");
            var parser = new InfixConvParser();
            var parseText = parser.Parse(text);
            var infixAlg = new InfixСonversion();
            var postfix = infixAlg.InfixToPostfix(parseText);
            var answer = infixAlg.CalculateValue(postfix);
            var sb = new StringBuilder();
            foreach (var e in postfix)
            {
                switch (e.Type)
                {
                    case ItemType.Bracket:
                        if (e.BraketType == Bracket.LeftBracket)
                            sb.Append("(");
                        else if (e.BraketType == Bracket.RightBracket)
                            sb.Append(")");
                        break;
                    case ItemType.Number:
                        sb.Append(e.NumberValue);
                        break;
                    case ItemType.Operation:
                        switch(e.OperationType)
                        {
                            case Operation.Cosine:
                                sb.Append("cos");
                                break;
                            case Operation.Divide:
                                sb.Append(":");
                                break;
                            case Operation.Logarithm:
                                sb.Append("lg");
                                break;
                            case Operation.Minus:
                                sb.Append("-");
                                break;
                            case Operation.Multiply:
                                sb.Append("*");
                                break;
                            case Operation.Plus:
                                sb.Append("+");
                                break;
                            case Operation.Power:
                                sb.Append("^");
                                break;
                            case Operation.Sine:
                                sb.Append("sin");
                                break;
                            case Operation.SquareRoot:
                                sb.Append("sqrt");
                                break;
                        }
                        break;
                }
                sb.Append(" ");
            }
            var prefixStr = sb.ToString();
            Console.WriteLine("Префиксная запись - " + text[0]);
            for (int i = 1; i < text.Count(); i++)
                Console.WriteLine(text[i]);
            Console.WriteLine("Результат в постфиксной записи - " + prefixStr);
            Console.WriteLine("Ответ: " + answer + ".");
        }
    }
}
