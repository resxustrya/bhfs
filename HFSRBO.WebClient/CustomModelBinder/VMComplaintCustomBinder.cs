using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using HFSRBO.Core;
using HFSRBO.Infra;
namespace HFSRBO.WebClient
{
    public class VMComplaintCustomBinder : IModelBinder
    {
        private IComplaintsRepository cr = new ComplaintsRepository();
        private INameOfComplainantRepository nameOfComplainantRepo = new NameOfComplainantRepo();
        private IComplaintPatientRepository _patientRepo = new PatientRepo();
        private IHospitalRepo hr = new HospitalRepo();

        
        public VMComplaintCustomBinder() { }
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            ComplaintInfoViewModel _civm = new ComplaintInfoViewModel();
            
            if(HttpContext.Current.Session["EditComplaintID"] != null)
            {
                Int32 complaintID = Convert.ToInt32(HttpContext.Current.Session["EditComplaintID"].ToString());
                _civm._complaints = this.cr.FindById(complaintID);
                _civm._nameOfComplainant = this.nameOfComplainantRepo.FindById(complaintID);
                _civm._complaintPatient = this._patientRepo.FindById(complaintID);
            }
            else
            {
                _civm._complaints = new complaints();
                _civm._complaints.date_created = DateTime.Now;
                _civm._complaints.staff = HttpContext.Current.User.Identity.GetUserName();

                _civm._complaints.active = true;
                _civm._nameOfComplainant = new complaint_nameOfComplainant();
                _civm._complaintPatient = new complaint_patient();
            }

            //COMPLAINT INFORMATION
            if (form.Get("anonymous").Trim().ToLower() == "1")
                _civm._complaints.annonymos = true;
            else _civm._complaints.annonymos = false;

            if (form.Get("pccCheck").Trim().ToLower() == "1")
            {
                _civm._complaints.pccCheck = true;
                _civm._complaints.pccNumber = form.Get("pccNumber");
            }
            else
            {
                _civm._complaints.pccCheck = false;
                _civm._complaints.communication_form = Convert.ToInt32(form.Get("communication_form"));
            }


            _civm._complaints.codeNumber = form.Get("codeNumber");
            try { _civm._complaints.hospitalID = Convert.ToInt32(form.Get("hospitalID")); } catch { }
            _civm._complaints.reasonOfConfinement = form.Get("reasonOfConfinement");
            _civm._complaints.other_complaint = form.Get("other_complaint");
            _civm._complaints.assistance_needed = form.Get("other_assistance");
            _civm._complaints.ownership = form.Get("ownership");

            _civm._complaints.status = Convert.ToInt32(form.Get("status"));
            
            
            
            //COMPLAINANT INFORMATION
            
            _civm._nameOfComplainant.firstname = form.Get("firstname");
            _civm._nameOfComplainant.lastname = form.Get("lastname");
            _civm._nameOfComplainant.mi = form.Get("mi");
            _civm._nameOfComplainant.civil_status = form.Get("civil_status");
            _civm._nameOfComplainant.gender = form.Get("gender");
            try { _civm._nameOfComplainant.Date = Convert.ToDateTime(form.Get("date")); } catch { }
            _civm._nameOfComplainant.relationship = form.Get("relationship");
            _civm._nameOfComplainant.telNo = form.Get("telNo");
            _civm._nameOfComplainant.mobile = form.Get("mobile");
            _civm._nameOfComplainant.address = form.Get("address");

            //COMPLAINT PATIENT INFORMATION

            _civm._complaintPatient.p_firstname = form.Get("p_firstname");
            _civm._complaintPatient.p_lastname = form.Get("p_lastname");
            _civm._complaintPatient.p_mi = form.Get("p_mi");
            _civm._complaintPatient.date_confined = form.Get("date_confined");
            try { _civm._complaintPatient.age = Convert.ToInt32(form.Get("age")); } catch { }


            return _civm;
        }
    }
}