using AutoMapper;

using Project.Common.Models;
using Project.Model;
using Project.Model.Common;

namespace Project.Common.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap(typeof(PageRepositoryModel<>), typeof(PageServiceModel<>));
            CreateMap(typeof(PageServiceModel<>), typeof(PageServiceModel<>));
            CreateMap<VehicleMakeRepoModel, VehicleMakeServiceModel>();
            CreateMap<VehicleMakeServiceModel, VehicleMakeRepoModel>();
        }
    }
}
