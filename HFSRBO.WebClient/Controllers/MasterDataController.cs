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
        IComplaintAssistanceRepo complaintAssistance;
        public MasterDataController(IComplaintTypeRepo complaintType, IFacilityTypeRepo facilityType,IHospitalRepo hospitals, IComplaintAssistanceRepo complaintAssistance)
        {
            this.complaintType = complaintType;
            this.facilityType = facilityType;
            this.hospitals = hospitals;
            this.complaintAssistance = complaintAssistance;
        }
        
        public ActionResult ComplaintTypes()
        {
            //var result = complaintType.GetComplaintTypes();
            ComplaintDetailsVM cdvm = new ComplaintDetailsVM
            {
                complaintTypes = this.complaintType.GetComplaintTypes(),
                complaintAssistance = this.complaintAssistance.GetComplaintAssistance()
            };
            return View(cdvm);
        }
        [HttpGet]
        public ActionResult AddComplaintType()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComplaintType(type_complaint ct)
        {
            complaintType.Add(ct);
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
        public ActionResult  HealthFacility()
        {
            HealthFacilityTypeFacilityVM hftvm = new HealthFacilityTypeFacilityVM
            {
                healthFacility = this.hospitals.GetHealthFacilities(),
                facilityType = this.facilityType.GetFacilityTypes()
            };
            return View(hftvm);
        }

        public ActionResult AddHealthFacitlity()
        {
            var facilitytypes = this.facilityType.GetFacilityTypes();
            return PartialView(facilitytypes);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHealthFacility(hospitals _hospitals)
        {
            hospitals.Add(_hospitals);
            return RedirectToAction("HealthFacility");
        }
        public ActionResult EditHealthFacility(String ID)
        {
            EditHealthFacilityVM data = new EditHealthFacilityVM
            {
                _hospital = this.hospitals.FindById(Convert.ToInt32(ID)),
                _facilityType = this.facilityType.GetFacilityTypes()
            };
            
            return PartialView(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditHealthFacility(hospitals _hospitals)
        {
            hospitals.Edit(_hospitals);
            return RedirectToAction("HealthFacility");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFacilityType(facility_type ft)
        {
            facilityType.Add(ft);
            return RedirectToAction("HealthFacility");
        }
        public ActionResult AddComplaintAssistance()
        {
            return PartialView();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComplaintAssistance(complaint_assistance _complaintAssistance)
        {
            complaintAssistance.Add(_complaintAssistance);
            return RedirectToAction("ComplaintTypes");
        }
        public ActionResult DeleteHospital(String ID)
        {
            this.hospitals.Remove(Int32.Parse(ID));
            return RedirectToAction("HealthFacility");
        }
        public ActionResult DeleteFacility(String ID)
        {
            this.facilityType.Remove(Int32.Parse(ID));
            return RedirectToAction("HealthFacility");
        }
    }
}