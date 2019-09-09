using System;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MyMind.Web.Database;
using MyMind.Web.IoC;
using Swashbuckle.AspNetCore.Swagger;

namespace MyMind.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        private IContainer? ApplicationContainer { get; set; }

        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("MyPolicy", options =>
            {
                options.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo{Title = "My Mind", Version = "v1"});
            });

            var builder = new ContainerBuilder();
            builder.Populate(services);
            builder.RegisterModule(new ContainerModule(Configuration));
            ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(ApplicationContainer);
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            MongoConfiguration.Initialize();
            app.UseSwagger();
            app.UseCors("MyPolicy");

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                c.RoutePrefix = "";
            });

            app.UseStaticFiles();
            app.UseRouting();
            app.UseEndpoints(routes =>
            {
                routes.MapControllerRoute(
                    "default",
                    "/api/{controller}/{action=Index}/{id?}");
            });
        }
    }
}
