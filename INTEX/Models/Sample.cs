using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("SAMPLE")]
    public class Sample
    {
        [Key, Column(Order = 0)]
        [Display(Name = "Compound LT ID")]
        public int COMPOUNDLTID { get; set; }
        [Key, Column(Order = 1)]
        [Display(Name = "Compound Sequence Code")]
        public int COMPOUNDSEQCODE { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public int ORDERID { get; set; }
        [Required]
        [Display(Name = "Recieved By")]
        public int RECEIVEDBY { get; set; }//Hold's employeeID
        [Required]
        [Display(Name = "Compound Name")]
        public string COMPOUNDNAME { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public double QUANTITY { get; set; }
        [Required]
        [Display(Name = "Date Arrived")]
        public DateTime DATEARRIVED { get; set; }
        [Required]
        [Display(Name = "Due Date")]
        public DateTime DUEDATE { get; set; }
        [Required]
        [Display(Name = "Appearance")]
        public string APPEARANCE { get; set; }
        [Required]
        [Display(Name = "Client Weight")]
        public double CLIENTWEIGHT { get; set; }
        [Required]
        [Display(Name = "Molar Mass")]
        public double MOLARMASS { get; set; }
        [Required]
        [Display(Name = "Actual Weight")]
        public double ACTUALWEIGHT { get; set; }
        [Required]
        [Display(Name = "MTD")]
        public double MTD { get; set; }


    }
}