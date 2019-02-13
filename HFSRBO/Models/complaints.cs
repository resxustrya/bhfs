using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO
{
    public class complaints
    {
        [Key]
        public Int32 ID { get; set; }
        public String Code { get; set; }
        public DateTime? date { get; set; }
        public Int32 hospitalID { get; set; }
        public DateTime? date_confined { get; set; }
        public String other_complaint { get; set; }
        public String assistance_needed { get; set; }
        public String communication_form { get; set; }
        public String ownership { get; set; }
        public DateTime? date_informed_the_hf { get; set; }
        public DateTime? date_hf_submitted_reply { get; set; }
        public DateTime? date_release_to_records { get; set; }
        public DateTime? date_final_resolution { get; set; }
        public String status { get; set; }
        public String staff { get; set; }
        public DateTime date_created { get; set; }
        public Boolean active { get; set; }
        public Boolean annonymos { get; set; }
        public Int32 year { get; set; }
    }
}