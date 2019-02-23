using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class ComplaintInfoViewModel
    {
        public Boolean anonymous { get; set; }
        public String codeNumber { get; set; }
        public String firstname { get; set; }
        public String lastname { get; set; }
        public String mi { get; set; }
        public String civil_status { get; set; }
        public String gender { get; set; }
        public DateTime date { get; set; }
        public String relationship { get; set; }
        public String telNo { get; set; }
        public String mobile { get; set; }
        public String address { get; set; }
        public String p_firstname { get; set; }
        public String p_lastname { get; set; }
        public String p_mi { get; set; }
        public String date_confined { get; set; }
        public Int32 age { get; set; }
        public Int32 hospitalID { get; set; }
        //public Int32[] complaint_type { get; set; }
        public String other_complaint { get; set; }
        public String assistance_needed { get; set; }
        public String reasonOfConfinement { get; set; }
        public Boolean pccCheck { get; set; }
        public String pccNumber { get; set; }
        public String communication_form { get; set; }
        public String ownership { get; set; }
        public String date_informed_the_hf { get; set; }
        public String date_hf_submitted_reply { get; set; }
        public String date_release_to_records { get; set; }
        public String date_final_resolution { get; set; }
        
    }
}
