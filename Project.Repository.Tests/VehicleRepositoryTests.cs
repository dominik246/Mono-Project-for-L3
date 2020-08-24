using FluentAssertions;

using Microsoft.EntityFrameworkCore;

using Project.DAL;
using Project.Model;
using Project.Repository.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Project.Repository.Tests
{
    public class VehicleRepositoryTests
    {
        DbContextOptions<ServiceDbContext> options = new DbContextOptionsBuilder<ServiceDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()).Options;

        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7")]
        public async Task VehicleShouldBeAddedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv)
        {
            VehicleMake make = new VehicleMake()
            {
                Name = makeName,
                Abrv = makeAbrv
            };

            VehicleModel model = new VehicleModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                MakeId = 1
            };
            
            await using(IServiceDbContext dbContext = new ServiceDbContext(options))
            {
                IVehicleRepository vehicleRepository = new VehicleRepository(dbContext);
                IUnitOfWork unitofWork = new UnitOfWork(vehicleRepository, dbContext);

                await unitofWork.VehicleRepository.CreateAsync(make);
                await unitofWork.VehicleRepository.CreateAsync(model);
                await unitofWork.CommitAsync();


            }

            await using(IServiceDbContext dbContext = new ServiceDbContext(options))
            {
                IVehicleRepository vehicleRepository = new VehicleRepository(dbContext);
                IUnitOfWork unitofWork = new UnitOfWork(vehicleRepository, dbContext);

                VehicleModel result = await unitofWork.VehicleRepository.GetAsync<VehicleModel>(1);

                result.Should().NotBeNull();
                result.Id.Should().Be(1);
                result.Name.Should().Be(modelName);
                result.SelectedVehicleMake.Name.Should().Be(makeName);
            }
        }
    }
}
