using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO
{
    public class complaint_nameOfComplainant
    {
        [Key]
        public Int32 complaintId { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String mi { get; set; }
        public Int32 age { get; set; }
        public String civil_status { get; set; }
        public String gender { get; set; }
        public String address { get; set; }
    }
}