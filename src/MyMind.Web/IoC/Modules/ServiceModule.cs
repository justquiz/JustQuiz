using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using MyMind.Web.Domain.Emotions.Services;

namespace MyMind.Web.IoC
{
    public class ServiceModule : Module
    {
        public ServiceModule()
        {
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IEmotionsService>()
                .As<IEmotionsService>()
                .InstancePerLifetimeScope();
        }
    }
}
