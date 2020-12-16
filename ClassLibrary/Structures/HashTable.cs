﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Structures
{

    public class HashTable
    {
        public long MaxCount { get; set; }
        public MovieInfo[] Values { get; set; }

        public HashTable(long maxCount)
        {
            MaxCount = maxCount;
            Values = new MovieInfo[maxCount];
        }

        public bool Insert(MovieInfo movie)
        {
            if (movie == null)
            {
                throw new Exception();
            }
            long hash = GetHash(movie.Name);
            for (long i = hash; i < Values.Length; i++)
            {
                if (Values[i] == null)
                {
                    Values[i] = movie;
                    return true;
                }
            }
            return false;
        }

        public bool Remove(string movieName)
        {
            long hash = GetHash(movieName);
            for (long i = hash; i < Values.Length; i++)
            {
                if (movieName.Equals(Values[i].Name))
                {
                    Values[i] = null;
                    return true;
                }
            }
            return false;
        }

        public bool Search(string movieName, out MovieInfo found)
        {
            long hash = GetHash(movieName);
            for (long i = hash; i < Values.Length; i++)
            {
                if (movieName.Equals(Values[i].Name))
                {
                    found = Values[i];
                    return true;
                }
            }
            found = default(MovieInfo);
            return false;
        }

        public long GetHash(string movieName)
        {
            return 0;
        }
    }

    public class MovieInfo : IEquatable<MovieInfo>
    {
        public long Id { get; set; }
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

        public bool Equals(MovieInfo other)
        {
            return Name == other.Name 
                && Format == other.Format 
                && Size == other.Size 
                && Link == other.Link;
        }
    }
}
