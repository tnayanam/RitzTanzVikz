using System.Globalization;

namespace Bridge.Helpers
{
    public static class Utils
    {
        public static string MakeFirstLetterCaps(string input)
        {
            return new CultureInfo("en").TextInfo.ToTitleCase(input.ToLower());
        }
    }
}