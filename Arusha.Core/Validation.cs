using System;
using System.Text.RegularExpressions;

namespace Arusha.Core
{
    public static class Validation
    {
        private const string MobilePattern = @"^(?<Prefix>(?:0098|0|098|\+98|98|))(?<Number>9[0-9]{9})$";
        private const string EmailPattern = @"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$";

        public static int ToInt(this string value)
        {
            return Convert.ToInt32(value);
        }

        public static string NormalizeEmail(this string str)
        {
            if (!str.HasValue(true))
            {
                return null;
            }
            return str.ToUpperInvariant();
        }
        public static bool IsEmail(this string username)
        {
            if (username.HasValue())
            {
                if (Regex.IsMatch(username, EmailPattern, RegexOptions.Compiled))
                {
                    return true;
                };
            }
            return false;
        }
        public static bool IsMobile(this string username)
        {
            if (username.HasValue())
            {
                if (Regex.IsMatch(username, MobilePattern, RegexOptions.Compiled))
                {
                    return true;
                };
            }
            return false;
        }
    }
}
