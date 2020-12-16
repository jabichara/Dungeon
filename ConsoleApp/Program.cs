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
            var hash = new HashTable(1000000);
            Console.WriteLine(hash.GetHash(new HashTable.MovieInfo("dasaf", "safsdfdsfd", 14122, "eGESGSES")));
        }
    }
}
