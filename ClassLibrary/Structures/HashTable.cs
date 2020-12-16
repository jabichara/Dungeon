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

        public long GetHash(MovieInfo movie)
        {
            long hash = 0;
            var rnd = new Random();
            foreach (char c in movie.Name)
            {
                hash += Convert.ToInt16(c)*rnd.Next(1000);
            }
            foreach (char c in movie.Link)
            {
                hash += Convert.ToInt16(c)*rnd.Next(150);
            }
            foreach (char c in movie.Format)
            {
                hash += Convert.ToInt16(c)*rnd.Next(50);
            }
            hash += movie.Size;
            while (hash > MaxCount)
                hash /= 2;
            return hash;
        }


        public class MovieInfo
        {
            public string Name { get; set; }
            public string Format { get; set; }
            public long Size { get; set; }
            public string Link { get; set; }

            public MovieInfo(string name, string link, long size, string format)
            {
                Name = name;
                Link = link;
                Size = size;
                Format = format;
            }
        }
    }
}
