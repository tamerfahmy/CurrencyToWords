using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using NumberToWords.BusinessLogic;
using System.Globalization;
using System.Diagnostics;

namespace NumbersToWords.BusinessLogic.Tests
{
    [TestClass]

    public class EnglishCurrencyToWordConverterTests
    {
        /// <summary>
        /// Assessment example 1
        /// </summary>
        [TestMethod]
        public void TestConvertZero()
        {
            var word = (0).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("zero dollars", word);
        }

        /// <summary>
        /// Assessment example 2
        /// </summary>
        [TestMethod]
        public void TestConvertOne()
        {
            var word = (1).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("one dollar", word);
        }

        /// <summary>
        /// Assessment example 3
        /// </summary>
        [TestMethod]
        public void TestConvertTensWith10Cents()
        {
            var word = (25.1).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("twenty-five dollars and ten cents", word);
        }

        /// <summary>
        /// Assessment example 4
        /// </summary>
        [TestMethod]
        public void TestConvertZeroWith1Cent()
        {
            var word = (0.01).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("zero dollars and one cent", word);
        }

        /// <summary>
        /// Assessment example 5
        /// </summary>
        [TestMethod]
        public void TestConvertThousandsAndHundrededs()
        {
            var word = (45100).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("forty-five thousand one hundred dollars", word);
        }

        /// <summary>
        /// Assessment example 6
        /// </summary>
        [TestMethod]
        public void TestConvertMillionsQithDecimals()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            var word = (999999999.99d).ToCurrencyWrods(new CultureInfo("en"));
            stopWatch.Stop();
            Assert.AreEqual("nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents", word);
            Assert.IsTrue(stopWatch.ElapsedMilliseconds < 2);
        }

        /// <summary>
        /// Assessment example 6
        /// </summary>
        [TestMethod]
        public void TestConvertMillions()
        {
            var word = (999999998).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-eight dollars", word);
        }



        [TestMethod]
        public void TestConvertPositiveUnits()
        {
            var word = (10).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("ten dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveTens()
        {
            var word = (30).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("thirty dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveTensAndUnits()
        {
            var word = (45).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("forty-five dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveHundreds()
        {
            var word = (100).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("one hundred dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveTwoHundreds()
        {
            var word = (200).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("two hundred dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveHundredsAndTens()
        {
            var word = (540).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("five hundred forty dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveHundredsAndTens2()
        {
            var word = (510).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("five hundred ten dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveThousandHundredsAndTens()
        {
            var word = (3510).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("three thousand five hundred ten dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveThousandHundredsAndTens2()
        {
            var word = (3519).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("three thousand five hundred nineteen dollars", word);
        }

        [TestMethod]
        public void TestConvertPositiveThousandHundredsAndTensWithDecimalEnglishSpearator()
        {
            var word = (3519.3451).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("three thousand five hundred nineteen dollars and three thousand four hundred fifty-one cents", word);
        }

        [TestMethod]
        public void TestConvertPositiveThousandHundredsAndTensWithZeroDecimalEnglishSpearator()
        {
            var word = (3519.00).ToCurrencyWrods(new CultureInfo("en"));
            Assert.AreEqual("three thousand five hundred nineteen dollars", word);
        }
    }
}
