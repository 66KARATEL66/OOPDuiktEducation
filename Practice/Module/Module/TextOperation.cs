using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module
{
    public static class TextOperation
    {
        public delegate T TextOperationDelegate<T>(string text);

        public static string ToUpperCase(string text)
        {
            return text.ToUpper();
        }

        public static int CharCount(string text)
        {
            return text.Length;
        }

        public static int WordCount(string text)
        {
            return text.Split(' ').Length;
        }
    }
}

    
