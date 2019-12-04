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
        [StringLength(6, MinimumLength = 6)]
        public string COMPOUNDLTID { get; set; }
        [Key, Column(Order = 1)]
        [Display(Name = "Compound Sequence Code")]
        public int COMPOUNDSEQCODE { get; set; }
        [Required]
        [Display(Name = "Order ID")]
        public int ORDERID { get; set; }
        [ForeignKey("ORDERID")]
        public virtual Order Order { get; set; }
        [Required]
        [Display(Name = "Recieved By")]
        public int RECEIVEDBY { get; set; }//Hold's employeeID
        [ForeignKey("RECEIVEDBY")]
        public virtual Employee Employee { get; set; }
        [Required]
        [Display(Name = "Compound Name")]
        public string COMPOUNDNAME { get; set; }
        [Required]
        [Display(Name = "Quantity")]
        public decimal QUANTITY { get; set; }
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
        public decimal CLIENTWEIGHT { get; set; }
        [Required]
        [Display(Name = "Molar Mass")]
        public decimal MOLARMASS { get; set; }
        [Required]
        [Display(Name = "Actual Weight")]
        public decimal ACTUALWEIGHT { get; set; }
        [Required]
        [Display(Name = "MTD")]
        public decimal MTD { get; set; }


    }
}