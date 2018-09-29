using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Dexiom.StringExtensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Split a complex name to words
        /// </summary>
        /// <example>"TheTPSReportIsCompleted" becomes "The TPS Report Is Completed"</example>
        /// <param name="source"></param>
        /// <returns></returns>
        public static string ToWords(this string source)
        {
            return Regex.Replace(source, @"((?<=\p{Ll})\p{Lu})|((?!\A)\p{Lu}(?>\p{Ll}))", " $0");
        }

        /// <summary>
        /// Extract a defined number of caracter (Starting on the right)
        /// </summary>
        /// <author>Jonathan Paré</author>
        /// <param name="source"></param>
        /// <param name="length">Number of caracters to take</param>
        /// <returns></returns>
        public static string Right(this string source, int length)
        {
            if (length >= source.Length)
            {
                return source;
            }
            else
            {
                return source.Substring(source.Length - length);
            }
        }

        /// <summary>
        /// Extract a defined number of caracter (Starting on the left)
        /// </summary>
        /// <author>Jonathan Paré</author>
        /// <param name="source"></param>
        /// <param name="length">Number of caracters to take</param>
        /// <returns></returns>
        public static string Left(this string source, int length)
        {
            if (source.Length <= length)
            {
                return source;
            }
            else
            {
                return source.Substring(0, length);
            }
        }

        /// <summary>
        /// Extract a defined number of caracter
        /// </summary>
        /// <author>Jonathan Paré</author>
        /// <param name="source"></param>
        /// <param name="startIndex">The zero-based starting caracter position</param>
        /// <returns></returns>
        public static string Mid(this string source, int startIndex)
        {
            return Mid(source, startIndex, int.MaxValue);
        }

        /// <summary>
        /// Extract a defined number of caracter
        /// </summary>
        /// <author>Jonathan Paré</author>
        /// <param name="source"></param>
        /// <param name="startIndex">The zero-based starting caracter position</param>
        /// <param name="length">Number of caracters to take</param>
        /// <returns></returns>
        public static string Mid(this string source, int startIndex, int length)
        {
            if (source.Length <= startIndex)
            {
                return string.Empty;
            }
            else if (length == int.MaxValue || source.Length <= startIndex + length)
            {
                return source.Substring(startIndex);
            }
            else
            {
                return source.Substring(startIndex, length);
            }
        }

        /// <summary>
        /// Check if the specified text occurs within this string.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="text">Text to search</param>
        /// <param name="stringComparison">Comparison rule</param>
        /// <returns></returns>
        public static bool Contains(this string source, string text, StringComparison stringComparison)
        {
            return source.IndexOf(text, stringComparison) >= 0;
        }

        /// <summary>
        /// Reduce the length of a string (ex: for a preview)
        /// If the string is longer than specified, the exceeding portion will be replaced by "..."
        /// </summary>
        /// <param name="source"></param>
        /// <param name="maxLength">Maximum length of the resulting string</param>
        /// <returns></returns>
        public static string Shorten(this string source, int maxLength)
        {
            if (source.Length <= maxLength)
                return source;

            return source.Substring(0, maxLength - 3) + "...";
        }
    }
}
