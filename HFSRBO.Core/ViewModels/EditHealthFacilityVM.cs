using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class EditHealthFacilityVM
    {
        public hospitals _hospital { get; set; }
        public IEnumerable<facility_type> _facilityType { get; set; }
    }
}
