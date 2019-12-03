using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("MATERIALS")]
    public class Materials
    {
        [Key]
        public int MATERIALID { get; set; }

        [Required(ErrorMessage = "Please the material name")]
        [Display(Name = "Material Name")]
        public string MATDESC { get; set; }

        [Required(ErrorMessage = "Please the current Quantity Available")]
        [Display(Name = "Quanityt Available")]
        public double QUANTITYAVAILABLE { get; set; }//set a reminder to replace this when below 100mg or something

        [Required(ErrorMessage = "Please select whether the material is reusable (Microscope, Petri Dishes, etc)")]
        [Display(Name = "Reusable")]
        public int REUSABLE { get; set; }//like do we need to replace the substance?  

        [Display(Name = "Cost Per Miligram (if not reusable)")]
        public double COST { get; set; }//cost per mg
    }
}