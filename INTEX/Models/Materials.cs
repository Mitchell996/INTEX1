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
        public Double QUANTITYAVAILABLE { get; set; }
        public int REUSABLE { get; set; }
    }
}