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

        public UnitOfWork(IVehicleService vehicleService)
        {
            VehicleService = vehicleService;
        }

        public IVehicleService VehicleService { get; }


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
