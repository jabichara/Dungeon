using ClassLibrary.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Generators
{
    public class MovInfGenerator
    {
        readonly static Random random = new Random();
        readonly static string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
        readonly static string[] MovFormats = { "mp4", "mov", "wmv", "flv", "avi", "avchd", "webm", "mkv" };

        public static MovieInfo GenerateMovInf()
        {
            string name = GenerateName(2, 8);

            string format = MovFormats[random.Next(0, MovFormats.Length - 1)];

            int size = random.Next();

            string link = "www." + GenerateName(3, 8) + "." + GenerateName(2, 3) + "/" + name + "." + format;

            return new MovieInfo(name, format, size, link);
        }

        public static string GenerateName(int minLength, int maxLength)
        {
            int length = random.Next(minLength, maxLength);
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static MovieInfo[] GenerateMovArray(int quantity)
        {
            var array = new MovieInfo[quantity];
            for (int i = 0; i < quantity; i++)
            {
                array[i] = GenerateMovInf();
            }
            return array;
        }
    }
}