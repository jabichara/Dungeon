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

namespace ConsoleApp.ConsoleViews
{
    class ViewTree
    {
        public static void ShowTree()
        {
            var tree = new RBTree();
            tree.Add(5);
            tree.Add(3);
            tree.Add(6);
            tree.Add(7);
            tree.Add(2);
            tree.Add(4);
            tree.Add(5);
            tree.Add(9);
            var e = tree.DisplayTree();
        }
    }
}
