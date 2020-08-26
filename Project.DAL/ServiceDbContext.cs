using Microsoft.EntityFrameworkCore;

using Project.Model;
using Project.Model.Common;

namespace Project.DAL
{
    public class ServiceDbContext : DbContext, IServiceDbContext
    {

        public ServiceDbContext(DbContextOptions options) : base(options) { }

        public DbSet<VehicleMakeRepoModel> VehicleMakes { get; set; }
        public DbSet<VehicleModelRepoModel> VehicleModels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<VehicleMakeRepoModel>()
                .HasMany(m => m.VehicleModelCollection)
                .WithOne(m => m.SelectedVehicleMake as VehicleMakeRepoModel)
                .HasForeignKey(m => m.MakeId);

        }
    }
}
