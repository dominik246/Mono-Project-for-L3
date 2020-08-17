using System;
using System.Collections.Generic;
using System.Text;

namespace Project.DAL.Models
{
    public interface IVehicle
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        VehicleMake SelectedVehicleMake { get; set; }
    }
}
