using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("ASSAY")]
    public class Assay
    {
        [Key]
        public int ASSAYID { get; set; }
        public string RESULT { get; set; }
        public string COMMENTS { get; set; }
        public int TESTID { get; set; }
    }
}