using System;
using System.Linq;
using MyMind.Web.Domain;

namespace MyMind.Web.Database
{
    public interface ISession : IDisposable
    {
        T Get<T>(Guid id) where T : Aggregate;
        IQueryable<T> Get<T>() where T : Aggregate;
        void Add<T>(T entity) where T : Aggregate;
        void AddOrUpdate<T>(T entity) where T : Aggregate;
        void Update<T>(T entity) where T : Aggregate;
        void Delete<T>(T entity) where T : Aggregate;
        void SaveChanges();
    }
}
