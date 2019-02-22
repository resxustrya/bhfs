using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;
using HFSRBO.Core;
namespace HFSRBO.WebClient
{
    [Authorize]
    [NoCache]
    [OutputCache(NoStore = true, Duration = 0)]
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
    }
}