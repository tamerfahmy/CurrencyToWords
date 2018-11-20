using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NumberToWords.BusinessLogic;

namespace NumbersToWords.BusinessLogic.Tests
{
    [TestClass]
    public class CurrencyToWordsFactoryTests
    {
        [TestMethod]
        public void TestAddNewCustomConverter()
        {
            CurrencyToWordsFactory.AddCustomConverter(new DummyCustomConverterOne());
            var converter = CurrencyToWordsFactory.GetConverter(new CultureInfo("ar"));

            Assert.IsNotNull(converter);
        }

        [TestMethod]
        [ExpectedException(typeof(ConverterException))]
        public void TestAddCustomConverterAlreadyExists()
        {
            CurrencyToWordsFactory.AddCustomConverter(new DummyCustomConverterTwo());
        }

        [TestMethod]
        [ExpectedException(typeof(ConverterException))]
        public void TestGetNotExisitingConverterByCulture()
        {
            var converter = CurrencyToWordsFactory.GetConverter(new CultureInfo("fr"));

            Assert.IsNull(converter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetWithNullCulture()
        {
            var converter = CurrencyToWordsFactory.GetConverter(null);

            Assert.IsNull(converter);
        }


    }

    public class DummyCustomConverterOne : ICurrencyToWordConverter
    {
        public CultureInfo Culture => new CultureInfo("ar");

        public string CurrencyWord => throw new NotImplementedException();

        public string CurrencyFractionWord => throw new NotImplementedException();

        public string Convert(int number)
        {
            throw new System.NotImplementedException();
        }

        public string Convert(double number)
        {
            throw new System.NotImplementedException();
        }
    }

    public class DummyCustomConverterTwo : ICurrencyToWordConverter
    {
        public CultureInfo Culture => new CultureInfo("en");

        public string CurrencyWord => throw new NotImplementedException();

        public string CurrencyFractionWord => throw new NotImplementedException();

        public string Convert(int number)
        {
            throw new System.NotImplementedException();
        }

        public string Convert(double number)
        {
            throw new System.NotImplementedException();
        }
    }
}
