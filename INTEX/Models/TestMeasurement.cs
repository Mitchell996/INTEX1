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
        [ForeignKey("SAMPLE"), Column(Order = 1)]
        public int COMPOUNDLTID { get; set; }
        [Required]
        [Display(Name = "Compound Sequence Code")]
        [ForeignKey("SAMPLE"), Column(Order = 1)]
        public int COMPOUNDSEQCODE { get; set; }

        public virtual Sample Sample { get; set; }

        [Required]
        [Display(Name = "Concentration")]
        public double CONCENTRATION { get; set; }

        [Required]
        [Display(Name = "Assay ID")]
        public int ASSAYID { get; set; }
    }
}