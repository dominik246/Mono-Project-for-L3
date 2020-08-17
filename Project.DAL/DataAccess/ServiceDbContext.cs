using Microsoft.EntityFrameworkCore;

using Project.DAL.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.DataAccess
{
    public class ServiceDbContext : DbContext, IServiceDbContext
    {
        public ServiceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<VehicleMake> VehicleMakes { get; set; }
        public DbSet<VehicleModel> VehicleModels { get; set; }
    }
}
