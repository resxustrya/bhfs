﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HFSRBO.Controllers
{
    [Authorize]
    [NoCache]
    [OutputCache(NoStore = true, Duration = 0)]
    public class ComplaintController : Controller
    {
        bhfsContext db = new bhfsContext();
        // GET: Complaint
        public ActionResult Home()
        {
            var complaints = db.complaints.ToList();
            return View(complaints);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormCollection collection,string[] complaint_type)
        {
            
            complaints complaint = new complaints();

            complaint.firstname = collection.Get("firstname");
            complaint.lastname = collection.Get("lastname");
            complaint.mi = collection.Get("mi");
            try { complaint.age = Convert.ToInt32(collection.Get("age")); } catch { }
            complaint.civil_status = collection.Get("civil_status");
            complaint.gender = collection.Get("gender");
            try { complaint.date = Convert.ToDateTime(collection.Get("date")); } catch {  }
            complaint.address = collection.Get("address");
            complaint.name_facility_complained = collection.Get("name_facility_complained");
            complaint.facility_type = collection.Get("facility_type");
            complaint.facility_address = collection.Get("facility_address");
            complaint.p_firstname = collection.Get("p_firstname");
            complaint.p_lastname = collection.Get("p_lastname");
            complaint.p_mi = collection.Get("p_mi");
            try { complaint.date_confined = Convert.ToDateTime(collection.Get("date_confined")); } catch { }

            complaint.other_complaint = collection.Get("other_complaint");
            complaint.nature_of_complaint = collection.Get("nature_of_complaint");
            complaint.assistance_needed = collection.Get("assistance_needed");
            complaint.communication_form = collection.Get("communication_form");
            complaint.ownership = collection.Get("ownership");
            try { complaint.date_informed_the_hf = Convert.ToDateTime(collection.Get("date_informed_the_hf")); } catch { }
            try { complaint.date_hf_submitted_reply = Convert.ToDateTime(collection.Get("date_hf_submitted_reply")); } catch { }
            try { complaint.date_release_to_records = Convert.ToDateTime(collection.Get("date_release_to_records")); } catch { }
            try { complaint.date_final_resolution = Convert.ToDateTime(collection.Get("date_final_resolution")); } catch { }
            complaint.status = "O";
            db.complaints.Add(complaint);
            db.SaveChanges();

            var new_complaint = db.complaints.Where(p => p.ID == complaint.ID).FirstOrDefault();
            new_complaint.Code = "RO7-" + DateTime.Now.Year.ToString() + "-" + new_complaint.ID;
            db.SaveChanges();


            if(complaint_type != null && complaint_type.Length > 0)
            {
                foreach (string s in complaint_type)
                {
                    complaint_types_list ctl = new complaint_types_list();
                    ctl.ComplaintID = complaint.ID;
                    ctl.ComplaintTypeId = Convert.ToInt32(s);
                    db.complaint_types_list.Add(ctl);
                }
                db.SaveChanges();
            }
            
            return RedirectToAction("Home");
           
        }
    }
}