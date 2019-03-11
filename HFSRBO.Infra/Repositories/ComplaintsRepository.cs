﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFSRBO.Core;
using System.Data.Entity;
namespace HFSRBO.Infra
{
    public class ComplaintsRepository : IComplaintsRepository
    {
        hfsrboContext db = new hfsrboContext();
        HospitalRepo hr = new HospitalRepo();
        ComplaintTypesRepo ctr = new ComplaintTypesRepo();
        ComplaintAssistanceRepo cat = new ComplaintAssistanceRepo();
        NameOfComplainantRepo nocp = new NameOfComplainantRepo();
        PatientRepo patient = new PatientRepo();
        public Int32 Add(complaints _complaints)
        {
            db.complaints.Add(_complaints);
            db.SaveChanges();
            return _complaints.ID;
        }
        public void Edit(complaints _complaints)
        {
            db.Entry(_complaints).State = EntityState.Modified;
        }
        public void Remove(Int32 ID)
        {
            try
            {
                db.complaints.Remove(db.complaints.Where(p => p.ID == ID).FirstOrDefault());
                nocp.Remove(ID);
                patient.Remove(ID);
                this.RemoveComplaintActions(ID);
                this.RemoveComplaintTypeByComplaintID(ID,"C");
                this.RemoveComplaintTypeByComplaintID(ID, "date_informed_the_hf");
                this.RemoveComplaintsDates(ID, "date_informed_the_hf");
                this.RemoveComplaintsDates(ID, "date_hf_submitted_reply");
                this.RemoveComplaintsDates(ID, "date_release_to_records");
                this.RemoveComplaintsDates(ID, "date_final_resolution");
                db.SaveChanges();
            }
            catch { }
        }

        public void RemoveComplaintTypeByComplaintID(Int32 complaintID, String member)
        {
            var result = db._complaint_types_list.Where(p => p.ComplaintID == complaintID && p.Member == member).ToList();
            db._complaint_types_list.RemoveRange(result);
            db.SaveChanges();
        }

        public complaints FindById(Int32 ID)
        {
            var result = db.complaints.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
       
        public CreateComplaintViewModel getCreateComplaintViewModel()
        {
            CreateComplaintViewModel _viewModel = new CreateComplaintViewModel
            {
                _hospitals = hr.GetHospitals(),
                _communications = this.GetCommunicationForm(),
                _complaint_type = ctr.GetComplaintTypes(),
                _complaintAssistance = cat.GetComplaintAssistance()
            };
            return _viewModel;
        }

        public IEnumerable<communication> GetCommunicationForm()
        {
            var result = db._communication;
            return result;
        }
        public void InsertComplaintTypeAssistance(complaint_types_list _complaint_types_list)
        {
            db._complaint_types_list.Add(_complaint_types_list);
            db.SaveChanges();
        }
        public Int32[] GetComplaintTypeAssistance(Int32 complaintID, String member)
        {
            Int32[] list = db._complaint_types_list.Where(p => p.ComplaintID == complaintID && p.Member == member).Select(p => p.ComplaintTypeId).ToArray();
            return list;
        }
        public void InsertComplaintsDates(complaint_dates _complaintsDates)
        {
            db._complaintsDates.Add(_complaintsDates);
            db.SaveChanges();
        }

        public IEnumerable<complaint_action_dates> GetComplaintActions(Int32 complaintID)
        {
            var result = db.complaintActionDates.Where(p => p.complaintID == complaintID).ToList();
            return result;
        }
        public List<String> GetComplaintsDates(Int32 complaintID, String member)
        {
            List<String> result = db._complaintsDates.Where(p => p.complaintID == complaintID && p.member == member).Select(p => p.Date).ToList();
            return result;
        }
        public void RemoveComplaintsDates(Int32 complaintID, String member)
        {
            var result = db._complaintsDates.Where(p => p.complaintID == complaintID && p.member == member).ToList();
            db._complaintsDates.RemoveRange(result);
        }

        public void InsertComplaintActions(complaint_action_dates _complaintActionDates)
        {
            db.complaintActionDates.Add(_complaintActionDates);
            db.SaveChanges();
        }
        public void RemoveComplaintActions(Int32 complaintID)
        {
            var result = db.complaintActionDates.Where(p => p.complaintID == complaintID).ToList();
            db.complaintActionDates.RemoveRange(result);
        }

        
        public IEnumerable<DisplayComplaintViewModel> GetComplaints()
        {

            var result = (from list in db.complaints where list.active == true
                          select new DisplayComplaintViewModel
                          {
                              complaintID = list.ID,
                              codeNumber = list.codeNumber,
                              dateCreated = list.date_created,
                              hospitalName = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.name).FirstOrDefault(),
                              hospitalAddress = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.address).FirstOrDefault(),
                              nameOfComplainant = (from name in db.complainantName where name.complaintId == list.ID select name.firstname + " " + name.mi + " " + name.lastname).FirstOrDefault(),
                              ownership = list.ownership,
                              communication_form = (from comm_form in db._communication where comm_form.ID.ToString() == list.communication_form select comm_form.desc).FirstOrDefault(),
                              annonymos = list.annonymos,
                              pccCheck = list.pccCheck,
                              pccNumber = list.pccNumber,
                              status = list.status,
                              staff = list.staff,
                              complaint_type = (from ct in db.complaintType join ctl in db._complaint_types_list on ct.ID equals ctl.ComplaintTypeId where ctl.ComplaintID == list.ID && ctl.Member == "C" select ct.Description).ToList(), 
                              assistanceNeeded = (from ca in db.complaintAssistance join ctl in db._complaint_types_list on ca.ID equals ctl.ComplaintTypeId where ctl.ComplaintID == list.ID && ctl.Member == "A" select ca.assistance).ToList(),
                              date_informed_the_hf = db._complaintsDates.Where(p => p.complaintID == list.ID && p.member == "date_informed_the_hf").ToList().Select(p => p.Date).ToList(),
                              date_hf_submitted_reply = db._complaintsDates.Where(p => p.complaintID == list.ID && p.member == "date_hf_submitted_reply").ToList().Select(p => p.Date).ToList(),
                              date_release_to_records = db._complaintsDates.Where(p => p.complaintID == list.ID && p.member == "date_release_to_records").ToList().Select(p => p.Date).ToList(),
                              date_final_resolution = db._complaintsDates.Where(p => p.complaintID == list.ID && p.member == "date_final_resolution").ToList().Select(p => p.Date).ToList(),
                              _complaintActionDates = db.complaintActionDates.Where(p => p.complaintID == list.ID)
                          }).ToList();
            return result;
        }
    }
}
