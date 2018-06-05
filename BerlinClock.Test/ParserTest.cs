using BerlinClock.Classes.Parsers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BerlinClock.Test
{
    [TestClass]
    public class ParserTest
    {
        BerlinClockHourParser hourParser;
        BerlinClockMinuteParser minuteParser;
        BerlinClockSecondParser secondParser;

        [TestInitialize]
        public void Init()
        {
            hourParser = new BerlinClockHourParser();
            minuteParser = new BerlinClockMinuteParser();
            secondParser = new BerlinClockSecondParser();
        }

        [TestMethod]
        [DataRow("00:00:00", "OOOO\r\nOOOO")]
        [DataRow("10:00:00", "RROO\r\nOOOO")]
        [DataRow("14:00:00", "RROO\r\nRRRR")]
        [DataRow("24:00:00", "RRRR\r\nRRRR")]
        public void HourParserTest(string time, string expectedResult)
        {
            var hour = time.Split(':');
            Assert.AreEqual(expectedResult, hourParser.Parse(hour));
        }

        [TestMethod]
        [DataRow("00:00:00", "OOOOOOOOOOO\r\nOOOO")]
        [DataRow("00:13:00", "YYOOOOOOOOO\r\nYYYO")]
        [DataRow("10:30:00", "YYRYYROOOOO\r\nOOOO")]
        [DataRow("14:59:00", "YYRYYRYYRYY\r\nYYYY")]
        public void MinutesParserTest(string time, string expectedResult)
        {
            var minutes = time.Split(':');
            Assert.AreEqual(expectedResult, minuteParser.Parse(minutes));
        }

        [TestMethod]
        [DataRow("00:00:00", "Y")]
        [DataRow("10:00:01", "O")]
        [DataRow("14:00:59", "O")]
        public void SecondsParserTest(string time, string expectedResult)
        {
            var seconds = time.Split(':');
            Assert.AreEqual(expectedResult, secondParser.Parse(seconds));
        }
    }
}
