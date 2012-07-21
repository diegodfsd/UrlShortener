using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using MongoDB.Bson;
using System.Linq.Expressions;

namespace UrlShortener.Web.Repositories
{
    public abstract class MongoDbRepository<TEntity>
    {
        private readonly MongoCollection<TEntity> collection;

        protected MongoDbRepository(string connectionString)
        {
            var context = new MongoDbContext(connectionString);
            collection = context.GetCollection<TEntity>();
        }

        public IQueryable<TEntity> All()
        {
            return collection                
                .AsQueryable<TEntity>();
        }

        public IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> query)
        {
            return All().Where(query);
        }

        public TEntity FindOneBy(Expression<Func<TEntity, bool>> query)
        {
            return collection
                .AsQueryable<TEntity>()
                .SingleOrDefault(query);
        }

        public void Save(TEntity entity)
        {
            collection.Save(entity);
        }
    }
}