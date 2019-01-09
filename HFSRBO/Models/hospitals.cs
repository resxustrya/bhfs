using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HFSRBO
{
    public class hospitals
    {
        [Key]
        public Int32 ID { get; set; }
        public String name { get; set; }
        public String address { get; set; }
    }
}