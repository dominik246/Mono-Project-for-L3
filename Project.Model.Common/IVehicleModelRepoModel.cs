namespace Project.Model.Common
{
    public interface IVehicleModelRepoModel : IVehicle
    {
        int MakeId { get; set; }
        new int Id { get; set; }
        new string Name { get; set; }
        new string Abrv { get; set; }
    }
}