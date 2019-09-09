using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MyMind.Web.Domain;

namespace MyMind.Infrastructure.MongoDB
{
    public class Session : ISession
    {
        private readonly IMongoDatabase _database;

        public Session(IMongoDatabase database)
        {
            _database = database;
        }

        public T Get<T>(Guid id) where T : Aggregate
        {
            return this.Get<T>().FirstOrDefault(x => x.Id == id);
        }

        public IQueryable<T> Get<T>() where T : Aggregate
        {
            return this.GetCollection<T>().AsQueryable();
        }

        public void Add<T>(T entity) where T : Aggregate
        {
            this.GetCollection<T>().InsertOne(entity);
        }

        public void AddOrUpdate<T>(T entity) where T : Aggregate
        {
            if (this.Get<T>(entity.Id) != null)
            {
                this.Add(entity);
            }
            else
            {
                this.Update(entity);
            }
        }

        public void Update<T>(T entity) where T : Aggregate
        {
            this.GetCollection<T>().ReplaceOne(x => x.Id == entity.Id, entity);
        }

        public void Delete<T>(T entity) where T : Aggregate
        {
            this.GetCollection<T>().DeleteOne(x => x.Id == entity.Id);
        }

        public void SaveChanges()
        {
            //use on database change
        }

        public void Dispose()
        {
            //use on database change
        }

        private IMongoCollection<T> GetCollection<T>() where T : Aggregate
        {
            return _database.GetCollection<T>($"{typeof(T).Name}s");
        }
    }
}
