using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Structures
{

    public class HashTable<MovieInfo>
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
            return 0;
        }
    }

    public class HashTableItem<T>
    {
        public int Index { get; set; }
        public T Value { get; set; }
        public T Next { get; set; }
    }

    public class MovieInfo
    {
        string Name { get; set; }
        string Format { get; set; }
        long Size { get; set; }
        string Link { get; set; }

        public MovieInfo(string name, string format, long size, string link)
        {
            Name = name;
            Format = format;
            Size = size;
            Link = link;
        }
    }
}
