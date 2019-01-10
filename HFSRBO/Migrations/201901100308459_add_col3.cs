namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.actions_takened", "DateCreated", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.actions_takened", "DateCreated");
        }
    }
}
