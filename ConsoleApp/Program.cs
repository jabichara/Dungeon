﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary.Measurers;
using ClassLibrary.Algorithms;
using ClassLibrary.Generators;
using ConsoleApp.ConsoleViews;
using ClassLibrary.Parsers;
using ClassLibrary.Structures;
using System.Net;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            //Console.SetBufferSize(Console.BufferWidth, 32766);
            //MeasureStackOperations.Show();
            //CalculatingInfixToPostfix.Show();
            //Console.ReadKey();
            ViewTree.ShowTree();
            Console.WriteLine();
            Console.WriteLine("Minimum - " + tree.Root.Value);
            Console.ReadLine();
        }
    }
}
