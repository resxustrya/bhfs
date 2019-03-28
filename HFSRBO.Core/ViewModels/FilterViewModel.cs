using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFSRBO.Core
{
    public class FilterViewModel
    {
        public Int32[] complaintType { get; set; }
        public Int32[] complaintAssistance { get; set; }
        public Int32[] hospitalID { get; set; }
        public String status { get; set; }
        public String display { get; set; }
        public String search { get; set; }
        public String date_receive { get; set; }
        public String date_entry { get; set; }



    }
}
