using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using HFSRBO.Core;
using System.Web.UI;

namespace HFSRBO.WebClient
{
    [Authorize]
    [NoCache]
    [OutputCache(Location = OutputCacheLocation.None, NoStore = true,Duration =0)]
    public class ComplaintController : Controller
    {
        private IComplaintsRepository cr;
        // GET: Complaint
        public ComplaintController(IComplaintsRepository cr)
        {
            this.cr = cr;
        }
        public ComplaintController()
        {}
        public ActionResult Complaints()
        {
            return View();
        }
        public ActionResult CreateComplaint()
        {
            CreateComplaintViewModel createComplaintVM = this.cr.getCreateComplaintViewModel();
            return View(createComplaintVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComplaint(String[] date_informed_the_hf,String[] date_hf_submitted_reply,String[] date_release_to_records,String[] date_final_resolution, String[] complaint_type,String[] complaint_assistance)
        {
            return Json(complaint_type.ToList(), JsonRequestBehavior.AllowGet);
            //return Json(civm.date.ToShortDateString(), JsonRequestBehavior.AllowGet);
        }
        /*
        public ActionResult CreateComplaint([ModelBinder(typeof(VMComplaintCustomBinder))] ComplaintInfoViewModel civm)
        {
            return Json(civm.date.ToShortDateString(), JsonRequestBehavior.AllowGet);
        }
        */
    }
}