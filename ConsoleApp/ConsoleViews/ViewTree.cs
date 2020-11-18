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
    public class ViewTree
    {
        public static void Show()
        {
            //var tree = new RBTree();
            //tree.Add(5);
            //tree.Add(3);
            //tree.Add(6);
            //tree.Add(7);
            //tree.Add(2);
            //tree.Add(4);
            //tree.Add(5);
            //tree.Add(9);
            //tree.Add(1);
            //tree.Add(2);
            //tree.Add(3);
            //tree.Add(4);
            //tree.Add(5);
            //tree.Add(6);
            //Random rnd = new Random();
            //for (int i = 0; i < 10; i++)
            //{
            //    tree.Add(rnd.Next(1, 5));
            //}

            //ShowTree(tree);

            //while (true)
            //{

            //    ShowTree();
            //}
        }

        //public static void ShowTree(RBTree tree)
        //{
        //    List<List<Node>> e = tree.GetTree();
        //    int treeHeight = e.Count;
        //    int countOfLeftSpace = 0;
        //    int countBetweenSpace = 1;
        //    List<string> levels = new List<string>();
        //    for (int i = e.Count - 1; i >= 0; i--)
        //    {
        //        List<Node> level = e[i];
        //        StringBuilder sb = new StringBuilder();
        //        for (int j = 0; j < countOfLeftSpace; j++)
        //        {
        //            sb.Append(" ");
        //        }
        //        countOfLeftSpace = (countOfLeftSpace * 2) + 1;

        //        for (int j = 0; j < level.Count; j++)
        //        {
        //            if (level[j] != null)
        //            {
        //                sb.Append(level[j].Value);
        //            }
        //            else
        //            {
        //                sb.Append(" ");
        //            }
        //            for (int n = 0; n < countBetweenSpace; n++)
        //            {
        //                sb.Append(" ");
        //            }
        //        }
        //        countBetweenSpace = (countOfLeftSpace * 2) + 1;
        //        levels.Add(sb.ToString());
        //    }
        //    levels.Reverse();
        //    foreach (string level in levels)
        //    {
        //        Console.WriteLine(level);
        //    }
        //}
    }
}
