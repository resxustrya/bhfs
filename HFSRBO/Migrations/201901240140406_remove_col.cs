namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_col : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.complaints", "facility_type");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "facility_type", c => c.String());
        }
    }
}
