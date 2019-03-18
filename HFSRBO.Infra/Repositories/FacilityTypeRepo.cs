using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HFSRBO.Core;
namespace HFSRBO.Infra
{
    public class FacilityTypeRepo : IFacilityTypeRepo
    {
        hfsrboContext db = new hfsrboContext();
        public void Add(facility_type _facilityType)
        {
            db.facilityType.Add(_facilityType);
            db.SaveChanges();
        }
        public void Edit(facility_type _facilityType)
        {
            db.Entry(_facilityType).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Remove(Int32 ID)
        {
            db.facilityType.Remove(db.facilityType.Where(p => p.ID == ID).FirstOrDefault());
            db.SaveChanges();
        }
        public facility_type FindById(Int32 ID)
        {
            var result = db.facilityType.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
        public IEnumerable<facility_type> GetFacilityTypes()
        {
            var result = db.facilityType;
            return result;
        }
    }
}
