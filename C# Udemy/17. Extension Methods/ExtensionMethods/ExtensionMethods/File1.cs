using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace ExtensionMethods2
{
    static class StringExtensions
    {
        public static string RemoveVowels(this string text)
        {
            string result = "";
            foreach(char ch in text)
            {
                if(ch != 'a' &&
                   ch != 'e' &&
                   ch != 'i' &&
                   ch != 'o' &&
                   ch != 'u' ||
                   ch != 'A' &&
                   ch != 'E' &&
                   ch != 'I' &&
                   ch != 'O' &&
                   ch != 'U' ) 
                { 
                 result += ch;
                }
            }
            return result;
        }
    }
}
