using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.BusinessLogic
{
    public static class NumberExtesions
    {
        /// <summary>
        /// Converts decimal number to currency words
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <param name="customConverters">The custom converters. If any of custom converters throws error, the conversion will fail</param>
        /// <returns></returns>
        public static string ToCurrencyWrods(this double number, CultureInfo cultureInfo, params ICurrencyToWordConverter[] customConverters)
        {
            customConverters?.ToList().ForEach(cc =>
            {
                CurrencyToWordsFactory.AddCustomConverter(cc);
            });

            var converter = CurrencyToWordsFactory.GetConverter(cultureInfo);
            var words = converter.Convert(number);
            return words;
        }

        /// <summary>
        /// Converts decimal number to currency words
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="cultureInfo">The culture information.</param>
        /// <param name="customConverters">The custom converters. If any of custom converters throws error, the conversion will fail</param>
        /// <returns></returns>
        public static string ToCurrencyWrods(this Int32 number, CultureInfo cultureInfo, params ICurrencyToWordConverter[] customConverter)
        {
            var words = ((double)number).ToCurrencyWrods(cultureInfo, customConverter);
            return words;
        }
    }
}
