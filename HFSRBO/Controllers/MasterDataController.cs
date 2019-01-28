using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFSRBO
{
    [Authorize]
    [NoCache]
    [OutputCache(NoStore = true, Duration = 0)]
    public class MasterDataController : Controller
    {
        bhfsContext db = new bhfsContext();
        // GET: MasterData
        public ActionResult ComplaintsType()
        {
            var list = db.type_complaint.ToList();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddComplaintType(FormCollection collection)
        {
            type_complaint tp = new type_complaint();
            tp.Description = collection.Get("description");
            db.type_complaint.Add(tp);
            db.SaveChanges();
            return RedirectToAction("ComplaintsType");
        }
        public ActionResult DeleteComplaint(String ID)
        {
            Int32 id = Convert.ToInt32(ID);
            var del = db.type_complaint.Where(p => p.ID == id).FirstOrDefault();
            db.type_complaint.Remove(del);
            db.SaveChanges();
            return RedirectToAction("ComplaintsType");
        }
        public ActionResult Staffs()
        {
            var list = db.staff_assigend.ToList();
            return View(list);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddStaff(FormCollection collection)
        {
            staff_assigend sa = new staff_assigend();
            sa.Name = collection.Get("name");
            db.staff_assigend.Add(sa);
            db.SaveChanges();
            return RedirectToAction("Staffs");
        }
        public ActionResult DeleteStaff(String ID)
        {
            Int32 id = Convert.ToInt32(ID);
            var del = db.staff_assigend.Where(p => p.ID == id).FirstOrDefault();
            db.staff_assigend.Remove(del);
            db.SaveChanges();
            return RedirectToAction("Staffs");
        }
        public ActionResult Hospitals()
        {
            HealthFacilityViewModel hfv = new HealthFacilityViewModel();
            hfv.hospitals = db.hospitals.ToList();
            hfv.facility_types = db.facility_type.ToList();
            return View(hfv);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddHospital(FormCollection collection)
        {
            hospitals h = new hospitals();
            h.name = collection.Get("name");
            h.address = collection.Get("address");
            h.facilityID = Convert.ToInt32(collection.Get("facility_types"));
            db.hospitals.Add(h);
            db.SaveChanges();
            return RedirectToAction("Hospitals");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddFacilityType(FormCollection collection)
        {
            facility_type ft = new facility_type();
            ft.Name = collection.Get("name");
            db.facility_type.Add(ft);
            db.SaveChanges();
            return RedirectToAction("Hospitals");
        }
        public ActionResult DeleteHospital(String ID)
        {
            Int32 id = Convert.ToInt32(ID);
            var del_hos = db.hospitals.Where(p => p.ID == id).FirstOrDefault();
            db.hospitals.Remove(del_hos);
            db.SaveChanges();
            return RedirectToAction("Hospitals");
        }
    }
}