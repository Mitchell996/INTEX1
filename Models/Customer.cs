using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("CUSTOMER")]
    public class Customer
    {
        [Key]
        private int CustomerID;
        public String CustName;
        public String Address;
        public String CustCity { get; set; }
        public String CustState { get; set; }
        public String CustEmail { get; set; }
        public String CUSTPHONE { get; set; }
        public string CustRouting { get; set; }
    }
}