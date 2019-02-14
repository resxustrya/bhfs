namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using HFSRBO.Core;
    internal sealed class Configuration : DbMigrationsConfiguration<HFSRBO.Infra.hfsrboContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HFSRBO.Infra.hfsrboContext context)
        {
            context.facilityType.Add(new facility_type { ID = 1, Name = "Drug Test" });
            context.facilityType.Add(new facility_type { ID = 2, Name = "Hospital" });
            context.facilityType.Add(new facility_type { ID = 3, Name = "Birthing Facility" });


            context.hospitals.Add(new hospitals { ID = 1, name = "UCMED", facilityID = 2 });
            context.hospitals.Add(new hospitals { ID = 2, name = "MIDICUS", facilityID = 1 });

            complaints _complaint = new complaints
            {
                Code = "RC-1",
                date = DateTime.Now,
                hospitalID = 1,
                date_confined = DateTime.Now,
                other_complaint = "Poor Service",
                ownership = "P",
                date_informed_the_hf = DateTime.Now,
                date_hf_submitted_reply = DateTime.Now,
                date_release_to_records = DateTime.Now,
                date_final_resolution = DateTime.Now,
                status = "O",
                date_created = DateTime.Now,
                active = true,
                year = 2019
            };

            context.complaints.Add(_complaint);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
