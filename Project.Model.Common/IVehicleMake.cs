using System.Collections.Generic;

namespace Project.Model
{
    public interface IVehicleMake
    {
        string Abrv { get; set; }
        int Id { get; set; }
        string Name { get; set; }
    }
}