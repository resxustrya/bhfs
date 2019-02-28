using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface IComplaintAssistanceRepo
    {
        void Add(complaint_assistance _complaintAssistance);
        void Edit(complaint_assistance _complaintAssistance);
        void Remove(Int32 ID);
        complaint_assistance FindById(Int32 ID);
        IEnumerable<complaint_assistance> GetComplaintAssistance();
    }
}
