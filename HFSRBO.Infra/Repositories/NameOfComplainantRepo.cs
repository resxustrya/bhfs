using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HFSRBO.Core;
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
        }
        public void Remove(Int32 ID)
        {
            try
            {
                db.complainantName.Remove(db.complainantName.Where(p => p.complaintId == ID).FirstOrDefault());
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
