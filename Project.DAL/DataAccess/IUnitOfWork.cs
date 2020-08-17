using System;
using System.Threading.Tasks;

namespace Project.DAL.DataAccess
{
    public interface IUnitOfWork
    {
        IVehicleService VehicleService { get; }

        Task CommitAsync();
        Task RollbackAsync();
    }
}