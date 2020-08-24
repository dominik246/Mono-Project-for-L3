namespace Project.Model.Common
{
    public interface IVehicle
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        IVehicleMake SelectedVehicleMake { get; set; }
    }
}
