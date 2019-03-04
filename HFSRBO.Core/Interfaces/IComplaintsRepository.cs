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
        void InsertComplaintTypeComplaintAsistance(complaint_types_list _complaint_types_list);

    }
}
