using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("TESTMEASUREMENT")]
    public class TestMeasurement
    {
        [Key]
        [Display(Name = "Test Material ID")]
        public int TESTMATERIALID { get; set; }

        [Required]
        [Display(Name = "Compound LT ID")]
        [StringLength(6, MinimumLength = 6)]
        public string COMPOUNDLTID { get; set; }
        [Required]
        [Display(Name = "Compound Sequence Code")]
        public int COMPOUNDSEQCODE { get; set; }
        [ForeignKey("COMPOUNDLTID,COMPOUNDSEQCODE")]
        public virtual Sample Sample { get; set; }

        [Required]
        [Display(Name = "Concentration")]
        public double CONCENTRATION { get; set; }

        [Required]
        [Display(Name = "Assay ID")]
        public int ASSAYID { get; set; }
    }
}