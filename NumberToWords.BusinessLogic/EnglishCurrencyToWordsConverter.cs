using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NumberToWords.BusinessLogic
{
    /// <summary>
    /// English currency number amount to words converter
    /// </summary>
    /// <seealso cref="NumberToWords.BusinessLogic.ICurrencyToWordConverter" />
    public class EnglishCurrencyToWordsConverter : ICurrencyToWordConverter
    {
        #region Private Members
        private readonly string[] _unitsMap = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private readonly string[] _tensMap = { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private readonly string[] _thousands = { "", " thousand", " million", " billion" };
        #endregion

        #region Constructor
        public EnglishCurrencyToWordsConverter()
        {

        }
        #endregion

        #region Public Members
        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public CultureInfo Culture => new CultureInfo("en");

        /// <summary>
        /// Gets the currency word.
        /// </summary>
        /// <value>
        /// The currency word.
        /// </value>
        public string CurrencyWord => "dollar";

        /// <summary>
        /// Gets the currency fraction word.
        /// </summary>
        /// <value>
        /// The currency fraction word.
        /// </value>
        public string CurrencyFractionWord => "cent";
        #endregion

        #region Public Methods
        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public string Convert(int number)
        {
            var word = InternalConvert(number);
            return word;
        }

        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        public string Convert(double number)
        {
            var word = InternalConvert(number);
            return word;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Internals convert number to words.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>The amount in words</returns>
        /// <exception cref="NumberToWords.BusinessLogic.ConverterException">
        /// </exception>
        private string InternalConvert(double number)
        {
            string word = string.Empty;
            if (number > 1000000000)
            {
                throw new ConverterException($"This number {number} is not allowed. Maximum number is 1000 000 000.");
            }
            else if (number < 0)
            {
                throw new ConverterException($"This number {number} is not allowed. Minimum number is 0.");
            }
            else
            {
                if (IsDecimalNumber(number))
                {
                    word = $"{HandleNumberConversion((long)number)} {GetCurrencyWord((int)number)}";
                    var decimalPart = GetDecimalPart(number);
                    word += $" and {HandleNumberConversion(decimalPart)} {GetCurrencyFractionWord(decimalPart)}";
                }
                else
                {
                    word = $"{HandleNumberConversion(number)} {GetCurrencyWord((int)number)}";
                }
            }

            return word;
        }

        /// <summary>
        /// Handles the umber to word conversion.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>the words representation</returns>
        private string HandleNumberConversion(double number)
        {
            string currencyWords = "";
            if (number == 0)
            {
                currencyWords = GetUnitValue((int)number);
            }
            else
            {
                var numberString = number.ToString();

                int thousandsIndex = 0;
                while (numberString.Length > 0)
                {
                    var threeDigitsString = numberString.Length < 3 ? numberString : numberString.Substring(numberString.Length - 3);
                    numberString = numberString.Length < 3 ? string.Empty : numberString.Remove(numberString.Length - 3);

                    threeDigitsString = $"{Get3DigitsWord(threeDigitsString)}{_thousands[thousandsIndex]}";

                    if (currencyWords.Length > 0)
                        currencyWords = $"{threeDigitsString} {currencyWords}";
                    else
                        currencyWords = threeDigitsString;

                    thousandsIndex++;
                }
            }
            return currencyWords;
        }

        /// <summary>
        /// Get a word representation of 3 digits.
        /// </summary>
        /// <param name="threeDigitsString">The three digits string.</param>
        /// <returns>The words representation of 3 digits</returns>
        private string Get3DigitsWord(string threeDigitsString)
        {
            string word = string.Empty;
            var threeDigitsInt = int.Parse(threeDigitsString);
            bool hasTens = false, hasHundereds = false;

            if (threeDigitsInt > 99 && threeDigitsInt < 1000)
            {
                hasHundereds = true;
                word += $"{GetUnitValue(threeDigitsInt / 100)} hundred";
                threeDigitsInt = threeDigitsInt % 100;
            }

            if (threeDigitsInt > 19 && threeDigitsInt < 100)
            {
                hasTens = true;
                var tensValue = GetTensValue(threeDigitsInt / 10);
                word += hasHundereds ? $" {tensValue}" : tensValue;
                threeDigitsInt = threeDigitsInt % 10;
            }

            if (threeDigitsInt > 0 && threeDigitsInt < 20)
            {
                var unitValue = GetUnitValue(threeDigitsInt);
                word += hasTens ? $"-{unitValue}" : hasHundereds ? $" { unitValue}" : unitValue;
            }

            return word;
        }

        /// <summary>
        /// Determines whether [is decimal number] [the specified number].
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns>
        ///   <c>true</c> if [is decimal number] [the specified number]; otherwise, <c>false</c>.
        /// </returns>
        private bool IsDecimalNumber(double number)
        {
            var numberString = number.ToString();
            return numberString.Contains(this.Culture.NumberFormat.NumberDecimalSeparator);
        }

        /// <summary>
        /// Gets the decimal part.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private int GetDecimalPart(double number)
        {
            var regex = new Regex($"(?<=[\\{this.Culture.NumberFormat.NumberDecimalSeparator}])[0-9]+");
            var decimalPartString = regex.Match(number.ToString()).Value;
            var decimalPart = int.Parse(decimalPartString);
            if (decimalPartString.Length == 1)
                decimalPart *= 10;

            return decimalPart;
        }

        /// <summary>
        /// Gets the unit value.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private string GetUnitValue(int number)
        {
            return _unitsMap[number];
        }

        /// <summary>
        /// Gets the tens value.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private string GetTensValue(int number)
        {
            return _tensMap[(int)number];
        }

        /// <summary>
        /// Gets the currency word.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private string GetCurrencyWord(int number)
        {
            if (number != 1)
                return $"{this.CurrencyWord}s";
            else
                return this.CurrencyWord;
        }

        /// <summary>
        /// Gets the currency fraction word.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        private string GetCurrencyFractionWord(int number)
        {
            if (number != 1)
                return $"{this.CurrencyFractionWord}s";
            else
                return this.CurrencyFractionWord;
        }
        #endregion
    }
}
