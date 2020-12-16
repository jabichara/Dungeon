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
            var MovArray = MovInfGenerator.GenerateMovArray(100);
            HashTable Database = new HashTable(1000);
            foreach (MovieInfo movie in MovArray)
            {
                Database.Insert(movie);
            }
            Database.Insert(new MovieInfo("Jopa", ".jp", 100, "www.jopa.com"));
            //for (int i = 0; i < 1000; i++)
            //{
            //    Console.WriteLine(Database.GetHash("Jopa"));
            //}
            while (true)
            {
                string input = Console.ReadLine();
                string[] parts = input.Split(' ');
                if (input.Substring(0,7) == "delete ")
                {
                    if (Database.Remove(parts[1]))
                    {
                        Console.WriteLine("удалено " + parts[1]);
                    }
                }
                else if (input.Substring(0, 7) == "search ")
                {
                    MovieInfo mi;
                    if (Database.Search(parts[1], out mi))
                    {
                        Console.WriteLine(mi.Name);
                        Console.WriteLine(mi.Link);
                        Console.WriteLine(mi.Size);
                        Console.WriteLine(mi.Format);
                    }
                }
                else if (input.Substring(0, 7) == "insert ")
                {
                    if (parts.Length < 5)
                    {
                        Console.WriteLine("Инвалидная команда, надо 4 параметра");
                    }
                    long size;
                    if (long.TryParse(parts[3], out size) &&
                        Database.Insert(new MovieInfo(parts[1], parts[2], size, parts[4])))
                    {
                        Console.WriteLine("Успешно добавлено " + parts[1]);
                    }
                }
                else
                {
                    Console.WriteLine("Инвалидная команда");
                }
            }
        }
    }
}
