using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("ORDERTEST")]
    public class OrderTest
    {
        [Key]
        public int ORDERTESTID { get; set; }

        [Required(ErrorMessage = "Please select the Employee assigned to the test from the dropdown list")]
        [Display(Name = "Employee Assigned")]
        public int EMPLOYEEID { get; set; }

        [Required(ErrorMessage = "Please select the Test Type from the dropdown list")]
        [Display(Name = "Test Performed")]
        public int TESTID { get; set; }

        [Display(Name = "Order Number")]
        public int ORDERID { get; set; }


    }
}