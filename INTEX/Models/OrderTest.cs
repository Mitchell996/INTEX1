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
        public int EMPLOYEEID { get; set; }
        public int TESTID { get; set; }
        public int ORDERID { get; set; }


    }
}