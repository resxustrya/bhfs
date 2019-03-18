
using HFSRBO.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace HFSRBO.Core
{
    public class HealthFacilityTypeFacilityVM
    {
        public IEnumerable<hospitals> healthFacility { get; set; }
        public IEnumerable<facility_type> facilityType { get; set; }
    }
}
