using System.Collections.Generic;

namespace Project.Model.Common
{
    public interface IVehicleMakeRepoModel : IVehicle
    {
        new int Id { get; set; }
        new string Name { get; set; }
        new string Abrv { get; set; }
    }
}