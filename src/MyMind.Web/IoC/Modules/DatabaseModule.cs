using System.Reflection;
using System.Threading;
using Autofac;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MyMind.Web.Database;

namespace MyMind.Web.IoC.Modules
{
    public class DatabaseModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public DatabaseModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register((c, p) => new MongoClient(_configuration["MongoDB:ConnectionString"])) //todo move to appsettings.json
                .SingleInstance();

            builder.Register((c, p) =>
            {
                var client = c.Resolve<MongoClient>();
                var database = client.GetDatabase(_configuration["MongoDB:Database"]); //todo move to appsettings.json

                return database;
            }).As<IMongoDatabase>();

            builder.RegisterType<Session>().As<ISession>();
            builder.RegisterType<SessionFactory>().As<ISessionFactory>();
        }
    }
}
