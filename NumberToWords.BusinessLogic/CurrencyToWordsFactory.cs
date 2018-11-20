using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.BusinessLogic
{
    /// <summary>
    /// A factory class to return an object to convert a currency number amount to words based on culture info for localization
    /// </summary>
    public class CurrencyToWordsFactory
    {
        #region Public Static Properties
        /// <summary>
        /// Gets the currency to words converters.
        /// </summary>
        /// <value>
        /// The currency to words converters.
        /// </value>
        public static List<ICurrencyToWordConverter> CurrencyToWordsConverters { get; } = new List<ICurrencyToWordConverter>()
        {
            new EnglishCurrencyToWordsConverter(),
            new GermanCurrencyToWordsConverter()
        };
        #endregion

        #region Public Static Methods
        /// <summary>
        /// Adds the custom converter.
        /// </summary>
        /// <param name="converter">The converter.</param>
        /// <exception cref="NumberToWords.BusinessLogic.ConverterException"></exception>
        public static void AddCustomConverter(ICurrencyToWordConverter converter)
        {
            if (!CurrencyToWordsConverters.Any(c => c.Culture.Name == converter.Culture.Name))
            {
                CurrencyToWordsConverters.Add(converter);
            }
            else
            {
                throw new ConverterException($"Currency to words converter with the same culture { converter.Culture.Name } already exists");
            }
        }

        /// <summary>
        /// Gets the converter.
        /// </summary>
        /// <param name="cultureInfo">The culture information.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">cultureInfo - cultureInfo can not be null.</exception>
        /// <exception cref="NumberToWords.BusinessLogic.ConverterException"></exception>
        public static ICurrencyToWordConverter GetConverter(CultureInfo cultureInfo)
        {
            if (cultureInfo == null)
            {
                throw new ArgumentNullException(nameof(cultureInfo), "cultureInfo can not be null.");
            }
            else
            {
                var converter = CurrencyToWordsConverters.FirstOrDefault(c => c.Culture.Name == cultureInfo.Name);
                if (converter != null)
                {
                    return converter;
                }
                else
                {
                    throw new ConverterException($"There is no valid currency to words converter for the culture {cultureInfo.Name}");
                }
            }
        }
        #endregion
    }
}
