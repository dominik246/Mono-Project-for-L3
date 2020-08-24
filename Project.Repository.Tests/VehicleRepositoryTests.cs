using FluentAssertions;

using Microsoft.EntityFrameworkCore;

using Moq;

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
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeAddedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            VehicleMake make = new VehicleMake()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            VehicleModel model = new VehicleModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var unitOfWork = new Mock<IUnitOfWork>();

            unitOfWork.Setup(u => u.VehicleRepository.GetAsync<VehicleModel>(1)).ReturnsAsync(model);

            var result = await unitOfWork.Object.VehicleRepository.GetAsync<VehicleModel>(1);

            result.Should().NotBeNull();
            result.Abrv.Should().Be(modelAbrv);
            result.Name.Should().Be(modelName);
            result.SelectedVehicleMake.Name.Should().Be(makeName);
        }
    }
}
