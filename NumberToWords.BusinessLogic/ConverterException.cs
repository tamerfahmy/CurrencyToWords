using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberToWords.BusinessLogic
{
    /// <summary>
    /// Handling custom logical exceptions on the implementation of the currency number to words conversion
    /// </summary>
    /// <seealso cref="System.Exception" />
    public class ConverterException : Exception
    {
        public ConverterException(string message) : base(message)
        {

        }
    }
}
