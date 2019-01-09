namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "hospitalID", c => c.Int(nullable: false));
            DropColumn("dbo.complaints", "name_facility_complained");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "name_facility_complained", c => c.String());
            DropColumn("dbo.complaints", "hospitalID");
        }
    }
}
