using Project.Repository.Common;

using System.Threading.Tasks;

namespace Project.Repository.Common
{
    public interface IUnitOfWork
    {
        IVehicleRepository VehicleRepository { get; }

        Task<int> CommitAsync();
        Task RollbackAsync();
    }
}