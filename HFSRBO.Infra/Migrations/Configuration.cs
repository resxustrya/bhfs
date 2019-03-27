namespace HFSRBO.Infra.Migrations
{
    using Core;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HFSRBO.Infra.hfsrboContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HFSRBO.Infra.hfsrboContext context)
        {
        }
    }
}
