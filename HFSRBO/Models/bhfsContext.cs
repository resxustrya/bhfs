using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HFSRBO
{
    public class bhfsContext : DbContext
    {
        public bhfsContext() : base("name=bhfs")
        { }
        public DbSet<type_complaint> type_complaint { get; set; }
        public DbSet<staff_assigend> staff_assigend { get; set; }
    }
}