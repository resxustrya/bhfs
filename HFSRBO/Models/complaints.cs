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
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String mi { get; set; }
        public Int32 age { get; set; }
        public String civil_status { get; set; }
        public String gender { get; set; }
        public DateTime? date { get; set; }
        public String address { get; set; }
        public String name_facility_complained { get; set; }
        public String facility_type { get; set; }
        public String facility_address { get; set; }
        public String p_firstname { get; set; }
        public String p_lastname { get; set; }
        public String p_mi { get; set; }
        public DateTime? date_confined { get; set; }
        public String other_complaint { get; set; }
        public String nature_of_complaint { get; set; }
        public String assistance_needed { get; set; }
        public String communication_form { get; set; }
        public String ownership { get; set; }
        public DateTime? date_informed_the_hf { get; set; }
        public DateTime? date_hf_submitted_reply { get; set; }
        public DateTime? date_release_to_records { get; set; }
        public DateTime? date_final_resolution { get; set; }
        public String Region { get; set; }
        public String status { get; set; }
    }
}