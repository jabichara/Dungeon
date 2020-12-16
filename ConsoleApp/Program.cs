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
using System.Collections;

namespace ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var MovArray = MovInfGenerator.GenerateMovArray(1000000);
            HashTable Database = new HashTable(1000000);
            foreach (MovieInfo movie in MovArray)
            {
                Database.Insert(movie);
            }
            Console.ReadLine();
        }
    }
}
