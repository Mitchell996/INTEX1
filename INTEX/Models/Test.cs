using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("TEST")]
    public class Test
    {
        [Key]
        public int TESTID { get; set; }
        public int EMPLOYEEID { get; set; }
        public int HOURSTOCOMPLETE { get; set; }
        public double BASEPRICE { get; set; }
        public int NUMBEROFDAYS { get; set; }
        public string TESTDESCRIPTION { get; set; }
        public int PROGRESS { get; set; }//-1 if not started, 0 if in progress, 1 if completed
        public int? TESTCONDITIONAL { get; set; }//ID to what the conditional test might be.

    }
}