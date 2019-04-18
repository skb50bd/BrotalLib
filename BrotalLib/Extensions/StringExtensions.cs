using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

using static System.Char;

namespace Brotal.Extensions
{
    public static class StringExtensions
    {
        public static string FromPascalCase(
            this string str)
        {
            var words = new List<string>();

            var word = new StringBuilder();
            foreach (var c in str)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    words.Add(word.ToString());
                    word = new StringBuilder();
                }
                word.Append(c);
            }

            words.Add(word.ToString());

            var final = new StringBuilder();
            foreach (var s in words)
                final.Append(s)
                     .Append(" ");

            return final.ToString().Trim();
        }

        public static string ToPascalCase(
            this string str)
        {
            var words = str.Split();
            var output = new StringBuilder();

            var textInfo = new CultureInfo("en-US", false).TextInfo;

            foreach (var word in words)
                output.Append(textInfo.ToTitleCase(word));

            return output.ToString();
        }

        public static T[] SubArray<T>(
            this T[] data, 
            int index, 
            int length)
        {
            var result = new T[length];
            Array.Copy(data, index, result, 0, length);

            return result;
        }

        public static string ToFriendlyCase(
            this string camelCase) =>
            Regex.Replace( // Remove Extra Spaces
                Regex.Replace( // Split The Camel Case Expression
                    camelCase,
                    "(?!^)([A-Z])",
                    " $1"),
                "/ +/ g",
                " ");

        public static string ToNaturalName(
            this Enum value)
        {
            var fi = value.GetType().GetField(value.ToString());
            var attributes = (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute), 
                false);

            return attributes.Length > 0 
                ? attributes[0].Description 
                : value.ToString().ToFriendlyCase();
        }

        public static string Capitalize(
            this string str)
        {
            var builder = new StringBuilder();
            var firstChar = str.Substring(0, 1)
                               .ToUpperInvariant();
            var restChars = str.Substring(1);

            builder.Append(firstChar);
            builder.Append(restChars);

            return builder.ToString();
        }

        public static string ToTitleCase(
            this string str)
        {
            var builder = new StringBuilder();
            var previousIsSpace = true;

            foreach (var c in str)
            {
                var x = c;
                if (c == ' ') previousIsSpace = true;
                else if (previousIsSpace)
                {
                    previousIsSpace = false;
                    x = ToUpperInvariant(c);
                }
                else
                {
                    previousIsSpace = false;
                }

                builder.Append(x);
            }

            return builder.ToString();
        }

        public static string ToCurrency(
            this decimal money, 
            int digitsAfterDecimal = 2) =>
            money.ToString($"C{digitsAfterDecimal}");
    }
}
