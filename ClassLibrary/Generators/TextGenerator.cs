using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary.Generators
{
    public class TextGenerator
    {
        readonly static Random rnd = new Random();
        readonly static char[] Alphabet = new char[]
        { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j',
            'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v',
            'w', 'x', 'y', 'z' };

        public static string GenerateText(int wordCount = 1000, int wordLength = 5)
        {
            StringBuilder text = new StringBuilder();
            if (wordCount == 0)
            {
                return string.Empty;
            }
            for (int i = 0; i < wordCount - 1; i++)
            {
                text.Append(GenerateWord(wordLength));
                text.Append(" ");
            }
            text.Append(GenerateWord(wordLength));
            return text.ToString();
        }

        public static string GenerateWord(int wordLength = 5)
        {
            StringBuilder word = new StringBuilder();
            for (int i = 0; i < wordLength; i++)
            {
                word.Append(Alphabet[rnd.Next(Alphabet.Length - 1)]);
            }
            return word.ToString();
        }
    }
}
