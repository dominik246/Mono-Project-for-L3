using System;
using System.Threading.Tasks;

namespace Project.DAL.DataAccess
{
    public interface IUnitOfWork
    {
        IVehicleService VehicleService { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}