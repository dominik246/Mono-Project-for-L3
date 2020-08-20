using AutoMapper;

using Project.Common.Models;

namespace Project.Common.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap(typeof(PageRepositoryModel<>), typeof(PageServiceModel<>));
        }
    }
}
