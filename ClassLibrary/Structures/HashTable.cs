using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Structures
{

    public class HashTable
    {
        public long MaxCount { get; set; }

        public HashTable(long maxCount)
        {
            MaxCount = maxCount;
        }

        public bool Insert(MovieInfo movie)
        {
            return false;
        }

        public bool Remove()
        {
            return false;
        }

        public bool Search(out MovieInfo movie)
        {
            movie = default(MovieInfo);
            return false;
        }

        public long GetHash(string movieName)
        {
            long hash = 0;
            var rnd = new Random();
            var a = rnd.Next(100);
            var b = rnd.Next(200);
            var c = rnd.Next(500, 1000);
            long k = (long)(Math.Pow(a, rnd.Next(5)) + Math.Sqrt(b) * rnd.Next(200, 1000) * c);
            foreach (char ch in movieName)
            {
                hash += Convert.ToInt16(c) * k;
            }
            while (hash > MaxCount)
                hash /= 2;
            return hash;
        }
    }


    public class MovieInfo
    {
        public string Name { get; set; }
        public string Format { get; set; }
        public long Size { get; set; }
        public string Link { get; set; }

        public MovieInfo(string name, string format, long size, string link)
        {
            Name = name;
            Format = format;
            Size = size;
            Link = link;
        }

        readonly string[] formats = new string[] { "mp4", "mov", "wmv", "flv", "avi", "avchd", "mkv" };
        public static List<MovieInfo> GetBaseMovies()
        {
            var rnd = new Random();
            string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var englishChars = new char[letters.Length];
            for (int i = 0; i < letters.Length; i++)
                englishChars.Append(letters[i]);
            var baseMovies = new List<MovieInfo>();
            for (int i = 0; i < 100000; i++)
            {
                var name = new StringBuilder();
                for (int j = 3; j < rnd.Next(7, 15); j++)
                {
                    var rndChar = rnd.Next(52);
                    name.Append(englishChars[rndChar]);
                }
                var format = formats[rnd.Next(7)];
                var size = rnd.Next(1000, 10000000);
                var link = new StringBuilder();
                link.Append("http://");
                for (int j = 0; j < rnd.Next(7,15); j++)
                {
                    var rndChar = rnd.Next(52);
                    link.Append(englishChars[rndChar]);
                }
                link.Append(".ru");
                baseMovies.Add(new MovieInfo(name.ToString(), format, size, link.ToString()));
            }
            return baseMovies;
        }
    }
}
