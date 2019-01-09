namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_created : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "date_created", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "date_created");
        }
    }
}
