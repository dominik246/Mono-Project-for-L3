using FluentAssertions;

using Moq;

using Project.Common.Models;
using Project.Model;
using Project.Model.Common;
using Project.Service.Common;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Xunit;

namespace Project.Service.Tests
{
    public class VehicleServiceTests
    {
        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeReturnedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            IVehicleMakeRepoModel make = new VehicleMakeRepoModel()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModelRepoModel model = new VehicleModelRepoModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var vehicleService = new Mock<IVehicleService>();
            vehicleService.Setup(s => s.GetAsync<IVehicleModelRepoModel>(modelId)).ReturnsAsync(model);
            var result = await vehicleService.Object.GetAsync<IVehicleModelRepoModel>(modelId);

            result.Should().NotBeNull();
            result.Abrv.Should().Be(modelAbrv);
            result.Name.Should().Be(modelName);
            result.SelectedVehicleMake.Name.Should().Be(makeName);
            vehicleService.Verify(x => x.GetAsync<IVehicleModelRepoModel>(modelId), Times.Once());
        }
        
        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeCreatedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            IVehicleMakeRepoModel make = new VehicleMakeRepoModel()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModelRepoModel model = new VehicleModelRepoModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var vehicleService = new Mock<IVehicleService>();
            vehicleService.Setup(s => s.CreateAsync(model));
            await vehicleService.Object.CreateAsync(model);
            vehicleService.Verify(c => c.CreateAsync(model), Times.Once());
        }

        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeDeletedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            IVehicleMakeRepoModel make = new VehicleMakeRepoModel()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModelRepoModel model = new VehicleModelRepoModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var vehicleService = new Mock<IVehicleService>();
            vehicleService.Setup(s => s.DeleteAsync<IVehicleModelRepoModel>(modelId));
            await vehicleService.Object.DeleteAsync<IVehicleModelRepoModel>(modelId);
            vehicleService.Verify(c => c.DeleteAsync<IVehicleModelRepoModel>(modelId), Times.Once());
        }
    
        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeUpdatedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            IVehicleMakeRepoModel make = new VehicleMakeRepoModel()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModelRepoModel model = new VehicleModelRepoModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var vehicleService = new Mock<IVehicleService>();
            vehicleService.Setup(s => s.UpdateAsync(model));
            await vehicleService.Object.UpdateAsync(model);
            vehicleService.Verify(s => s.UpdateAsync(model), Times.Once());
        }
    
        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehiclesShouldAllBeFoundOrderedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            List<IVehicleMakeRepoModel> makeList = new List<IVehicleMakeRepoModel>();
            List<IVehicleModelRepoModel> modelList = new List<IVehicleModelRepoModel>();

            await Task.Run(() =>
            {

                for (int i = 0; i < 10; i++)
                {
                    makeList.Add(new VehicleMakeRepoModel()
                    {
                        Name = makeName + i,
                        Abrv = makeAbrv + i,
                        Id = makeId + i
                    });
                    
                    modelList.Add(new VehicleModelRepoModel()
                    {
                        Name = modelName + i,
                        Abrv = modelAbrv + i,
                        Id = modelId + i,
                        MakeId = makeId + i
                    });
                }
            });

            var pagedModel = new PageServiceModel<IVehicleModelRepoModel>() { QueryResult = modelList };

            var vehicleService = new Mock<IVehicleService>();

            vehicleService.Setup(s => s.FindAsync<IVehicleModelRepoModel>(null, null, null)).ReturnsAsync(pagedModel);
            var result = await vehicleService.Object.FindAsync<IVehicleModelRepoModel>(null, null, null);
            vehicleService.Verify(c => c.FindAsync<IVehicleModelRepoModel>(null, null, null), Times.Once());
            result.Should().NotBeNull();
            result.QueryResult.Should().NotBeNull();
            result.QueryResult.Should().HaveCount(10);
            result.QueryResult.Should().AllBeAssignableTo<IVehicleModelRepoModel>();
            result.QueryResult.Should().NotContainNulls();
            result.QueryResult.Should().BeInAscendingOrder(x => x.Name);
        }
    }
}
