﻿using ClassLibrary.Measurers;
using ClassLibrary.Parsers;
using ClassLibrary.Structures;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp.ConsoleViews
{
    public class MeasureStackOperations
    {
        public static void Show()
        {
            string pathToFolder = Directory.GetCurrentDirectory()
                .Replace(@"bin\Debug", "") + @"Files\";
            var countFiles = new DirectoryInfo(pathToFolder).GetFiles().Length;
            Console.WriteLine("---------------------------------------------------");
            for (int i = 1; i <= countFiles; i++)
            {
                string[] text = File.ReadAllLines(pathToFolder + "input" + i + ".txt");
                StackOperationsParser sop = new StackOperationsParser();
                List<StackOperation> operations = sop.Parse(text);
                Console.WriteLine("input" + i + ".txt");
                Console.WriteLine("Время на считывание - " + ActionTimeMeasurer.Measure
                    (new Action(() => sop.Parse(text))));
                Console.WriteLine();
                StackRealization<object> stack = new StackRealization<object>();
                var watch = new Stopwatch();
                foreach (StackOperation operation in operations)
                {
                    switch (operation.Command)
                    {
                        case StackCommand.Push:
                            watch.Start();
                            long executionTime = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Push(operation.Object)));
                            watch.Stop();
                            Console.WriteLine("Команда: Push(" + operation.Object + ")");
                            Console.WriteLine("Время выполнения: " + executionTime);
                            break;
                        case StackCommand.Pop:
                            var saveElement = stack.Top();
                            watch.Start();
                            long executionTime2 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Pop()));
                            watch.Stop();
                            Console.WriteLine("Команда: Pop()");
                            Console.WriteLine("Возвращенное значeние: " + saveElement);
                            Console.WriteLine("Время выполнения: " + executionTime2);
                            break;
                        case StackCommand.Top:
                            watch.Start();
                            long executionTime3 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Top()));
                            watch.Stop();
                            Console.WriteLine("Команда: Top()");
                            Console.WriteLine("Возвращенное значeние: " + stack.Top());
                            Console.WriteLine("Время выполнения: " + executionTime3);
                            break;
                        case StackCommand.isEmpty:
                            watch.Start();
                            long executionTime4 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.IsEmpty()));
                            watch.Stop();
                            Console.WriteLine("Команда: IsEmpty()");
                            Console.WriteLine("Возвращенное значeние: " + stack.IsEmpty());
                            Console.WriteLine("Время выполнения: " + executionTime4);
                            break;
                        case StackCommand.Print:
                            watch.Start();
                            long executionTime5 = ActionTimeMeasurer.Measure
                                (new Action(() => stack.Print()));
                            watch.Stop();
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
                Console.WriteLine("Время на выполнение - " + watch.ElapsedMilliseconds);
                Console.WriteLine("---------------------------------------------------");
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
