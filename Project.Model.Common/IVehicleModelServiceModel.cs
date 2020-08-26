using Project.Model.Common;

namespace Project.Model.Common
{
    public interface IVehicleModelServiceModel : IVehicle
    {
        int MakeId { get; set; }
    }
}