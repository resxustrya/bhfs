using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class CreateComplaintViewModel
    {
        public IEnumerable<hospitals> _hospitals { get; set; }
        public IEnumerable<communication> _communications { get; set; }
        public IEnumerable<type_complaint> _complaint_type { get; set; }
        public IEnumerable<complaint_assistance> _complaintAssistance { get; set; }
        public List<String> _facility_type { get; set; }
    }
}
