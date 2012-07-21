using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy.IO;
using System.IO;
using Newtonsoft.Json;

namespace UrlShortener.Web.Helpers
{
    public static class RequestHelpers
    {
        public static TResult To<TResult>(this RequestStream body)
        {
            using (var reader = new StreamReader(body))
            {
                return JsonConvert.DeserializeObject<TResult>(reader.ReadToEnd());
            }
        }
    }
}