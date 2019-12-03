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
        public int TESTMATERIALID { get; set; }
        public int COMPOUNDLTID { get; set; }
        public int COMPOUNDSEQCODE { get; set; }
        public double CONCENTRATION { get; set; }
        public int ASSAYID { get; set; }
    }
}