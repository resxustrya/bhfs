using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class actions_takened
    {
        [Key]
        public Int32 ID { get; set; }
        public String actions { get; set; }
        public Int32 ComplaintID { get; set; }
        public DateTime DateCreated { get; set; }
    }
}