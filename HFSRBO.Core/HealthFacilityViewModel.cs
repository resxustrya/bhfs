using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HFSRBO.Core
{
    public class HealthFacilityViewModel
    {
        public IEnumerable<hospitals> hospitals { get; set; }
        public IEnumerable<facility_type> facility_types { get; set; }
    }
}