using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface IComplaintsRepository
    {
        Int32 Add(complaints p);
        void Edit(complaints p);
        void Remove(Int32 ID);
        IEnumerable<complaints> GetComplaints();
        complaints FindById(Int32 ID);
        CreateComplaintViewModel getCreateComplaintViewModel();
        void InsertComplaintTypeAssistance(complaint_types_list _complaint_types_list);
        void RemoveComplaintTypeByComplaintID(Int32 complaintID, String member);
        void InsertComplaintsDates(complaint_dates _complaintsDates);
        void RemoveComplaintsDates(Int32 complaintID, String member);
        void InsertComplaintActions(complaint_action_dates _complaintActionDates);
        void RemoveComplaintActions(Int32 complaintID);

    }
}
