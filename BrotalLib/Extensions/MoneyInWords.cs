using System;
using System.Globalization;
using System.Text;

namespace Brotal.Extensions
{
    public static class MoneyInWords
    {
        #region Decimal to Words
        /// <summary>
        /// Converts decimal number to words (string)
        /// </summary>
        /// <param name="value">The decimal number</param>
        /// <param name="basicMonetaryUnit">Basic monetary unit to show.
        /// E.g. Dollars, Taka, Euro etc</param>
        /// <param name="fractionMonetaryUnit">1/100th fraction unit name of the basic monetary unit.
        /// E.g. Cents, Penny, Poisa etc.</param>
        /// <returns>In words representation of the decimal value</returns>
        public static string ToMoney(this decimal value,
            string basicMonetaryUnit,
            string fractionMonetaryUnit)
        {
            var decimals = string.Empty;
            var input = Math.Round(value, 2).ToString(CultureInfo.InvariantCulture);

            if (input.Contains("."))
            {
                decimals = input.Substring(input.IndexOf(".", StringComparison.Ordinal) + 1);

                // remove decimal part from input
                input = input.Remove(input.IndexOf(".", StringComparison.Ordinal));
            }

            // Convert input into words. save it into strWords
            var strWords = $"{GetWords(input)} {basicMonetaryUnit}";

            if (decimals.Length > 0)
            {
                // if there is any decimal part convert it to words and add it to strWords.
                strWords += $" and {GetWords(decimals)} {fractionMonetaryUnit}";
            }

            return strWords;
        }

        private static string GetWords(string input)
        {
            // these are separators for each 3 digit in numbers. 
            // you can add more if you want convert bigger numbers.
            string[] separators = { "", " Thousand ", " Million ", " Billion ", " Trillion " };

            // Counter is indexer for separators.
            // each 3 digit converted this will count.
            var i = 0;

            var builder = new StringBuilder();

            while (input.Length > 0)
            {
                // get the 3 last numbers from input and store it. 
                // if there is not 3 numbers just use take it.
                var threeDigits = input.Length < 3 ? input : input.Substring(input.Length - 3);

                // remove the 3 last digits from input. if there is not 3 numbers just remove it.
                input = input.Length < 3 ? "" : input.Remove(input.Length - 3);

                var no = int.Parse(threeDigits);

                // Convert 3 digit number into words.
                threeDigits = GetWord(no);

                // apply the separator.
                threeDigits += separators[i];

                // since we are getting numbers from right to left then we must append result to strWords like this.
                builder.Insert(0, threeDigits);

                // 3 digits converted. count and go for next 3 digits
                i++;
            }

            return builder.ToString();
        }

        // method just to convert 3digit number into words.
        private static string GetWord(int no)
        {
            string[] ones = {
                "One",
                "Two",
                "Three",
                "Four",
                "Five",
                "Six",
                "Seven",
                "Eight",
                "Nine",
                "Ten",
                "Eleven",
                "Twelve",
                "Thirteen",
                "Fourteen",
                "Fifteen",
                "Sixteen",
                "Seventeen",
                "Eighteen",
                "Nineteen"
            };

            string[] tens = {
                "Ten",
                "Twenty",
                "Thirty",
                "Forty",
                "Fifty",
                "Sixty",
                "Seventy",
                "Eighty",
                "Ninety"
            };

            var builder = new StringBuilder();

            if (no > 99 && no < 1000)
            {
                var i = no / 100;
                builder.Append(ones[i - 1])
                       .Append(" Hundred ");
                no %= 100;
            }

            if (no > 19 && no < 100)
            {
                var i = no / 10;
                builder.Append(tens[i - 1])
                       .Append(" ");
                no %= 10;
            }

            if (no > 0 && no < 20)
            {
                builder.Append(ones[no - 1]);
            }

            return builder.ToString();
        }
        #endregion
    }
}
