using System;

namespace BerlinClock.Classes.Parsers
{
    public interface IBerlinClockParser
    {
        string Parse(string[] time);
    }
}