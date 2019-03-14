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
        private IHospitalRepo hr;
        // GET: Complaint
        public ComplaintController(IComplaintsRepository cr, INameOfComplainantRepository nameOfComplainantRepo, IComplaintPatientRepository _patientRepo, IHospitalRepo hr)
        {
            this.cr = cr;
            this.nameOfComplainantRepo = nameOfComplainantRepo;
            this._patientRepo = _patientRepo;
            this.hr = hr;
        }
        public ComplaintController()
        {}
        public ActionResult Complaints()
        {
            IEnumerable<DisplayComplaintViewModel> list = this.cr.GetComplaints();
            return View(list);
        }

        public ActionResult GetComplaints()
        {
            IEnumerable<DisplayComplaintViewModel> list = this.cr.GetComplaints();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateComplaint()
        {
            CreateComplaintViewModel createComplaintVM = this.cr.getCreateComplaintViewModel();
            return View(createComplaintVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateComplaint([ModelBinder(typeof(VMComplaintCustomBinder))] ComplaintInfoViewModel civm,List<String> date_informed_the_hf,List<String> date_hf_submitted_reply,List<String> date_release_to_records,List<String> date_final_resolution, List<String> complaint_type,List<String> complaint_assistance,List<String> actionTaken,List<String> actionDate)
        {
            civm.complaint_type = complaint_type;
            civm.assistanceNeeded = complaint_assistance;
            civm.date_informed_the_hf = date_informed_the_hf;
            civm.date_hf_submitted_reply = date_hf_submitted_reply;
            civm.date_release_to_records = date_release_to_records;
            civm.date_final_resolution = date_final_resolution;
            civm.actionTaken = actionTaken;
            civm.actionDate = actionDate;

            //ADD NEW COMPLAINT TO DATABASE AND RETURN ITS ID(PRIMARY KEY) AFTER INSERTED
            Int32 complaintID = this.cr.Add(civm._complaints);
            civm._nameOfComplainant.complaintId = complaintID;
            this.nameOfComplainantRepo.Add(civm._nameOfComplainant);
            civm._complaintPatient.complaintID = complaintID;
            this._patientRepo.Add(civm._complaintPatient);


            SaveComplaint(civm,complaintID);
            return RedirectToAction("Complaints");
        }

        public void SaveComplaint(ComplaintInfoViewModel civm,Int32 complaintID)
        {
            this.cr.RemoveComplaintTypeByComplaintID(complaintID, "C");
            this.cr.RemoveComplaintTypeByComplaintID(complaintID, "A");
            this.cr.RemoveComplaintsDates(complaintID, "date_informed_the_hf");
            this.cr.RemoveComplaintsDates(complaintID, "date_hf_submitted_reply");
            this.cr.RemoveComplaintsDates(complaintID, "date_release_to_records");
            this.cr.RemoveComplaintsDates(complaintID, "date_final_resolution");
            this.cr.RemoveComplaintActions(complaintID);

            if (civm.complaint_type != null)
            {
                
                foreach (String complaintTypeID in civm.complaint_type)
                {
                    this.cr.InsertComplaintTypeAssistance(
                        new complaint_types_list {
                            ComplaintID = complaintID,
                            ComplaintTypeId = Int32.Parse(complaintTypeID),
                            Member = "C"
                    });
                }
            }
            if(civm.assistanceNeeded != null)
            {
                
                foreach (String complaintTypeID in civm.assistanceNeeded)
                {
                    this.cr.InsertComplaintTypeAssistance(
                        new complaint_types_list
                        {
                            ComplaintID = complaintID,
                            ComplaintTypeId = Int32.Parse(complaintTypeID),
                            Member = "A"
                        });
                }
            }
            if(civm.date_informed_the_hf != null)
            {
                
                foreach(String s in civm.date_informed_the_hf)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates {
                        Date = s,
                        complaintID = complaintID,
                        member = "date_informed_the_hf"
                    });
                }
            }

            if (civm.date_hf_submitted_reply != null)
            {
                
                foreach (String s in civm.date_hf_submitted_reply)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates
                    {
                        Date =s,
                        complaintID = complaintID,
                        member = "date_hf_submitted_reply"
                    });
                }
            }

            if (civm.date_release_to_records != null)
            {
                
                foreach (String s in civm.date_release_to_records)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates
                    {
                        Date = s,
                        complaintID = complaintID,
                        member = "date_release_to_records"
                    });
                }
            }

            if (civm.date_final_resolution != null)
            {
                
                foreach (String s in civm.date_final_resolution)
                {
                    this.cr.InsertComplaintsDates(new complaint_dates
                    {
                        Date = s,
                        complaintID = complaintID,
                        member = "date_final_resolution"
                    });
                }
            }
            if(civm.actionTaken != null)
            {
                
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
        public ActionResult DeleteComplaint(String ID)
        {
            Int32 complaintID = Convert.ToInt32(ID);
            this.cr.Remove(complaintID);
            return RedirectToAction("Complaints");
        }
        public ActionResult GetHealthFacility()
        {
            var result = this.hr.GetHealthFacilities().Select(p => new { p.Name, p.ID }).ToList();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public ActionResult EditComplaint(String ID)
        {
            Session["EditComplaintID"] = ID;
            Int32 complaintID = Convert.ToInt32(ID);
            var result = this.cr.EditComplaint(complaintID);
            return View(result);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditComplaint([ModelBinder(typeof(VMComplaintCustomBinder))] ComplaintInfoViewModel civm, List<String> date_informed_the_hf, List<String> date_hf_submitted_reply, List<String> date_release_to_records, List<String> date_final_resolution, List<String> complaint_type, List<String> complaint_assistance, List<String> actionTaken, List<String> actionDate)
        {
            Int32 complaintID = Convert.ToInt32(Session["EditComplaintID"].ToString());
            try
            {
                civm.complaint_type = complaint_type;
                civm.assistanceNeeded = complaint_assistance;
                civm.date_informed_the_hf = date_informed_the_hf;
                civm.date_hf_submitted_reply = date_hf_submitted_reply;
                civm.date_release_to_records = date_release_to_records;
                civm.date_final_resolution = date_final_resolution;
                civm.actionTaken = actionTaken;
                civm.actionDate = actionDate;

                //UPDATE THE COMPLAINT
                this.cr.Edit(civm._complaints);
                this.nameOfComplainantRepo.Edit(civm._nameOfComplainant);
                this._patientRepo.Edit(civm._complaintPatient);
                SaveComplaint(civm, complaintID);
                TempData["EditSuccess"] = true;
            }
            catch
            {
                TempData["EditSuccess"] = false;
            }
            return RedirectToAction("EditComplaint",new { ID = complaintID.ToString() });
        }

        public ActionResult Filter()
        {
            CreateComplaintViewModel filterViewData = this.cr.getCreateComplaintViewModel();
            return PartialView(filterViewData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filter(FilterViewModel filterViewData)
        {
            IEnumerable<DisplayComplaintViewModel> list = this.cr.FilterComplaints(filterViewData);
            return View();
        }
    }
}