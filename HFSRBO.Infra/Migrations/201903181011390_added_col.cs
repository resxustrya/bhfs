namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.hospitals", "facilityType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.hospitals", "facilityType");
        }
    }
}
