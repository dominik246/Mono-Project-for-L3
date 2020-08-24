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
            IVehicleMake make = new VehicleMake()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModel model = new VehicleModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var vehicleService = new Mock<IVehicleService>();
            vehicleService.Setup(s => s.GetAsync<IVehicleModel>(modelId)).ReturnsAsync(model);
            var result = await vehicleService.Object.GetAsync<IVehicleModel>(modelId);

            result.Should().NotBeNull();
            result.Abrv.Should().Be(modelAbrv);
            result.Name.Should().Be(modelName);
            result.SelectedVehicleMake.Name.Should().Be(makeName);
            vehicleService.Verify(x => x.GetAsync<IVehicleModel>(modelId), Times.Once());
        }
        
        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeCreatedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            IVehicleMake make = new VehicleMake()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModel model = new VehicleModel()
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
            IVehicleMake make = new VehicleMake()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModel model = new VehicleModel()
            {
                Name = modelName,
                Abrv = modelAbrv,
                Id = modelId,
                MakeId = make.Id,
                SelectedVehicleMake = make
            };

            var vehicleService = new Mock<IVehicleService>();
            vehicleService.Setup(s => s.DeleteAsync<IVehicleModel>(modelId));
            await vehicleService.Object.DeleteAsync<IVehicleModel>(modelId);
            vehicleService.Verify(c => c.DeleteAsync<IVehicleModel>(modelId), Times.Once());
        }
    
        [Theory]
        [InlineData("Volkswagen", "VW", "Golf 7", "Golf 7", 1, 1)]
        public async Task VehicleShouldBeUpdatedTheory(string makeName, string makeAbrv, string modelName, string modelAbrv, int makeId, int modelId)
        {
            IVehicleMake make = new VehicleMake()
            {
                Name = makeName,
                Abrv = makeAbrv,
                Id = makeId
            };

            IVehicleModel model = new VehicleModel()
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
            List<IVehicleMake> makeList = new List<IVehicleMake>();
            List<IVehicleModel> modelList = new List<IVehicleModel>();

            await Task.Run(() =>
            {

                for (int i = 0; i < 10; i++)
                {
                    makeList.Add(new VehicleMake()
                    {
                        Name = makeName + i,
                        Abrv = makeAbrv + i,
                        Id = makeId + i
                    });
                    
                    modelList.Add(new VehicleModel()
                    {
                        Name = modelName + i,
                        Abrv = modelAbrv + i,
                        Id = modelId + i,
                        MakeId = makeId + i
                    });
                }
            });

            var pagedModel = new PageServiceModel<IVehicleModel>() { QueryResult = modelList };

            var vehicleService = new Mock<IVehicleService>();

            vehicleService.Setup(s => s.FindAsync<IVehicleModel>(null, null, null)).ReturnsAsync(pagedModel);
            var result = await vehicleService.Object.FindAsync<IVehicleModel>(null, null, null);
            vehicleService.Verify(c => c.FindAsync<IVehicleModel>(null, null, null), Times.Once());
            result.Should().NotBeNull();
            result.QueryResult.Should().NotBeNull();
            result.QueryResult.Should().HaveCount(10);
            result.QueryResult.Should().AllBeAssignableTo<IVehicleModel>();
            result.QueryResult.Should().NotContainNulls();
            result.QueryResult.Should().BeInAscendingOrder(x => x.Name);
        }
    }
}
