using Project.Repository.Common;

using System.Threading.Tasks;

namespace Project.DAL.DataAccess
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}