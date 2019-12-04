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
        [Required]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "Please enter your Company name")]
        [Display(Name = "Company Name")]
        public string CustName { get; set; }

        [Required(ErrorMessage = "Please enter your Street Address")]
        [Display(Name = "Street Address")]
        public string CustAddress { get; set; }
        [Required(ErrorMessage = "Please enter your city")]
        [Display(Name = "City")]
        public string CustCity { get; set; }

        [Required(ErrorMessage = "Please enter your State")]
        [Display(Name = "State Abbreviation (i.e. AZ)")]
        public string CustState { get; set; }

        [Required(ErrorMessage = "Please enter the email for your company contact")]
        [EmailAddress(ErrorMessage="Please enter a valid Email Address")]
        [Display(Name = "Contact Email")]
        public string CustEmail { get; set; }

        [Required(ErrorMessage = "Please enter your Company Phone")]
        [Display(Name = "Company Phone")]
        public string CustPhone { get; set; }

        [Required(ErrorMessage = "Please enter your Company Routing Number")]
        [Display(Name = "Routing Number")]
        public string CustRouting { get; set; }
    }
}