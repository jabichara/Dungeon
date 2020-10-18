using ClassLibrary.Measurers;
using ClassLibrary.Parsers;
using ClassLibrary.Structures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleViews
{
    public class MeasureStackOperations
    {
        public static void Show()
        {
            string pathToFolder = Directory.GetCurrentDirectory()
                .Replace(@"bin\Debug", "") + @"Files\";
            for (int i = 1; i < 6; i++)
            {
                string[] text = File.ReadAllLines(pathToFolder + "input" + i + "txt");
                StackOperationsParser sop = new StackOperationsParser();
                List<StackOperation> operations = sop.Parse(text);
                StackRealization<object> stack = new StackRealization<object>();
                foreach (StackOperation operation in operations)
                {
                    switch (operation.Command)
                    {
                        case StackCommand.Push:
                            long executionTime = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Push(operation.Object)));
                            Console.WriteLine("Команда: Push(" + operation.Object + ")");
                            Console.WriteLine("Время выполнения: " + executionTime);
                            break;
                        case StackCommand.Pop:
                            long executionTime2 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Pop()));
                            Console.WriteLine("Команда: Pop()");
                            Console.WriteLine("Возвращенное значeние: " + stack.Pop());
                            Console.WriteLine("Время выполнения: " + executionTime2);
                            break;
                        case StackCommand.Top:
                            long executionTime3 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Top()));
                            Console.WriteLine("Команда: Top()");
                            Console.WriteLine("Возвращенное значeние: " + stack.Top());
                            Console.WriteLine("Время выполнения: " + executionTime3);
                            break;
                        case StackCommand.isEmpty:
                            long executionTime4 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.IsEmpty()));
                            Console.WriteLine("Команда: IsEmpty()");
                            Console.WriteLine("Возвращенное значeние: " + stack.IsEmpty());
                            Console.WriteLine("Время выполнения: " + executionTime4);
                            break;
                        case StackCommand.Print:
                            long executionTime5 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Print()));
                            Console.WriteLine("Команда: Print()");
                            Console.WriteLine("Время выполнения: " + executionTime5);
                            break;
                        default:
                            throw new Exception();
                    }
                    string stackСondition = ObjectsToString(stack.Print());
                    Console.WriteLine("Состояние стека: " + stackСondition);
                    Console.WriteLine();
                }
            }
        }

        static string ObjectsToString(object[] objects)
        {
            StringBuilder sb = new StringBuilder();
            foreach (object obj in objects)
            {
                sb.Append(obj);
                sb.Append(" ");
            }
            return sb.ToString();
        }
    }
}
