using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class complaint_dates
    {
        [Key]
        public Int32 ID { get; set; }
        public String Date { get; set; }
        public Int32 complaintID { get; set; }
        public String member { get; set; }
    }
}
