using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.BusinessLogic
{
    /// <summary>
    /// Handles the conversion from number currency amount to German words
    /// Not Implemented yet!
    /// </summary>
    /// <seealso cref="NumberToWords.BusinessLogic.ICurrencyToWordConverter" />
    public class GermanCurrencyToWordsConverter : ICurrencyToWordConverter
    {
        public CultureInfo Culture => new CultureInfo("de");

        public string CurrencyWord => throw new ConverterException("Culture is not implemented");

        public string CurrencyFractionWord => throw new ConverterException("Culture is not implemented");

        public GermanCurrencyToWordsConverter()
        {

        }

        public string Convert(int number)
        {
            throw new ConverterException("Culture is not implemented");
        }

        public string Convert(double number)
        {
            throw new ConverterException("Culture is not implemented");
        }
    }
}
