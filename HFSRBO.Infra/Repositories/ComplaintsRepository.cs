using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Core;
using System.Data.Entity;
namespace HFSRBO.Infra
{
    public class ComplaintsRepository : IComplaintsRepository
    {
        hfsrboContext db = new hfsrboContext();
        public Int32 Add(complaints _complaints)
        {
            db.complaints.Add(_complaints);
            db.SaveChanges();
            return _complaints.ID;
        }
        public void Edit(complaints _complaints)
        {
            db.Entry(_complaints).State = EntityState.Modified;
        }
        public void Remove(Int32 ID)
        {
            try
            {
                db.complaints.Remove(db.complaints.Where(p => p.ID == ID).FirstOrDefault());
                db.SaveChanges();
            }
            catch { }
        }
        public complaints FindById(Int32 ID)
        {
            var result = db.complaints.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
        public IEnumerable<complaints> GetComplaints()
        {
            return db.complaints;
        }
    }
}
