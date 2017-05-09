using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MarketingVillage.Foundation.Common.Helpers
{
    public static class UtilityBelt
    {
        /// <summary>
        /// Checks if a string matches a wildcard argument (using regex)
        /// </summary>
        public static bool IsWildcardMatch(string input, string wildcards)
        {
            return Regex.IsMatch(input, "^" + Regex.Escape(wildcards).Replace("\\*", ".*").Replace("\\?", ".") + "$", RegexOptions.IgnoreCase);
        }
    }
}