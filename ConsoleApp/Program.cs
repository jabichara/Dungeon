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
            Set<int> S = new Set<int>();

            //for (int i = 0; i < 10; i++)
            //S.Add(new Random().Next(30));
            S.Add(6);
            S.Add(7);
            S.Add(9);
            S.Add(13);
            S.Add(14);
            S.Add(15);
            S.Add(17);
            S.Add(19);
            S.Add(25);
            S.Add(29);

            Console.WriteLine("Depth = {0}", S.Depth);

            S.Validate();

          //  for (int i = 0; i < 10; i += 2)
       //         S.Remove(i);

            Console.WriteLine("Depth = {0}", S.Depth);

            S.Validate();

            foreach (var Str in S)
                Console.WriteLine("{0}", Str);

            if (S[3])
                Console.WriteLine("{0} is in {1}", 3.ToString(), S);
            else
                Console.WriteLine("{0} is not in {1}", 3.ToString(), S);
            ViewTree.Show();
            Console.ReadLine();
        }
    }
}
