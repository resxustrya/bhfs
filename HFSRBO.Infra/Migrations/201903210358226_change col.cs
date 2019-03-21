namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecol : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "status", c => c.String());
        }
    }
}
