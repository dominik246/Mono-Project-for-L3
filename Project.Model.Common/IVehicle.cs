﻿namespace Project.Model.Common
{
    public interface IVehicle
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IVehicle SelectedVehicleMake { get; set; }
    }
}
