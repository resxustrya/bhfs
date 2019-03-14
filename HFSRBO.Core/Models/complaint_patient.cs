using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class complaint_patient
    {
        [Key]
        public Int32 ID { get; set; }
        public Int32 complaintID { get; set; }
        public String p_firstname { get; set; }
        public String p_lastname { get; set; }
        public String p_mi { get; set; }
        public Int32 age { get; set; }
        public string date_confined;
    }
}