using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO.Core
{
    public class hospitals
    {
        [Key]
        public Int32 ID { get; set; }
        public String name { get; set; }
        public String address { get; set; }
        public Int32 facilityID { get; set;}
        public String facilityType { get; set; }
    }
}