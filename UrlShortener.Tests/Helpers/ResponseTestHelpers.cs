using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nancy.Testing;
using Newtonsoft.Json;

namespace UrlShortener.Tests.Helpers
{
    public static class ResponseTestHelpers
    {
        public static dynamic ToDynamic(this BrowserResponseBodyWrapper body)
        {
            using (var reader = new StreamReader(body.AsStream()))
            {
                return JsonConvert.DeserializeObject(reader.ReadToEnd());
            }
        }
    }
}
