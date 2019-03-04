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
        hfsrboContext db = new hfsrboContext();
        HospitalRepo hr = new HospitalRepo();
        communicationsViewModel cvm = new communicationsViewModel();
        ComplaintTypesRepo ctr = new ComplaintTypesRepo();
        ComplaintAssistanceRepo cat = new ComplaintAssistanceRepo();
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
                db.SaveChanges();
            }
            catch { }
        }
        public complaints FindById(Int32 ID)
        {
            var result = db.complaints.Where(p => p.ID == ID).FirstOrDefault();
            return result;
        }
        public IEnumerable<complaints> GetComplaints()
        {
            return db.complaints;
        }
        public CreateComplaintViewModel getCreateComplaintViewModel()
        {
            CreateComplaintViewModel _viewModel = new CreateComplaintViewModel
            {
                _hospitals = hr.GetHospitals(),
                _communications = cvm._communication,
                _complaint_type = ctr.GetComplaintTypes(),
                _complaintAssistance = cat.GetComplaintAssistance()
            };
            return _viewModel;
        }
        public void InsertComplaintTypeComplaintAsistance(complaint_types_list _complaint_types_list)
        {
            db._complaint_types_list.Add(_complaint_types_list);
            db.SaveChanges();
        }
    }
}
