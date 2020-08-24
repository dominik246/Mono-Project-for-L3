using Project.Repository.Common;

using System.Threading.Tasks;

namespace Project.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceDbContext _dbContext;
        public IVehicleRepository VehicleRepository { get; }

        public UnitOfWork(IVehicleRepository vehicleRepository, IServiceDbContext dbContext)
        {
            VehicleRepository = vehicleRepository;
            _dbContext = dbContext;
        }


        public async Task<int> CommitAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbContext.DisposeAsync();
        }
    }
}
