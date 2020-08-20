using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Autofac;

using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Project.Common.Models;
using Project.DAL.DataAccess;
using Project.Repository;
using Project.Repository.Common;

namespace Project.WebAPI
{
    public class Startup
    {
        public Startup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }
        public ILifetimeScope AutofacContainer { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddControllers();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var dbContextOptions = new DbContextOptionsBuilder().UseSqlServer(Configuration.GetConnectionString("default"));

            builder
                .RegisterType<ServiceDbContext>()
                .As<IServiceDbContext>()
                .WithParameter("options", dbContextOptions.Options)
                .InstancePerLifetimeScope();
            builder
                .RegisterType<VehicleRepository>()
                .As<IVehicleRepository>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<UnitOfWork>()
                .As<IUnitOfWork>()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<SortModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder
                .RegisterType<FilterModel>()
                .AsSelf()
                .InstancePerLifetimeScope();
            builder
                .RegisterGeneric(typeof(PageRepositoryModel<>))
                .AsSelf()
                .InstancePerLifetimeScope();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
