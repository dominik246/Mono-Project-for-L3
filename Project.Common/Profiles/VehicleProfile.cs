using AutoMapper;

using Project.Common.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
