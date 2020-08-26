using Project.Model.Common;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Model
{
    public class VehicleMakeRepoModel : IVehicleMakeRepoModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(20)")]
        public string Abrv { get; set; }

        public ICollection<VehicleModelRepoModel> VehicleModelCollection { get; set; }
        
        [NotMapped]
        IVehicleMakeRepoModel IVehicle.SelectedVehicleMake { get; set; }
    }
}
