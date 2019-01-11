namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "active", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "active");
        }
    }
}
