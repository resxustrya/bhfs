using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface IComplaintPatientRepository
    {
        void Add(complaint_patient _complaintPatient);
        void Edit(complaint_patient _complaintPatient);
        void Remove(Int32 complaintID);
        complaint_patient FindById(Int32 complaintID);
    }
}
