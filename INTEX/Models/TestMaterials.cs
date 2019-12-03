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
        public int TESTMATERIALID { get; set; }
        public int MATERIALID { get; set; }
        public int TESTID { get; set; }
        public double QUANTITYNEEDED { get; set; }
    }
}