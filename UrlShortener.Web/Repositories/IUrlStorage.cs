using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UrlShortener.Web.Model;

namespace UrlShortener.Web.Repositories
{
    public interface IUrlStorage
    {
        void Insert(Url url);
        Url Get(string urlShortened);
    }
}
