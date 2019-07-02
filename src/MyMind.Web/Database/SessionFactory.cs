using MongoDB.Driver;

namespace MyMind.Web.Database
{
    public class SessionFactory : ISessionFactory
    {
        private readonly IMongoDatabase _database;

        public SessionFactory(IMongoDatabase database)
        {
            _database = database;
        }

        public ISession Create()
        {
            return new Session(this._database);
        }
    }
}
