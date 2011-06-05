using System;

namespace UsingSpecflowForUnitTests.SecureNavigation.Domain
{
    public static class StringExtension
    {
        public static bool EqualsIgnoreCase(this string value, string compareTo)
        {
            if (value == null) return (compareTo == null);
            return value.Equals(compareTo, StringComparison.OrdinalIgnoreCase);
        }
    }
}