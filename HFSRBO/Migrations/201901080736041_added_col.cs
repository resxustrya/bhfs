namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "status");
        }
    }
}
