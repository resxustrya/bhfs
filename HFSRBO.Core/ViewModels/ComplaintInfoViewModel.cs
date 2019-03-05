using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class ComplaintInfoViewModel
    {

        public complaints _complaints { get; set; }
        public complaint_nameOfComplainant _nameOfComplainant { get; set; }
        public complaint_patient _complaintPatient { get; set; }
        public Int32[] complaint_type { get; set; }
        public Int32[] assistanceNeeded { get; set; }
        public String[] date_informed_the_hf { get; set; }
        public String[] date_hf_submitted_reply { get; set; }
        public String[] date_release_to_records { get; set; }
        public String[] date_final_resolution { get; set; }
        public String[] actionDate { get; set; }
        public String[] actionTaken { get; set; }

    }
}
