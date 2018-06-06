using BerlinClock.Classes.Parsers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace BerlinClock.Classes
{
    public class TimeConverter : ITimeConverter
    {
        private readonly List<IBerlinClockParser> parsers = new List<IBerlinClockParser> { new BerlinClockSecondParser(), new BerlinClockHourParser(), new BerlinClockMinuteParser() };

        public string ConvertTime(string aTime)
        {
            if (!TryParse(aTime, out string[] time))
            {
                throw new ArgumentException("Not valid time to convert.");
            }

            return string.Join("\n", parsers.Select(i => i.Parse(time)));
        }

        /// <summary>
        /// TimeSpan.TryParse not working for 24:00:00
        /// </summary>
        /// <param name="s"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private bool TryParse(string s, out string[] result)
        {
            Regex regex = new Regex(@"^(?:0?[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (regex.IsMatch(s) || s == "24:00:00")
            {
                result = s.Split(':');
                return true; 
            }

            result = null;
            return false;
        }
    }
}
