﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HFSRBO.Core;
namespace HFSRBO.WebClient
{
    public class VMComplaintCustomBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var form = controllerContext.HttpContext.Request.Form;
            ComplaintInfoViewModel _civm = new ComplaintInfoViewModel();
            _civm.anonymous = Convert.ToBoolean(form.Get("anonymous"));
            _civm.codeNumber = form.Get("codeNumber");
            _civm.firstname = form.Get("firstname");
            _civm.lastname = form.Get("lastname");
            _civm.mi = form.Get("mi");
            _civm.civil_status = form.Get("civil_status");
            _civm.gender = form.Get("gender");
            try { _civm.date = Convert.ToDateTime(form.Get("date")); } catch { }
            _civm.relationship = form.Get("relationship");
            _civm.telNo = form.Get("telNo");
            _civm.mobile = form.Get("mobile");
            _civm.address = form.Get("address");
            _civm.p_firstname = form.Get("p_firstname");
            _civm.p_lastname = form.Get("p_lastname");
            _civm.p_mi = form.Get("p_mi");
            _civm.date_confined = form.Get("date_confined");
            try { _civm.age = Convert.ToInt32(form.Get("age")); } catch { }
            try { _civm.hospitalID = Convert.ToInt32(form.Get("hospitalID")); } catch { }
            _civm.other_complaint = form.Get("other_complaint");
            _civm.assistance_needed = form.Get("assistance_needed");
            _civm.reasonOfConfinement = form.Get("reasonOfConfinement");
            _civm.pccCheck = Convert.ToBoolean(form.Get("pccCheck"));
            _civm.pccNumber = form.Get("pccNumber");
            _civm.communication_form = form.Get("communication_form");
            _civm.ownership = form.Get("ownership");
            _civm.date_informed_the_hf = form.Get("date_informed_the_hf");
            _civm.date_hf_submitted_reply = form.Get("date_hf_submitted_reply");
            _civm.date_release_to_records = form.Get("date_release_to_records");
            _civm.date_final_resolution = form.Get("date_final_resolution");

            return _civm;
        }
    }
}