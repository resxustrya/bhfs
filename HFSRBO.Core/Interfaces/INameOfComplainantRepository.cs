using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface INameOfComplainantRepository
    {
        void Add(complaint_nameOfComplainant nameOfComplainant);
        void Edit(complaint_nameOfComplainant nameOfComplainant);
        void Remove(Int32 complaintID);
        complaint_nameOfComplainant FindById(Int32 complaintID);
    }
}
