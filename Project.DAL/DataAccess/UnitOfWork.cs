using Project.Repository.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project.DAL.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IServiceDbContext _dbContext;

        public UnitOfWork(IVehicleRepository vehicleRepository, IServiceDbContext dbContext)
        {
            VehicleRepository = vehicleRepository;
            _dbContext = dbContext;
        }

        public IVehicleRepository VehicleRepository { get; }

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
