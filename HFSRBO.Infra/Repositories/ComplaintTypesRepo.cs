using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Core;
using System.Data.Entity;
namespace HFSRBO.Infra
{
    public class ComplaintTypesRepo : IComplaintTypeRepo
    {
        hfsrboContext db = new hfsrboContext();
        public void Add(type_complaint _typeComplaint)
        {
            db.complaintType.Add(_typeComplaint);
            db.SaveChanges();
        }
        public void Edit(type_complaint _typeComplaint)
        {
            db.Entry(_typeComplaint).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove(Int32 ID)
        {
            db.complaintType.Remove(db.complaintType.Where(p => p.ID == ID).FirstOrDefault());
            db.SaveChanges();
        }
        public type_complaint FindById(Int32 ID)
        {
            var result = db.complaintType.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
        public IEnumerable<type_complaint> GetComplaintTypes()
        {
            var result = db.complaintType;
            return result;
        }
    }
}
