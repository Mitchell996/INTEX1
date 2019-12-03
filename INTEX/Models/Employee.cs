using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("EMPLOYEE")]
    public class Employee
    {
        [Key]
        public int EMPLOYEEID { get; set; }
        public string EMPFIRSTNAME { get; set; }
        public string EMPLASTNAME { get; set; }
        public int HOURLYWAGE { get; set; }

    }
}