using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class DisplayComplaintViewModel
    {
        public Int32 complaintID { get; set; }
        public String codeNumber { get; set; }
        public String hospitalName { get; set; }
        public String hospitalAddress { get; set; }
        public String nameOfComplainant { get; set; }
        public String date_confined { get; set; }
        public String other_complaint { get; set; }
        public String reasonOfConfinement { get; set; }
        public String otherAssistanceNeed { get; set; }
        public String communication_form { get; set; }
        public String ownership { get; set; }
        public Int32 status { get; set; }
        public String staff { get; set; }
        public Boolean annonymos { get; set; }
        public Boolean pccCheck { get; set; }
        public String pccNumber { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateReceive { get; set; }
        public List<String> complaint_type { get; set; }
        public List<String> assistanceNeeded { get; set; }
        public List<String> date_informed_the_hf { get; set; }
        public List<String> date_hf_submitted_reply { get; set; }
        public List<String> date_release_to_records { get; set; }
        public List<String> date_final_resolution { get; set; }
        public IEnumerable<complaint_action_dates> _complaintActionDates { get; set; }

    }
}
