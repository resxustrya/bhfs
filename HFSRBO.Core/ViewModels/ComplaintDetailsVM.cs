using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Core;
namespace HFSRBO.Core
{
    public class ComplaintDetailsVM
    {
        public IEnumerable<type_complaint> complaintTypes { get; set; }
        public IEnumerable<complaint_assistance> complaintAssistance { get; set; }
        
    }
}
