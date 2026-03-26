using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public static class TextOperation
    {
        public delegate string TextOperationDelegate(string text);

        public static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        public static string CharCount(string text)
        {
            return "Chars: " + text.Length;
        }

        public static string WordCount(string text)
        {
            return "Words: " + text.Split(' ').Length;
        }
    }
}

    
