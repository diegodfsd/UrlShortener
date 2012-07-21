using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UrlShortener.Web.Repositories
{
    public class UrlStoragecs : MongoDbRepository<Model.Url>, IUrlStorage
    {
        const string MONGODB_CONNECTIONSTRING = @"mongodb://localhost/urls?safe=true";

        public UrlStoragecs()
            : base(MONGODB_CONNECTIONSTRING)
        {
        }

        public void Insert(Model.Url url)
        {
            Save(url);
        }

        public Model.Url Get(string urlShortened)
        {
            return FindOneBy(_ => _.Short == urlShortened);
        }
    }
}