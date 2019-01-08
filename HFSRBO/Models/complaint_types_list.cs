using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO
{
    public class complaint_types_list
    {
        [Key]
        public Int32 ID { get; set; }
        public Int32 ComplaintID { get; set; }
        public Int32 ComplaintTypeId { get; set; }
    }
}