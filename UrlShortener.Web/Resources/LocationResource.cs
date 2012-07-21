using System;
using Nancy;

namespace UrlShortener.Web.Resources
{
    public class LocationResource
    {
        private readonly Url url;
        private string identifier;

        public LocationResource(Url url, string identifier)
        {
            this.url = url;
            this.identifier = identifier;
        }

        private string GenerateUrl()
        {
            var port = "";
            if (url.Port.HasValue)
            {
                port = string.Concat(":", url.Port);
            }

            if (!string.IsNullOrWhiteSpace(identifier))
                identifier = string.Concat("/", identifier);

            return string.Format("{0}://{1}{2}{3}{4}", url.Scheme, url.HostName, port, url.Path, identifier);
        }

        public static implicit operator string(LocationResource location)
        {
            return location.ToString();
        }

        public override string ToString()
        {
            return GenerateUrl();
        }
    }
}