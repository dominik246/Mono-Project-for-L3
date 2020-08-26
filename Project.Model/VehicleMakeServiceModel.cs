using Project.Model.Common;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Project.Model
{
    public class VehicleMakeServiceModel : IVehicleMakeServiceModel
    {
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Make Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }
        
        IVehicleMakeRepoModel IVehicle.SelectedVehicleMake { get; set; }
    }
}
