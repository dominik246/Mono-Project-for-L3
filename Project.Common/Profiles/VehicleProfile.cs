using AutoMapper;

using Project.Common.Models;
using Project.Model.Common;

namespace Project.Common.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap(typeof(PageRepositoryModel<>), typeof(PageServiceModel<>));
            //CreateMap(typeof(PageServiceModel<>), typeof(PageRepositoryModel<>))
            //    .ForMember("QueryResult", m => m.Ignore())
            //    .ForMember("ReturnPaged", m => m.Ignore());
            CreateMap<IVehicleMakeRepoModel, IVehicleMakeServiceModel>();
            CreateMap<IVehicleModelRepoModel, IVehicleModelServiceModel>();
            CreateMap<IVehicleMakeServiceModel, IVehicleMakeRepoModel>();
            CreateMap<IVehicleModelServiceModel, IVehicleModelRepoModel>();
        }
    }
}
