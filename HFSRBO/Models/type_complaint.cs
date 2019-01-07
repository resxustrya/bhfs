using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO
{
    public class type_complaint
    {
        [Key]
        public Int32 ID { get; set; }
        public String Description { get; set; }
    }
}