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

            context._communication.Add(new communication { ID = 1, desc = "By Photo" });
            context._communication.Add(new communication { ID = 2, desc = "By Mail" });
            context._communication.Add(new communication { ID = 3, desc = "By Interview walk-in" });
            context._communication.Add(new communication { ID = 4, desc = "By Social media" });
            context._communication.Add(new communication { ID = 5, desc = "By Postal Mail" });
            context._communication.Add(new communication { ID = 6, desc = "By Text Message" });
            context._communication.Add(new communication { ID = 7, desc = "By Interview" });
            context._communication.Add(new communication { ID = 8, desc = "By Email" });
            context._communication.Add(new communication { ID = 9, desc = "Courier" });

            try { context.SaveChanges(); } catch { }
        }
    }
}
