using Microsoft.EntityFrameworkCore;

using Project.DAL.Models;

namespace Project.DAL.DataAccess
{
    public interface IServiceDbContext
    {
        DbSet<VehicleMake> VehicleMakes { get; set; }
        DbSet<VehicleModel> VehicleModels { get; set; }
    }
}