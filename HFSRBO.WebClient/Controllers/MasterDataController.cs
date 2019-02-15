using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFSRBO.Core;
namespace HFSRBO.WebClient.Controllers
{
    [Authorize]
    [NoCache]
    [OutputCache(NoStore = true, Duration = 0)]
    public class MasterDataController : Controller
    {
        IComplaintTypeRepo complaintType;
        IFacilityTypeRepo facilityType;
        IHospitalRepo hospitals;
        public MasterDataController(IComplaintTypeRepo complaintType, IFacilityTypeRepo facilityType,IHospitalRepo hospitals)
        {
            this.complaintType = complaintType;
            this.facilityType = facilityType;
            this.hospitals = hospitals;
        }
        
        public ActionResult ComplaintTypes()
        {
            var result = complaintType.GetComplaintTypes();
            return View(result);
        }
        [HttpGet]
        public ActionResult AddComplaintType()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComplaintType(FormCollection collection)
        {
            complaintType.Add(new type_complaint { Description = collection.Get("description") });
            return RedirectToAction("ComplaintTypes");
        }
        public ActionResult EditComplaintType(String ID)
        {
            try
            {
                Int32 id = Convert.ToInt32(ID);
                var result = complaintType.FindById(id);
                Session["ID"] = result.ID;
                return PartialView(result);
            }
            catch { }
            return HttpNotFound();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComplaintType(FormCollection collection)
        {
            Int32 ID = Convert.ToInt32(Session["ID"].ToString());
            var result = complaintType.FindById(ID);
            result.Description = collection.Get("description");
            complaintType.Edit(result);
            return RedirectToAction("ComplaintTypes");
        }
        public ActionResult DeleteComplaintType(String ID)
        {
            try
            {
                Int32 id = Convert.ToInt32(ID);
                complaintType.Remove(id);
                return RedirectToAction("ComplaintTypes");
            }
            catch { }
            return HttpNotFound();
        }
        public ActionResult HealthFacilities()
        {
            HospitalFacilityViewModel _hospitalFacilityType = new HospitalFacilityViewModel
            {
                _hospitals = this.hospitals.GetHospitals(),
                _facilityType = this.facilityType.GetFacilityTypes()

            };
            return View(_hospitalFacilityType);
        }
    }
}