using BerlinClock.Classes.Extensions;
using System;
using System.Text;

namespace BerlinClock.Classes.Parsers
{
    public class BerlinClockMinuteParser : IBerlinClockParser
    {
        private const int LampOfFirstRow = 11;
        private const int LampOfSecondRow = 4;
        private const int MinuteMultiplier = 5;

        public string Parse(string[] time)
        {
            int minutes = Convert.ToInt32(time[1]);

            string firstRow = GetFirstRowLamps(minutes / MinuteMultiplier);
            string secondRow = GetSecondRowLamps(minutes % MinuteMultiplier);

            return $"{firstRow}{Environment.NewLine}{secondRow}";
        }

        private string GetFirstRowLamps(int lampIsOn)
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= lampIsOn; i++)
            {
                if (i % 3 == 0)
                {
                    sb.Append(Color.Red.Repeat(1));
                }
                else
                {
                    sb.Append(Color.Yellow.Repeat(1));
                }
            }

            sb.Append(Color.None.Repeat(LampOfFirstRow - lampIsOn));

            return sb.ToString();
        }

        private string GetSecondRowLamps(int lampIsOn)
        {
            return Color.Yellow.Repeat(lampIsOn) + Color.None.Repeat(LampOfSecondRow - lampIsOn);
        }
    }
}
