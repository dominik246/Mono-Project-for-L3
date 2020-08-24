using System.Collections.Generic;

namespace Project.Model.Common
{
    public interface IVehicleMake : IVehicle
    {
        new string Abrv { get; set; }
        new int Id { get; set; }
        new string Name { get; set; }
    }
}