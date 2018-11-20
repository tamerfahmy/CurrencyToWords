using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.BusinessLogic
{
    /// <summary>
    /// Interface for currency number amount to words
    /// </summary>
    public interface ICurrencyToWordConverter
    {
        /// <summary>
        /// Gets the currency word.
        /// </summary>
        /// <value>
        /// The currency word.
        /// </value>
        string CurrencyWord { get; }
        /// <summary>
        /// Gets the currency fraction word.
        /// </summary>
        /// <value>
        /// The currency fraction word.
        /// </value>
        string CurrencyFractionWord { get; }
        /// <summary>
        /// Gets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        CultureInfo Culture { get; }
        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        string Convert(int number);
        /// <summary>
        /// Converts the specified number.
        /// </summary>
        /// <param name="number">The number.</param>
        /// <returns></returns>
        string Convert(double number);
    }
}
