using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HFSRBO.Core;
namespace HFSRBO.Infra
{
    public class PatientRepo : IComplaintPatientRepository
    {
        hfsrboContext db = new hfsrboContext();
        public void Add(complaint_patient _patient)
        {
            db.patient.Add(_patient);
            db.SaveChanges();
        }
        public void Edit(complaint_patient _patient)
        {
            db.Entry(_patient).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove(Int32 ID)
        {
            try
            {
                db.patient.Remove(db.patient.Where(p => p.complaintID == ID).FirstOrDefault());
                db.SaveChanges();
            }
            catch { }
        }
        public complaint_patient FindById(Int32 ID)
        {
            var result = db.patient.Where(p => p.complaintID == ID).FirstOrDefault();
            return result;
        }
    }
}
