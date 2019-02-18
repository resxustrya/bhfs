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
        public ActionResult  HealthFacility(String tab ="1")
        {
            if(tab == "1")
            {
                ViewBag.Tab = tab;
                var result = hospitals.GetHealthFacilities();
                return View("~/Views/MasterData/HealthFacilities.cshtml", result);
            }
            else if(tab == "2")
            {
                ViewBag.Tab = tab;
                var result = facilityType.GetFacilityTypes();
                return View("~/Views/MasterData/HealthFacilities.cshtml", result);
            }
            ViewBag.Tab = tab;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHealthFacility(FormCollection collection)
        {
            Core.hospitals _hospital = new Core.hospitals
            {
                name = collection.Get("name"),
                address = collection.Get("address"),
                facilityID = Convert.ToInt32(collection.Get("facilityID"))
            };
            hospitals.Add(_hospital);
            return RedirectToAction("HealthFacility");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFacilityType(FormCollection collection)
        {
            Core.facility_type ft = new facility_type
            {
                Name = collection.Get("name")
            };
            facilityType.Add(ft);
            return RedirectToAction("HealthFacility");
        }
    }
}