using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using UrlShortener.Web.Repositories;
using UrlShortener.Web.Resources;
using UrlShortener.Web.Helpers;

namespace UrlShortener.Web.Modules
{
    public class ShortenerModule : NancyModule
    {
        IUrlStorage storage;

        public ShortenerModule(IUrlStorage urlStorage)
        {
            storage = urlStorage;

            Post["/urls"] = HandleCreate;
            Get["/urls/{shortUrl}"] = HandlerGet;
        }

        private Response HandlerGet(dynamic parameters)
        {
            var urlFound = storage.Get((string)parameters.shortUrl);
            if (urlFound == null)
                return Response.NotFound();

            return Response.AsJson<UrlResource>(urlFound.Map<UrlResource>());
        }

        private Response HandleCreate(dynamic parameters)
        {
            if (!Request.Form.url.HasValue)
                return Response.BadRequest();

            var urlOriginal = Request.Form.url;
            var url = new Model.Url(urlOriginal);
            storage.Insert(url);

            return Response.Created(url.Short);
        }
    }
}