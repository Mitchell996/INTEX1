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
        [Display(Name = "Test ID")]
        public int TESTID { get; set; }
        [Required]
        [Display(Name = "Employee ID")]
        public int EMPLOYEEID { get; set; }
        [ForeignKey("EmployeeID")]
        public virtual Employee Employee { get; set; }
        [Required]
        [Display(Name = "Hours To Complete")]
        public int HOURSTOCOMPLETE { get; set; }
        [Required]
        [Display(Name = "Base Price")]
        public double BASEPRICE { get; set; }
        [Required]
        [Display(Name = "Number Of Days")]
        public int NUMBEROFDAYS { get; set; }
        [Required]
        [Display(Name = "Test Description")]
        public string TESTDESCRIPTION { get; set; }
        [Required]
        public int PROGRESS { get; set; }//-1 if not started, 0 if in progress, 1 if completed
        public int? TESTCONDITIONAL { get; set; }//ID to what the conditional test might be.
        [ForeignKey("TestConditional")]
        public virtual Test Tes { get; set; }

    }
}