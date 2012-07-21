using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nancy;
using UrlShortener.Web.Resources;

namespace UrlShortener.Web.Helpers
{
    public static class ResponseHelpers
    {
        public static Response Created(this IResponseFormatter formatter, string identifier)
        {
            Response response = HttpStatusCode.Created;
            var address = formatter.Context.Request.Url;
            var location = new LocationResource(address, identifier);
            return response.WithHeader("Location", location);
        }

        public static Response BadRequest(this IResponseFormatter formatter)
        {
            Response response = "";
            response.StatusCode = HttpStatusCode.BadRequest;
            return response;
        }

        public static Response NotFound(this IResponseFormatter formatter)
        {
            Response response = "";
            response.StatusCode = HttpStatusCode.NotFound;
            return response;
        }
    }
}