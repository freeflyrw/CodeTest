using System;
using System.Linq;

namespace CodeTest
{
    public static class StringExtensions
    {
        public static string ReverseStringForLoop(this string stringToReverse)
        {
            var reversedString = string.Empty;
            for (var i = stringToReverse.Length -1; i >= 0; i--)
            {
                reversedString += stringToReverse[i];
            }

            return reversedString;
        }

        public static string ReverseString(this string stringToReverse)
        {
            return new string(stringToReverse.Reverse().ToArray());
        }        
    }
}