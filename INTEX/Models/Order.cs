using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{   
    [Table("ORDER")]
    public class Order
    {
        [Key]

        public int ORDERID { get; set; }

        
        [Required(ErrorMessage = "Please select the Customer from the dropdown list")]
        [Display(Name = "Customer")]
        public int CUSTOMERID { get; set; }
        [ForeignKey("CUSTOMERID")]
        public virtual Customer Customer { get; set; }


        [Display(Name = "Comments (optional)")]
        public string ORDERCOMMENTS { get; set; }

        [Required(ErrorMessage = "Please enter the number of tests completed / number of tests requested (i.e. 4/5)")]
        [Display(Name = "Progress (Number of tests completed / Number of tests requested (i.e. 4/5))x")]
        public string ORDERPROGRESS { get; set; }
    }
}