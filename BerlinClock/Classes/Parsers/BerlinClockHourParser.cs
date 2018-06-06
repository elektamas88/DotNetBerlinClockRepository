using BerlinClock.Classes.Extensions;
using System;

namespace BerlinClock.Classes.Parsers
{
    public class BerlinClockHourParser : IBerlinClockParser
    {
        private const int LampOfRow = 4;
        private const int HourMultiplier = 5;

        public string Parse(string[] time)
        {
            int hours = Convert.ToInt32(time[0]);

            string FirstRow = GetLamps(hours / HourMultiplier);
            string SecondRow = GetLamps(hours % HourMultiplier);

            return $"{FirstRow}\n{SecondRow}";
        }

        private string GetLamps(int lampIsOn)
        {
            return Color.Red.Repeat(lampIsOn) + Color.None.Repeat(LampOfRow - lampIsOn);
        }
    }
}
