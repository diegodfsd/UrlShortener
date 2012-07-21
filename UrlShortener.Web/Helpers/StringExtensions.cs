using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener.Web.Helpers
{
    public static class StringExtensions
    {
        public static string Pluralize(this string value)
        {
            return string.Format("{0}s", value);
        }
    }
}