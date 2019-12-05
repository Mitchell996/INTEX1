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
        public OrderTest()
        {

        }
        public OrderTest(int testToAdd, int orderToAdd)
        {
            ORDERID = orderToAdd;
            TESTID = testToAdd;
            //EMPLOYEEID = null;
        }

        [Key]
        public int ORDERTESTID { get; set; }

        //[Required(ErrorMessage = "Please select the Employee assigned to the test from the dropdown list")]
        [Display(Name = "Employee Assigned")]
        public int? EMPLOYEEID { get; set; }
        [ForeignKey("EMPLOYEEID")]
        public virtual  Employee Employee { get; set; }

        [Required(ErrorMessage = "Please select the Test Type from the dropdown list")]
        [Display(Name = "Test Performed")]
        public int TESTID { get; set; }
        [ForeignKey("TESTID")]
        public virtual Test Test { get; set; }

        [Display(Name = "Order Number")]
        public int ORDERID { get; set; }
        [ForeignKey("ORDERID")]
        public virtual Order Order { get; set; }


    }
}