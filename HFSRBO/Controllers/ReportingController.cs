using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFSRBO.Controllers
{
    public class ReportingController : Controller
    {
        // GET: Reporting
        public ActionResult Filters()
        {
            return View();
        }
    }
}