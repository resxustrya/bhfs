using System;
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
        private hfsrboContext db = new hfsrboContext();
        private HospitalRepo hr = new HospitalRepo();
        private ComplaintTypesRepo ctr = new ComplaintTypesRepo();
        private ComplaintAssistanceRepo cat = new ComplaintAssistanceRepo();
        private NameOfComplainantRepo nocp = new NameOfComplainantRepo();
        private PatientRepo patient = new PatientRepo();
        public Int32 Add(complaints _complaints)
        {
            db.complaints.Add(_complaints);
            db.SaveChanges();
            return _complaints.ID;
        }
        public void Edit(complaints _complaints)
        {
            db.Entry(_complaints).State = EntityState.Modified;
            db.SaveChanges();
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
            IEnumerable<DisplayComplaintViewModel> result = null;
            result = (from list in db.complaints where list.active == true orderby list.date_created descending
                          select new DisplayComplaintViewModel
                          {
                              complaintID = list.ID,
                              codeNumber = list.codeNumber,
                              dateCreated = list.date_created,
                              hospitalName = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.name).FirstOrDefault(),
                              hospitalAddress = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.address).FirstOrDefault(),
                              nameOfComplainant = (from name in db.complainantName where name.complaintId == list.ID select name.firstname + " " + name.mi + " " + name.lastname).FirstOrDefault(),
                              ownership = list.ownership,
                              communication_form = (from comm_form in db._communication where comm_form.ID == list.communication_form select comm_form.desc).FirstOrDefault(),
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
        public EditComplaintViewModel EditComplaint(Int32 complaintID)
        {
            EditComplaintViewModel result = new EditComplaintViewModel
            {
                _complaint = this.FindById(complaintID),
                _nameOfComplainant = this.nocp.FindById(complaintID),
                _patient = this.patient.FindById(complaintID),
                _complaint_type_list = this.GetComplaintTypeAssistance(complaintID,"C"),
                _complaintAssistance = this.GetComplaintTypeAssistance(complaintID,"A"),
                date_informed_the_hf = db._complaintsDates.Where(p => p.complaintID == complaintID && p.member == "date_informed_the_hf").ToList().Select(p => p.Date).ToList(),
                date_hf_submitted_reply = db._complaintsDates.Where(p => p.complaintID == complaintID && p.member == "date_hf_submitted_reply").ToList().Select(p => p.Date).ToList(),
                date_release_to_records = db._complaintsDates.Where(p => p.complaintID == complaintID && p.member == "date_release_to_records").ToList().Select(p => p.Date).ToList(),
                date_final_resolution = db._complaintsDates.Where(p => p.complaintID == complaintID && p.member == "date_final_resolution").ToList().Select(p => p.Date).ToList(),
                _complaintActionDates = db.complaintActionDates.Where(p => p.complaintID == complaintID),
                _createComplaintViewModel = this.getCreateComplaintViewModel()
            };
            return result;
        }
        public IEnumerable<DisplayComplaintViewModel> FilterComplaints(FilterViewModel filterViewData)
        {
            IEnumerable<DisplayComplaintViewModel> filterComplaints = null;
            IEnumerable<complaints> _complaints = null;
            DateTime dateFrom = Convert.ToDateTime(filterViewData.date_from);
            DateTime dateTo = Convert.ToDateTime(filterViewData.date_to);
            String where = "",query = "", join = "";
            
            where = " WHERE complaint_list.date_created BETWEEN '" + dateFrom.ToString() + "'" + " AND '" + dateTo.ToString() + "'";
            
            if(filterViewData.complaintType != null && filterViewData.complaintAssistance != null)
            {
                where += " AND (ctl.ComplaintTypeId IN (";
                if (filterViewData.complaintType.Count() == 1)
                    where += "'" + filterViewData.complaintType[0].ToString().Trim() + "'";
                else
                {
                    for (int i = 1; i <= filterViewData.complaintType.Count(); i++)
                    {
                        if (i == filterViewData.complaintType.Count())
                            where += "'" + filterViewData.complaintType[i - 1].ToString().Trim() + "'";
                        else
                            where += "'" + filterViewData.complaintType[i - 1].ToString().Trim() + "',";
                    }
                }

                where += ") AND ctl.Member = 'C') ";

                where += " OR (ctl.ComplaintTypeId IN (";
              

                if (filterViewData.complaintAssistance.Count() == 1)
                    where += "'" + filterViewData.complaintAssistance[0].ToString().Trim() + "'";
                else
                {
                    for (int i = 1; i <= filterViewData.complaintAssistance.Count(); i++)
                    {
                        if (i == filterViewData.complaintAssistance.Count())
                            where += "'" + filterViewData.complaintAssistance[i - 1].ToString().Trim() + "'";
                        else
                            where += "'" + filterViewData.complaintAssistance[i - 1].ToString().Trim() + "',";
                    }
                }

                where += ") AND ctl.Member = 'A') ";
            }
            else if(filterViewData.complaintType != null)
            {
                where += " AND ctl.ComplaintTypeId IN (";
                if (filterViewData.complaintType.Count() == 1)
                    where += "'" + filterViewData.complaintType[0].ToString().Trim() + "'";
                else
                {
                    for (int i = 1; i <= filterViewData.complaintType.Count(); i++)
                    {
                        if (i == filterViewData.complaintType.Count())
                            where += "'" + filterViewData.complaintType[i - 1].ToString().Trim() + "'";
                        else
                            where += "'" + filterViewData.complaintType[i - 1].ToString().Trim() + "',";
                    }
                }

                where += ") AND ctl.Member = 'C' ";
            }
            else if(filterViewData.complaintAssistance != null)
            {
                where += " AND ctl.ComplaintTypeId IN (";
                if (filterViewData.complaintAssistance.Count() == 1)
                    where += "'" + filterViewData.complaintAssistance[0].ToString().Trim() + "'";
                else
                {
                    for (int i = 1; i <= filterViewData.complaintAssistance.Count(); i++)
                    {
                        if (i == filterViewData.complaintAssistance.Count())
                            where += "'" + filterViewData.complaintAssistance[i - 1].ToString().Trim() + "'";
                        else
                            where += "'" + filterViewData.complaintAssistance[i - 1].ToString().Trim() + "',";
                    }
                }

                where += ") AND ctl.Member = 'A' ";
            }

            if(filterViewData.hospitalID != null)
            {
                where += " AND complaint_list.hospitalID IN (";
                if (filterViewData.hospitalID.Count() == 1)
                    where += "'" + filterViewData.hospitalID[0].ToString().Trim() + "'";
                else
                {
                    for (int i = 1; i <= filterViewData.hospitalID.Count(); i++)
                    {
                        if (i == filterViewData.hospitalID.Count())
                            where += "'" + filterViewData.hospitalID[i - 1].ToString().Trim() + "'";
                        else
                            where += "'" + filterViewData.hospitalID[i - 1].ToString().Trim() + "',";
                    }
                }

                where += ")";
            }

            if(filterViewData.status != null)
            {
                where += " AND complaint_list.status = " + filterViewData.status;
            }
            if(filterViewData.complaintType != null || filterViewData.complaintAssistance != null)
            {
                join = " JOIN[hfsrbo].[dbo].[complaint_types_list] ctl ON complaint_list.ID = ctl.ComplaintID ";
            }
            query = "SELECT DISTINCT complaint_list.* FROM [hfsrbo].[dbo].[complaints] complaint_list " + join + where + " AND complaint_list.active = 1 ORDER BY complaint_list.date_created DESC";
           
            
            _complaints = db.complaints.SqlQuery(query).ToList();

            filterComplaints = _complaints.Select(list => new DisplayComplaintViewModel
            {
                complaintID = list.ID,
                codeNumber = list.codeNumber,
                dateCreated = list.date_created,
                hospitalName = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.name).FirstOrDefault(),
                hospitalAddress = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.address).FirstOrDefault(),
                nameOfComplainant = (from name in db.complainantName where name.complaintId == list.ID select name.firstname + " " + name.mi + " " + name.lastname).FirstOrDefault(),
                ownership = list.ownership,
                communication_form = (from comm_form in db._communication where comm_form.ID == list.communication_form select comm_form.desc).FirstOrDefault(),
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
                _complaintActionDates = db.complaintActionDates.Where(p => p.complaintID == list.ID),
                other_complaint = list.other_complaint,
                otherAssistanceNeed = list.assistance_needed
                          
            });
            return filterComplaints.ToList();
        }
        public IEnumerable<DisplayComplaintViewModel> Search(String search)
        {
            String query = "";
            IEnumerable<DisplayComplaintViewModel> result = null;
            IEnumerable<complaints> _complaints = null;

            _complaints = db.complaints.Where(p => p.codeNumber.ToLower().Contains(search.ToLower())).ToList();
            if(_complaints == null)
            {
                _complaints = (from c in db.complaints join hl in db.hospitals on c.hospitalID equals hl.ID where hl.name.ToLower().Contains(search.ToLower()) select c).ToList();
            }
            if(_complaints != null)
            {
                result = _complaints.Select(list => new DisplayComplaintViewModel
                {
                    complaintID = list.ID,
                    codeNumber = list.codeNumber,
                    dateCreated = list.date_created,
                    hospitalName = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.name).FirstOrDefault(),
                    hospitalAddress = db.hospitals.Where(p => p.ID == list.hospitalID).Select(p => p.address).FirstOrDefault(),
                    nameOfComplainant = (from name in db.complainantName where name.complaintId == list.ID select name.firstname + " " + name.mi + " " + name.lastname).FirstOrDefault(),
                    ownership = list.ownership,
                    communication_form = (from comm_form in db._communication where comm_form.ID == list.communication_form select comm_form.desc).FirstOrDefault(),
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
                    _complaintActionDates = db.complaintActionDates.Where(p => p.complaintID == list.ID),
                    other_complaint = list.other_complaint,
                    otherAssistanceNeed = list.assistance_needed

                });
            }

            return result;

            
        }
    }
}
