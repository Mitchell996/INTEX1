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
        [Stringlength(6,minimumLength= 6)]
        [Display(Name = "Compound LT ID")]
        public int COMPOUNDLTID { get; set; }
        [Required]
        [Display(Name = "Compound Sequence Code")]
        public int COMPOUNDSEQCODE { get; set; }

        [Required]
        [Display(Name = "Concentration")]
        public double CONCENTRATION { get; set; }

        [Required]
        [Display(Name = "Assay ID")]
        public int ASSAYID { get; set; }
    }
}