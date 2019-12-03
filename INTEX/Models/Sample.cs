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
        public int COMPOUNDLTID { get; set; }
        [Key, Column(Order = 1)]
        public int COMPOUNDSEQCODE { get; set; }
        public int ORDERID { get; set; }
        public int RECEIVEDBY { get; set; }//Hold's employeeID
        public string COMPOUNDNAME { get; set; }
        public double QUANTITY { get; set; }
        public DateTime DATEARRIVED { get; set; }
        public DateTime DUEDATE { get; set; }
        public string APPEARANCE { get; set; }
        public double CLIENTWEIGHT { get; set; }
        public double MOLARMASS { get; set; }
        public double ACTUALWEIGHT { get; set; }
        public double MTD { get; set; }


    }
}