namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_col1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.hospitals", "facilityID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.hospitals", "facilityID");
        }
    }
}
