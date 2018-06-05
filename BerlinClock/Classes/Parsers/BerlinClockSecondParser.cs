using System;
using BerlinClock.Classes.Extensions;

namespace BerlinClock.Classes.Parsers
{
    public class BerlinClockSecondParser : IBerlinClockParser
    {
        public string Parse(string[] time)
        {
            int seconds = Convert.ToInt32(time[2]);

            if (seconds % 2 == 0)
                return Color.Yellow.Repeat(1);
            else
                return Color.None.Repeat(1);
        }
    }
}
