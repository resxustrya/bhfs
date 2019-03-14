using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Core;
using System.Data.Entity;
namespace HFSRBO.Infra
{
    public class NameOfComplainantRepo : INameOfComplainantRepository
    {
        hfsrboContext db = new hfsrboContext();
        public void Add(complaint_nameOfComplainant _nameOfComplainant)
        {
            db.complainantName.Add(_nameOfComplainant);
            db.SaveChanges();
        }
        public void Edit(complaint_nameOfComplainant _nameOfComplainant)
        {
            db.Entry(_nameOfComplainant).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove(Int32 ID)
        {
            try
            {
                db.complainantName.Remove(db.complainantName.Where(p => p.complaintId == ID).FirstOrDefault());
                db.SaveChanges();
            }
            catch { }
        }
        public complaint_nameOfComplainant FindById(Int32 ID)
        {
            var result = db.complainantName.Where(p => p.complaintId == ID).FirstOrDefault();
            return result;
        }
    }
}
