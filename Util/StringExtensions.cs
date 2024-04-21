using System.Text.RegularExpressions;

namespace PiiDetectionDemo.Util
{

    public static class StringExtensions
    {

        public static string CleanupAllWhiteSpace(this string input) => Regex.Replace(input ?? string.Empty, @"\s+", " ");

    }

}