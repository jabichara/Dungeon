using ClassLibrary.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Algorithms
{
    public class InfixСonversion
    {
        public List<ExpressionItem> InfixToPostfix(List<ExpressionItem> infixExp)
        {
            //http://aliev.me/runestone/BasicDS/InfixPrefixandPostfixExpressions.html
            //https://habr.com/ru/post/489744/
            Stack<ExpressionItem> stack = new Stack<ExpressionItem>();
            Queue<ExpressionItem> queue = new Queue<ExpressionItem>();
            foreach (ExpressionItem item in infixExp)
            {
                switch (item.Type)
                {
                    case ItemType.Number:
                        queue.Enqueue(item);
                        break;
                    case ItemType.Operation:
                        if (GetPriority(item) == 0)
                        {
                            stack.Push(item);
                        }
                        else
                        {
                            int currentPriority = GetPriority(item);
                            while (stack.Count > 0
                                && (stack.Peek().Type == ItemType.Operation 
                                && GetPriority(stack.Peek()) == 0
                                || GetPriority(stack.Peek()) > currentPriority))
                            {
                                queue.Enqueue(stack.Pop());
                            }
                            stack.Push(item);
                        }
                        break;
                    case ItemType.Bracket:
                        if (item.BraketType == Bracket.LeftBracket)
                        {
                            stack.Push(item);
                        }
                        else
                        {
                            ExpressionItem el = stack.Pop();
                            while (el.BraketType != Bracket.LeftBracket)
                            {
                                queue.Enqueue(el);
                                if (stack.Count == 0) throw new Exception();
                                el = stack.Pop();
                            }
                        }
                        break;
                }
            }
            while (stack.Count != 0)
            {
                queue.Enqueue(stack.Pop());
            }
            return queue.ToList();
        }

        public double CalculateValue(List<ExpressionItem> postfixExp)
        {
            //List<ExpressionItem> xu = InfixToPostfix(infixExp);
            Stack<ExpressionItem> stack = new Stack<ExpressionItem>();
            foreach(var item in postfixExp)
            {
                switch (item.Type)
                {
                    case ItemType.Number:
                        stack.Push(item);
                        break;
                    case ItemType.Operation:
                        if (GetPriority(item) > 0)
                        {
                            double numberSecond = (double)stack.Pop().NumberValue;
                            double numberFirst = (double)stack.Pop().NumberValue;
                            switch (item.OperationType)
                            {
                                case Operation.Plus:
                                    stack.Push(new ExpressionItem(ItemType.Number, numberFirst + numberSecond));
                                    break;
                                case Operation.Minus:
                                    stack.Push(new ExpressionItem(ItemType.Number, numberFirst - numberSecond));
                                    break;
                                case Operation.Multiply:
                                    stack.Push(new ExpressionItem(ItemType.Number, numberFirst * numberSecond));
                                    break;
                                case Operation.Divide:
                                    stack.Push(new ExpressionItem(ItemType.Number, numberFirst / numberSecond));
                                    break;
                                case Operation.Power:
                                    stack.Push(new ExpressionItem(ItemType.Number, Math.Pow(numberFirst, numberSecond)));
                                    break;
                            }                         
                        }
                        else
                        {
                            double number = (double)stack.Pop().NumberValue;
                            switch (item.OperationType)
                            {
                                case Operation.Sine:
                                    stack.Push(new ExpressionItem(ItemType.Number, Math.Sin((number * Math.PI) / 180)));
                                    break;
                                case Operation.Cosine:
                                    stack.Push(new ExpressionItem(ItemType.Number, Math.Cos((number * Math.PI) / 180)));
                                    break;
                                case Operation.Logarithm:
                                    stack.Push(new ExpressionItem(ItemType.Number, Math.Log(number)));
                                    break;
                                case Operation.SquareRoot:
                                    stack.Push(new ExpressionItem(ItemType.Number, Math.Sqrt(number)));
                                    break;
                            }

                        }
                        break;
                }
            }
            return Math.Round((double)stack.Pop().NumberValue);
        }

        int GetPriority(ExpressionItem ei)
        {
            if (ei.OperationType == Operation.Plus 
                || ei.OperationType == Operation.Minus) return 1;
            if (ei.OperationType == Operation.Multiply 
                || ei.OperationType == Operation.Divide) return 2;
            if (ei.OperationType == Operation.Power) return 3;
            return 0;
        }
    }
}
