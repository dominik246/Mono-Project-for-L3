using Project.Model.Common;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Model
{
    public class VehicleModelRepoModel : IVehicleModelRepoModel
    {
        [Key]
        public int Id { get; set; }

        public IVehicleMakeRepoModel SelectedVehicleMake { get; set; }

        [Required]
        [ForeignKey(nameof(SelectedVehicleMake))]
        public int MakeId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Abrv { get; set; }
    }
}
