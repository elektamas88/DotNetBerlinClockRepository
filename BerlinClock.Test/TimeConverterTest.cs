using System;
using BerlinClock.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Test
{
    [TestClass]
    public class TimeConverterTest
    {
        ITimeConverter converter;

        [TestInitialize]
        public void Init()
        {
            converter = new TimeConverter();
        }

        [TestMethod]
        [DataRow("14:00")]
        [DataRow("24:00:01")]
        [DataRow("24:01:00")]
        [DataRow("00:60:00")]
        [ExpectedException(typeof(System.ArgumentException))]
        public void BadFormatTest(string time)
        {
            converter.ConvertTime(time);
        }

        [TestMethod]
        [DataRow("11:12:13", "O\r\nRROO\r\nROOO\r\nYYOOOOOOOOO\r\nYYOO")]
        [DataRow("24:00:00", "Y\r\nRRRR\r\nRRRR\r\nOOOOOOOOOOO\r\nOOOO")]
        public void GoodFormatTest(string time, string expectedResult)
        {
            var result = converter.ConvertTime(time);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
