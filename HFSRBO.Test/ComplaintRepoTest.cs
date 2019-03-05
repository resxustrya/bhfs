using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Infra;
using HFSRBO.Core;
namespace HFSRBO.Test
{
    [TestClass]
    public class ComplaintRepoTest
    {
        ComplaintsRepository cr;
        ComplaintTypesRepo ct;
        FacilityTypeRepo ft;
        [TestInitialize]
        public void TestSetup()
        {
            cr = new ComplaintsRepository();
            ct = new ComplaintTypesRepo();
            ft = new FacilityTypeRepo();
        }
        /*
        public void isRepositoryHasData()
        {
            var result = cr.GetComplaints();
            Assert.IsNotNull(result);
            var numberRecords = result.Count();
            Assert.AreEqual(2,numberRecords);
        }
      
        public void ComplaintAddRepo()
        {
            complaints _complaint = new complaints
            {
                codeNumber = "RC-2",
                date = DateTime.Now,
                hospitalID = 2,
                date_confined = DateTime.Now,
                other_complaint = "No Nurse",
                ownership = "P",
                date_informed_the_hf = DateTime.Now,
                date_hf_submitted_reply = DateTime.Now,
                date_release_to_records = DateTime.Now,
                date_final_resolution = DateTime.Now,
                status = "O",
                date_created = DateTime.Now,
                active = true,
                year = 2019
            };

            cr.Add(_complaint);
            var result = cr.GetComplaints();
            var numRecords = result.Count();
            Assert.AreEqual(1, numRecords);
        }
        public void ComplaintType()
        {
            ct.Add(new type_complaint { ID = 1, Description="Overcharging of Fees" });
            ct.Add(new type_complaint { ID = 2, Description="Poor Servies"});
            var result = ct.GetComplaintTypes();
            Assert.AreEqual(2, result.Count());
        }

        public void FacilityType()
        {
            ft.Add(new facility_type {ID =1, Name = "Health Facility" });
            ft.Add(new facility_type { ID = 2, Name = "Drug Testing" });

            var result = ft.GetFacilityTypes();
            Assert.AreEqual(2, result.Count());
        }
        */
    }
}
