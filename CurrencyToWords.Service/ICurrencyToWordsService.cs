using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CurrencyToWords.Service
{
    [ServiceContract]
    public interface ICurrencyToWordsService
    {
        [OperationContract]
        ConversionResponse Convert(double value, CultureInfo cultureInfo);

    }

    public interface IServiceResponse
    {
        ServiceResultStatus Status { get; set; }
        string Message { get; set; }
    }

    /// <summary>
    /// The response of the number to words currency conversion 
    /// </summary>
    [DataContract]
    public class ConversionResponse : IServiceResponse
    {
        [DataMember]
        public string AmountInWords { get; set; }

        [DataMember]
        public ServiceResultStatus Status { get; set; }

        [DataMember]
        public string Message { get; set; }
    }

    [DataContract]
    public enum ServiceResultStatus : byte
    {
        [EnumMember]
        Success = 0,
        [EnumMember]
        Warning = 2,
        [EnumMember]
        Failed = 3,
    }
}
