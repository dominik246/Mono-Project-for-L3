﻿using Project.Model.Common;

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Model
{
    public class VehicleMake : IVehicle
    {
        [Display(Name = "ID")]
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column(TypeName = "nvarchar(50)")]
        [Display(Name = "Make Name")]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        [Column(TypeName = "nvarchar(20)")]
        [Display(Name = "Abbreviation")]
        public string Abrv { get; set; }

        public virtual ICollection<VehicleModel> VehicleModelCollection { get; set; }

        [NotMapped]
        IVehicle IVehicle.SelectedVehicleMake { get; set; }
    }
}
