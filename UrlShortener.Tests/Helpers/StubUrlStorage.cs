using System;
using System.Collections.Generic;
using System.Linq;
using UrlShortener.Web.Repositories;
using Model = UrlShortener.Web.Model;

namespace UrlShortener.Tests.Helpers
{
    public class StubUrlStorage : IUrlStorage
    {
        private IList<Model.Url> urls;

        public StubUrlStorage(params Model.Url[] urls)
        {
            this.urls = new List<Model.Url>(urls);
        }

        public void Insert(Model.Url url)
        {
            urls.Add(url);
        }

        public Model.Url Get(string urlShortened)
        {
            return urls.SingleOrDefault(_ => _.Short == urlShortened);
        }
    }
}
