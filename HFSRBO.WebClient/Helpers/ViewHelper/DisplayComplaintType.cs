using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HFSRBO.Core;
namespace HFSRBO.WebClient
{
    public class DisplayComplaintType
    {
        private IComplaintAssistanceRepo car;
        public DisplayComplaintType(IComplaintAssistanceRepo car)
        {
            this.car = car;
        }
    }
}