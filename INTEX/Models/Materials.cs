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
        public string MATDESC { get; set; }
        public double QUANTITYAVAILABLE { get; set; }//set a reminder to replace this when below 100mg or something
        public int REUSABLE { get; set; }//like do we need to replace the substance?  
        public double COST { get; set; }//cost per mg
    }
}