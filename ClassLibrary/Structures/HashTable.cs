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
        string 
    }
}
