namespace Project.Model.Common
{
    public interface IVehicleModel : IVehicle
    {
        new string Abrv { get; set; }
        new int Id { get; set; }
        int MakeId { get; set; }
        new string Name { get; set; }
    }
}