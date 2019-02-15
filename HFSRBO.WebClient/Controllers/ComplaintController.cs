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
        // GET: Complaint
        public ActionResult Complaints()
        {
            return View();
        }
    }
}