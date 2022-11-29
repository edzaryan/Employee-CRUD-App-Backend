using System.Text.RegularExpressions;

namespace EmployeeApp.Extensions
{
    public static class StringMethodExtensions
    {
        public static string Capitalize(this string str)
        {
            return str[0].ToString().ToUpper() + str.Substring(1);
        }

        public static string RegulateSpaces(this string str)
        {
            return Regex.Replace(str, @"\s+", " ");
        }
    }
}
