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
        public List<String> complaint_type { get; set; }
        public List<String> assistanceNeeded { get; set; }
        public List<String> date_informed_the_hf { get; set; }
        public List<String> date_hf_submitted_reply { get; set; }
        public List<String> date_release_to_records { get; set; }
        public List<String> date_final_resolution { get; set; }
        public List<String> actionDate { get; set; }
        public List<String> actionTaken { get; set; }
        public List<String> remarks { get; set; }

    }
}
