using System;
using System.Linq;

namespace CodeTest
{
    public static class StringExtensions
    {
        public static string ReverseString(this string stringToReverse)
        {
            return new string(stringToReverse.Reverse().ToArray());
        }        
    }
}