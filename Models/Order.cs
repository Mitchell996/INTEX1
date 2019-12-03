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
        public int CUSTOMERID { get; set; }
        public string ORDERCOMMENTS { get; set; }
        public string ORDERPROGRESS { get; set; }
    }
}