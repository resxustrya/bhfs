using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFSRBO.Core;
namespace HFSRBO.Client.Controllers
{
    public class ComplaintsController : Controller
    {
        IComplaintsRepository cr;

        public ComplaintsController() { }
        public ComplaintsController(IComplaintsRepository cr)
        {
            this.cr = cr;
        }
        // GET: Complaints
        public ActionResult Index()
        {
            var complaints = this.cr.GetComplaints();
            return Json(complaints, JsonRequestBehavior.AllowGet);
        }
    }
}