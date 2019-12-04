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
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EMPLOYEEID { get; set; }

        [Required(ErrorMessage = "Please the Employee First Name")]
        [Display(Name = "First Name")]
        public string EMPFIRSTNAME { get; set; }

        [Required(ErrorMessage = "Please the Employee Last Name")]
        [Display(Name = "Last Name")]
        public string EMPLASTNAME { get; set; }

        [Required(ErrorMessage = "Please the Employee Hourly Wage")]
        [Display(Name = "Hourly Wage")]
        public int HOURLYWAGE { get; set; }

    }
}