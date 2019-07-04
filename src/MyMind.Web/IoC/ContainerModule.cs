using Autofac;
using Microsoft.Extensions.Configuration;
using MyMind.Web.IoC.Modules;

namespace MyMind.Web.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new DatabaseModule(this._configuration));
            builder.RegisterModule(new ServiceModule());
        }
    }
}
