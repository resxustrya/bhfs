using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using HFSRBO.Core;
namespace HFSRBO.Infra
{
    public class hfsrboContext : DbContext
    {
        public hfsrboContext() : base("name=hfsrbo") { }

        public DbSet<complaints> complaints { get; set; }
        public DbSet<complaint_nameOfComplainant> complainantName { get; set; }
        public DbSet<complaint_patient> patient { get; set; }
        public DbSet<hospitals> hospitals { get; set; }
        public DbSet<facility_type> facilityType { get; set; }
        public DbSet<type_complaint> complaintType { get; set; }
        public DbSet<complaint_assistance> complaintAssistance { get; set; }
        public DbSet<complaint_action_dates> complaintActionDates { get; set; }
        public DbSet<complaint_types_list> _complaint_types_list { get; set; }
    }
}
