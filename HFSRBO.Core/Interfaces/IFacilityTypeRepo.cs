using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public interface IFacilityTypeRepo
    {
        void Add(facility_type _facilityType);
        void Edit(facility_type _facilityType);
        void Remove(Int32 ID);
        facility_type FindById(Int32 ID);
        IEnumerable<facility_type> GetFacilityTypes();
    }
}
