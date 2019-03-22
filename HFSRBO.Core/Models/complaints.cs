using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class complaints
    {
        
        [Key]
        public Int32 ID { get; set; }
        public String codeNumber { get; set; }
        public Int32 hospitalID { get; set; }
        public String other_complaint { get; set; }
        public String reasonOfConfinement { get; set; }
        public String assistance_needed { get; set; }
        public Int32 communication_form { get; set; }
        public String pccNumber { get; set; }
        public String ownership { get; set; }
        public Int32 status { get; set; }
        public String staff { get; set; }
        public DateTime date_created { get; set; }
        public Boolean active { get; set; }
        public Boolean annonymos { get; set; }
        public Boolean pccCheck { get; set; }
        public Int32 year { get; set; }

        public complaints()
        {
            this.date_created = DateTime.Now;
        }
    }
}