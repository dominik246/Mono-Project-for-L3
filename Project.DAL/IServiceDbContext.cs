using Microsoft.EntityFrameworkCore;

using Project.DAL.Models;

namespace Project.DAL
{
    public interface IServiceDbContext
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
    }
}