using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using Project.Model;

using System;
using System.Threading;
using System.Threading.Tasks;

namespace Project.DAL
{
    public interface IServiceDbContext
    {
        DbSet<VehicleMakeRepoModel> VehicleMakes { get; set; }
        DbSet<VehicleModelRepoModel> VehicleModels { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default);
        DbSet<TModel> Set<TModel>() where TModel : class;
        IModel Model { get; }
        ValueTask DisposeAsync();
    }
}