﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HFSRBO
{
    public class staff_assigend
    {
        [Key]
        public Int32 ID { get; set; }
        public String Name { get; set; }
    }
}