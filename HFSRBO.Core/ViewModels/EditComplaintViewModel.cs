using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class EditComplaintViewModel
    {
        
        public complaints _complaint { get; set; }
        public complaint_nameOfComplainant _nameOfComplainant { get; set; }
        public complaint_patient _patient { get; set; }
        public Int32[] _complaint_type_list { get; set; }
        public Int32[] _complaintAssistance { get; set; }
        public List<String> date_informed_the_hf { get; set; }
        public List<String> date_hf_submitted_reply { get; set; }
        public List<String> date_release_to_records { get; set; }
        public List<String> date_final_resolution { get; set; }
        public IEnumerable<remarks> _remarks { get; set; }
        public IEnumerable<complaint_action_dates> _complaintActionDates { get; set; }
        public CreateComplaintViewModel _createComplaintViewModel { get; set; }

    }
}
