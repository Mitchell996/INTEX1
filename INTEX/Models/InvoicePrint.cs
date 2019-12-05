using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    public class InvoicePrint
    {
        [Key]
        public int InvoiceID { get; set; }

        public string EmployeeAssigned { get; set; }
        public string TestDescription { get; set; }
        public int HoursToComplete { get; set; }
        public double BasePrice { get; set; }
        public double QuantityNeeded { get; set; }
        public double MaterialPrice { get; set; }

    }
}