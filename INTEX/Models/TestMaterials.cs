using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("TESTMATERIALS")]
    public class TestMaterials
    {
        [Key]
        [Display(Name = "Test Material ID")]
        public int TESTMATERIALID { get; set; }
        [Required]
        [Display(Name = "Material ID")]
        public int MATERIALID { get; set; }
        [ForeignKey("MATERIALID")]
        public virtual Materials Materials { get; set; }
        [Required]
        [Display(Name = "Test ID")]
        public int TESTID { get; set; }
        [ForeignKey("TESTID")]
        public virtual Test Test { get; set; }
        [Required]
        [Display(Name = "Quantity Needed")]
        public double QUANTITYNEEDED { get; set; }
    }
}