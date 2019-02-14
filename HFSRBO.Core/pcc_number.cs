using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class pcc_number
    {
        [Key]
        public Int32 ID { get; set; }
        public Int32 complaintID { get; set; }
        public String pccNumber { get; set; }
    }
}