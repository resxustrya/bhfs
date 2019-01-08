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
        public ActionResult AddComplaintType(FormCollection collection)
        {
            type_complaint tp = new type_complaint();
            tp.Description = collection.Get("description");
            db.type_complaint.Add(tp);
            db.SaveChanges();
            return RedirectToAction("ComplaintsType");
        }
        public ActionResult Staffs()
        {
            var list = db.staff_assigend.ToList();
            return View(list);
        }
        [HttpPost]
        public ActionResult AddStaff(FormCollection collection)
        {
            staff_assigend sa = new staff_assigend();
            sa.Name = collection.Get("name");
            db.staff_assigend.Add(sa);
            db.SaveChanges();
            return RedirectToAction("Staffs");
        }
    }
}