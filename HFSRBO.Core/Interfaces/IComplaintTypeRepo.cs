using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface IComplaintTypeRepo
    {
        void Add(type_complaint _typeComplaint);
        void Edit(type_complaint _typeComplaint);
        void Remove(Int32 ID);
        type_complaint FindById(Int32 ID);
        IEnumerable<type_complaint> GetComplaintTypes();
    }
}
