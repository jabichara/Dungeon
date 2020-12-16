using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Structures
{

    public class HashTable<MovieInfo>
    {
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

        public int GetHash(MovieInfo movie)
        {

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
        public string Key { get; set; }
        public long Size { get; set; }
        public string Format { get; set; }
        public string Link { get; set; }

        public M
    }
}
