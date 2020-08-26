using Project.Model.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Model
{
    public class VehicleModelServiceModel : IVehicleModelServiceModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Make Name")]
        public int MakeId { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Model Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }
        
        [Display(Name = "Selected Vehicle Make")]
        public IVehicleMakeRepoModel SelectedVehicleMake { get; set; }
    }
}
