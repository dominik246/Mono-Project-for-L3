namespace Project.Model.Common
{
    public interface IVehicleMakeServiceModel : IVehicle
    {
        new int Id { get; set; }
        new string Name { get; set; }
        new string Abrv { get; set; }
    }
}