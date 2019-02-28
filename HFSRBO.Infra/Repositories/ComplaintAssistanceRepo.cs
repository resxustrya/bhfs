using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Core;
using System.Data.Entity;

namespace HFSRBO.Infra
{
    public class ComplaintAssistanceRepo : IComplaintAssistanceRepo
    {
        hfsrboContext db = new hfsrboContext();
        public void Add(complaint_assistance _complaintAssistance)
        {
            db.complaintAssistance.Add(_complaintAssistance);
            db.SaveChanges();
        }
        public void Edit(complaint_assistance _complaintAssistance)
        {
            db.Entry(_complaintAssistance).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove(Int32 ID)
        {
            db.complaintAssistance.Remove(db.complaintAssistance.Where(p => p.ID == ID).FirstOrDefault());
            db.SaveChanges();
        }
        public complaint_assistance FindById(Int32 ID)
        {
            var result = db.complaintAssistance.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
        public IEnumerable<complaint_assistance> GetComplaintAssistance()
        {
            var result = db.complaintAssistance;
            return result;
        }
    }
}
