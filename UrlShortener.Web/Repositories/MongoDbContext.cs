using System;
using System.Collections.Generic;
using UrlShortener.Web.Helpers;
using MongoDB.Driver;

namespace UrlShortener.Web.Repositories
{
    public class MongoDbContext
    {
        private string connectionString;

        public MongoDbContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public MongoCollection<TEntity> GetCollection<TEntity>()
        {
            var collectionName = GetCollectionName<TEntity>();

            return GetDatabase()
                .GetCollection<TEntity>(collectionName);
        }

        private MongoDatabase GetDatabase()
        {
            return GetDatabase(new MongoUrl(connectionString));
        }

        private MongoDatabase GetDatabase(MongoUrl url)
        {
            var server = MongoServer.Create(url.ToServerSettings());
            return server.GetDatabase(url.DatabaseName);
        }

        private string GetCollectionName<TEntity>()
        {
            return typeof(TEntity).Name.Pluralize();
        }
    }
}