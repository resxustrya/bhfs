using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using System.IO;

namespace HFSRBO
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
            var complaints = db.complaints.Where(p => p.active == true).ToList();
            return View(complaints);
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SubmitForm(FormCollection collection, String[] complaint_type)
        {
            complaints complaint = new complaints();
            SaveComplaint(collection,complaint,complaint_type, true);
            return RedirectToAction("Home");
        }

        public void SaveComplaint(FormCollection collection, complaints complaint,String[] complaint_type,Boolean isNew)
        {
            complaint.firstname = EncyptDecrypt.Encrypt(collection.Get("firstname"));
            complaint.lastname = EncyptDecrypt.Encrypt(collection.Get("lastname"));
            complaint.mi = EncyptDecrypt.Encrypt(collection.Get("mi"));
            try { complaint.age = Convert.ToInt32(collection.Get("age")); } catch { }
            complaint.civil_status = collection.Get("civil_status");
            complaint.gender = EncyptDecrypt.Encrypt(collection.Get("gender"));
            try { complaint.date = Convert.ToDateTime(collection.Get("date")); } catch { }
            complaint.address = EncyptDecrypt.Encrypt(collection.Get("address"));
            complaint.hospitalID = Convert.ToInt32(collection.Get("hospitalID"));
            complaint.p_firstname = EncyptDecrypt.Encrypt(collection.Get("p_firstname"));
            complaint.p_lastname = EncyptDecrypt.Encrypt(collection.Get("p_lastname"));
            complaint.p_mi = EncyptDecrypt.Encrypt(collection.Get("p_mi"));
            try { complaint.date_confined = Convert.ToDateTime(collection.Get("date_confined")); } catch { }

            complaint.other_complaint = EncyptDecrypt.Encrypt(collection.Get("other_complaint"));
            complaint.nature_of_complaint = collection.Get("nature_of_complaint");
            complaint.assistance_needed = collection.Get("assistance_needed");
            complaint.communication_form = collection.Get("communication_form");
            complaint.ownership = collection.Get("ownership");
            try { complaint.date_informed_the_hf = Convert.ToDateTime(collection.Get("date_informed_the_hf")); } catch { }
            try { complaint.date_hf_submitted_reply = Convert.ToDateTime(collection.Get("date_hf_submitted_reply")); } catch { }
            try { complaint.date_release_to_records = Convert.ToDateTime(collection.Get("date_release_to_records")); } catch { }
            try { complaint.date_final_resolution = Convert.ToDateTime(collection.Get("date_final_resolution")); } catch { }
            complaint.status = "O";
            if (isNew)
            {
                complaint.year = DateTime.Now.Year;
            }
            
            complaint.staff = User.Identity.GetUserName();
            complaint.date_created = DateTime.Now;

            if (isNew)
            {
                complaint.active = true;
                db.complaints.Add(complaint);
            }
            db.SaveChanges();
            if (isNew)
            {
                var new_complaint = db.complaints.Where(p => p.ID == complaint.ID).FirstOrDefault();
                new_complaint.Code = "RO7-" + DateTime.Now.Year.ToString() + "-" + new_complaint.ID;
                db.SaveChanges();
            }
            

            if (complaint_type != null && complaint_type.Length > 0)
            {
                var del_ctl = db.complaint_types_list.Where(p => p.ComplaintID == complaint.ID).ToList();
                if(del_ctl.Count > 0)
                {
                    db.complaint_types_list.RemoveRange(del_ctl);
                }
                foreach (string s in complaint_type)
                {
                    complaint_types_list ctl;
                    ctl = new complaint_types_list();
                    ctl.ComplaintID = complaint.ID;
                    ctl.ComplaintTypeId = Convert.ToInt32(s);
                    db.complaint_types_list.Add(ctl);
                }
                db.SaveChanges();
            }
        }

        public ActionResult EditComplaint(String ID)
        {
            var complaint = db.complaints.Where(p => p.ID.ToString() == ID).FirstOrDefault();
            Session["ComplaintID"] = ID;
            return View(complaint);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComplaint(FormCollection collection, String[] complaint_type)
        {
            Int32 ID = Convert.ToInt32(Session["ComplaintID"].ToString());
            var complaint = db.complaints.Where(p => p.ID == ID).FirstOrDefault();
            SaveComplaint(collection, complaint, complaint_type, false);
            return RedirectToAction("Home");
        }
        public ActionResult DeleteComplaint(String ID)
        {
            Int32 id = Convert.ToInt32(ID);
            var del = db.complaints.Where(p => p.ID == id).FirstOrDefault();
            del.active = false;
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        public ActionResult Filter()
        {
            return View();
        }
        public ActionResult AddAction(String ID)
        {
            Session["ComplaintID"] = ID;
            Int32 ComplaintID = Convert.ToInt32(ID);
            var actions = db.actions.Where(p => p.ComplaintID == ComplaintID).ToList();
            return PartialView(actions);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddAction(FormCollection collection)
        {
            Int32 ComplaintID = Convert.ToInt32(Session["ComplaintID"].ToString());
            actions_takened actions = new actions_takened();
            actions.actions = collection.Get("actions");
            actions.ComplaintID = ComplaintID;
            actions.DateCreated = DateTime.Now;
            db.actions.Add(actions);
            db.SaveChanges();

            return RedirectToAction("Home");
        }
        public void DeleteAction(String ID)
        {
            Int32 id = Convert.ToInt32(ID);
            var del = db.actions.Where(p => p.ID == id).FirstOrDefault();
            db.actions.Remove(del);
            db.SaveChanges();
        }

        [HttpPost]
        public ActionResult Filter(FormCollection collection, String[] complaint_type)
        {
            String[] hospitals = collection.Get("hospitalID").Split(',');

            Int32[] Int_complaint_types = { };
            Int32[] Int_hospitals = { };
            DateTime date_from;
            DateTime date_to;
           
            date_from = Convert.ToDateTime(collection.Get("date_from"));
            date_to = Convert.ToDateTime(collection.Get("date_to"));
            

            IEnumerable<complaints> complaints = null;
            try { Int_complaint_types = Array.ConvertAll(complaint_type, s => int.Parse(s)); } catch { }
            try { Int_hospitals = Array.ConvertAll(hospitals, s => int.Parse(s)); } catch { }

            if(Int_complaint_types.Length > 0 && Int_hospitals.Length <= 0)
            {
                complaints = (from c in db.complaints

                              join ctl in db.complaint_types_list
                                on c.ID equals ctl.ComplaintID
                              where Int_complaint_types.Contains(ctl.ComplaintTypeId)
                              select c).Distinct().ToList();
            }

            if (Int_complaint_types.Length <= 0 && Int_hospitals.Length > 0)
            {
                complaints = (from c in db.complaints where
                              Int_hospitals.Contains(c.hospitalID)
                              select c).Distinct().ToList();
            }

            if (Int_complaint_types.Length > 0 && Int_hospitals.Length > 0)
            {
                complaints = (from c in db.complaints
                              join ctl in db.complaint_types_list
                              on c.ID equals ctl.ComplaintID
                              where Int_complaint_types.Contains(ctl.ComplaintTypeId) &&
                              Int_hospitals.Contains(c.hospitalID)
                              select c).Distinct().ToList();
            }
            if(collection.Get("display") == "P")
            {
                (new print_complaints()).print_complaint(complaints,date_from,date_to);
                var fileStream = new FileStream(Server.MapPath("~/PDF/complaints.pdf"),
                                        FileMode.Open,
                                        FileAccess.Read
                                    );
                var fsResult = new FileStreamResult(fileStream, "application/pdf");
                return fsResult;
            }

            return View("~/Views/Complaint/Home.cshtml", complaints);
     
        }
        public ActionResult Status(String ID)
        {
            Session["ComplaintID"] = ID;
            Int32 id = Convert.ToInt32(Session["ComplaintID"].ToString());
            var complaint = db.complaints.Where(p => p.ID == id).FirstOrDefault();
            return PartialView(complaint);
        }

        [HttpPost]
        public ActionResult Status(FormCollection collection)
        {
            Int32 ID = Convert.ToInt32(Session["ComplaintID"].ToString());
            var complaint = db.complaints.Where(p => p.ID == ID).FirstOrDefault();
            complaint.status = collection.Get("status");
            db.SaveChanges();
            return RedirectToAction("Home");
        }
        public JsonResult GetHospital()
        {
            var hospitals = (from list in db.hospitals select list.name ).ToList();
            return Json(hospitals,JsonRequestBehavior.AllowGet);
        }
    }
}