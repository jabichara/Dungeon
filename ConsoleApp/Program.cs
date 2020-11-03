using System;
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
            RB tree = new RB();
            tree.Insert(5);
            tree.Insert(3);
            tree.Insert(7);
            tree.Insert(1);
            tree.Insert(9);
            tree.Insert(-1);
            tree.Insert(11);
            tree.Insert(6);
            tree.DisplayTree();
            tree.Delete(-1);
            tree.DisplayTree();
            tree.Delete(9);
            tree.DisplayTree();
            tree.Delete(5);
            tree.DisplayTree();
            Console.WriteLine();
            Console.WriteLine("Minimum - " + tree.root.data);
            Console.ReadLine();
        }
    }
}
