using NumberToWords.BusinessLogic;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CurrencyToWords.Service
{
    public class CurrencyToWordsService : ICurrencyToWordsService
    {
        public ConversionResponse Convert(double value, CultureInfo cultureInfo)
        {
            var response = new ConversionResponse();

            try
            {
                var amountInWords = value.ToCurrencyWrods(cultureInfo);
                response.Status = ServiceResultStatus.Success;
                response.AmountInWords = amountInWords;
            }
            catch (ConverterException ex)
            {
                //ToDo: Log the exception on server side

                //Send the error to client
                response.Status = ServiceResultStatus.Warning;
                response.Message = ex.Message;
            }
            catch (Exception ex)
            {
                //ToDo: Log the exception on server side

                //Send the error to client
                var errorId = Guid.NewGuid();
                response.Status = ServiceResultStatus.Failed;
                response.Message = $"An error has been occurred, Please report this GUID to service provider. {errorId}";
            }

            return response;
        }
    }
}
