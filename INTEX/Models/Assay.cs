using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace INTEX.Models
{
    [Table("ASSAY")]
    public class Assay
    {
        [Key]
        [Required]
        public int ASSAYID { get; set; }

        [Required(ErrorMessage = "Please upload the correct file")]
        [Display(Name = "Result File")]
        public string RESULT { get; set; }
        
        [Display(Name = "Comments")]
        [Required(ErrorMessage = "Please enter comments on the Assay Test")]
        public string COMMENTS { get; set; }

        [Required(ErrorMessage = "Please select the type of test performed")]
        [Display(Name = "Test Type")]
        public int TESTID { get; set; }
        [ForeignKey("TESTID")]
        public virtual Test Test { get; set; }
    }
}