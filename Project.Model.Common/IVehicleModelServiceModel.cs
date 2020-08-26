namespace Project.Model.Common
{
    public interface IVehicleModelServiceModel : IVehicle
    {
        int MakeId { get; set; }
        new int Id { get; set; }
        new string Name { get; set; }
        new string Abrv { get; set; }
        new IVehicleMakeRepoModel SelectedVehicleMake { get; set; }
    }
}