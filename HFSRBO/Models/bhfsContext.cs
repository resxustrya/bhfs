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
        public DbSet<complaints> complaints { get; set; }
        public DbSet<complaint_types_list> complaint_types_list { get; set; }
        public DbSet<hospitals> hospitals { get; set; }
        public DbSet<actions_takened> actions { get; set; }
    }
}