using System;

namespace UrlShortener.Web.Helpers
{
    public class Shortener
    {
        private static readonly string CHARACTERS = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
 
        public static string Generate(long number)
        {
            string result = "";
            var baseSize = CHARACTERS.Length;

            do
            {
                result = string.Format("{0}{1}", CHARACTERS[(int)(number % baseSize)], result);
                number /= baseSize;
            } while (number > 0);
            return result;
        }
    }
}