using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFSRBO.Core;
using HFSRBO.Infra;
namespace HFSRBO.WebClient
{
    public static class HealthFacilityHelper
    {
        private static FacilityTypeRepo facilityType = new FacilityTypeRepo();
        public static  IEnumerable<facility_type> GetFacilityTypes()
        {
            return facilityType.GetFacilityTypes();
        }
    }
}