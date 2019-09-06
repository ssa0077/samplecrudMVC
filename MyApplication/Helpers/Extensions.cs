using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MyApplication.Helpers
{
    public class Extensions
    {
        public static bool WarnInputError(string input)
        {
            string pattern = @"[\!\[\]\*\-]";

            Match m = Regex.Match(input, pattern);

            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }

            return false;
        }
    }
}