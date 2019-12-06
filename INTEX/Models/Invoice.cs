using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("Invoice")]
    public class Invoice
    {

        
            [Key]
            public int INVOICEID { get; set; }
            [Required]
            public int ORDERID { get; set; }
            [Required]
            public double TOTALPRICE { get; set; }
            
            public double DISCOUNT { get; set; }


        
    }
}