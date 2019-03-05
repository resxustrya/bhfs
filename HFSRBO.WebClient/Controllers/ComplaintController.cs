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
        private INameOfComplainantRepository nameOfComplainantRepo;
        private IComplaintPatientRepository _patientRepo;
        // GET: Complaint
        public ComplaintController(IComplaintsRepository cr, INameOfComplainantRepository nameOfComplainantRepo, IComplaintPatientRepository _patientRepo)
        {
            this.cr = cr;
            this.nameOfComplainantRepo = nameOfComplainantRepo;
            this._patientRepo = _patientRepo;
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
        public ActionResult CreateComplaint([ModelBinder(typeof(VMComplaintCustomBinder))] ComplaintInfoViewModel civm,String[] date_informed_the_hf,String[] date_hf_submitted_reply,String[] date_release_to_records,String[] date_final_resolution, String[] complaint_type,String[] complaint_assistance,String[] actionTaken,String[] actionDate)
        {
            Boolean isNew = true;
            try { civm.complaint_type = Array.ConvertAll(complaint_type, s => int.Parse(s)); } catch { }
            try { civm.assistanceNeeded = Array.ConvertAll(complaint_assistance, s => int.Parse(s)); } catch { }
            civm.date_informed_the_hf = date_informed_the_hf;
            civm.date_hf_submitted_reply = date_hf_submitted_reply;
            civm.date_release_to_records = date_release_to_records;
            civm.date_final_resolution = date_final_resolution;
            civm.actionTaken = actionTaken;
            civm.actionDate = actionDate;
            SaveComplaint(civm,isNew);
            return Json(actionTaken.ToList(), JsonRequestBehavior.AllowGet);
        }

        public void SaveComplaint(ComplaintInfoViewModel civm,Boolean isNew)
        {
            //ADD NEW COMPLAINT TO DATABASE AND RETURN ITS ID(PRIMARY KEY) AFTER INSERTED
            Int32 complaintID = this.cr.Add(civm._complaints);
            civm._nameOfComplainant.complaintId = complaintID;
            this.nameOfComplainantRepo.Add(civm._nameOfComplainant);
            civm._complaintPatient.complaintID = complaintID;
            this._patientRepo.Add(civm._complaintPatient);

            if(civm.complaint_type != null)
            {
                this.cr.RemoveComplaintTypeByComplaintID(complaintID,"C");
                foreach (Int32 complaintTypeID in civm.complaint_type)
                {
                    this.cr.InsertComplaintTypeAssistance(
                        new complaint_types_list {
                            ComplaintID = complaintID,
                            ComplaintTypeId = complaintTypeID,
                            Member = "C"
                    });
                }
            }
            if(civm.assistanceNeeded != null)
            {
                this.cr.RemoveComplaintTypeByComplaintID(complaintID, "A");
                foreach (Int32 complaintTypeID in civm.assistanceNeeded)
                {
                    this.cr.InsertComplaintTypeAssistance(
                        new complaint_types_list
                        {
                            ComplaintID = complaintID,
                            ComplaintTypeId = complaintTypeID,
                            Member = "A"
                        });
                }
            }
            if(civm.date_informed_the_hf != null)
            {
                this.cr.RemoveComplaintsDates(complaintID, "date_informed_the_hf");
                foreach(String s in civm.date_informed_the_hf)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates {
                        Date = Convert.ToDateTime(s),
                        complaintID = complaintID,
                        member = "date_informed_the_hf"
                    });
                }
            }

            if (civm.date_hf_submitted_reply != null)
            {
                this.cr.RemoveComplaintsDates(complaintID, "date_hf_submitted_reply");
                foreach (String s in civm.date_hf_submitted_reply)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates
                    {
                        Date = Convert.ToDateTime(s),
                        complaintID = complaintID,
                        member = "date_hf_submitted_reply"
                    });
                }
            }

            if (civm.date_release_to_records != null)
            {
                this.cr.RemoveComplaintsDates(complaintID, "date_release_to_records");
                foreach (String s in civm.date_release_to_records)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates
                    {
                        Date = Convert.ToDateTime(s),
                        complaintID = complaintID,
                        member = "date_release_to_records"
                    });
                }
            }

            if (civm.date_final_resolution != null)
            {
                this.cr.RemoveComplaintsDates(complaintID, "date_final_resolution");
                foreach (String s in civm.date_final_resolution)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates
                    {
                        Date = Convert.ToDateTime(s),
                        complaintID = complaintID,
                        member = "date_final_resolution"
                    });
                }
            }
            if(civm.actionTaken != null)
            {
                this.cr.RemoveComplaintActions(complaintID);
                for(int i = 0; i < civm.actionTaken.Count();i++)
                {
                    this.cr.InsertComplaintActions(new complaint_action_dates {
                        Date = Convert.ToDateTime(civm.actionDate[i]),
                        Action = civm.actionTaken[i],
                        complaintID = complaintID
                    });
                }
            }
        }
    }
}