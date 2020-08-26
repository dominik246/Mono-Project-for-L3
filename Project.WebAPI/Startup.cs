
using Autofac;

using AutoMapper;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Project.Common.Models;
using Project.Common.Profiles;
using Project.DAL;
using Project.Repository;
using Project.Repository.Common;
using Project.Service;
using Project.Service.Common;

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
            services.AddAutoMapper(typeof(Startup), typeof(VehicleProfile));
            services.AddControllers();
            services.AddOptions();
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
            builder
                .RegisterType<VehicleService>()
                .As<IVehicleService>()
                .InstancePerLifetimeScope();
            builder
                .RegisterGeneric(typeof(PageServiceModel<>))
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
