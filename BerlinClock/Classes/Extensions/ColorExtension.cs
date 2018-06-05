namespace BerlinClock.Classes.Extensions
{
    public static class ColorExtension
    {
        public static string Repeat(this Color color, int count)
        {
            char c = (char)color;

            return new string(c, count);
        }
    }
}
