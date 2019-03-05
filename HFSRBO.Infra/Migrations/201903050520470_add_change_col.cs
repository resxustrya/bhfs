namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_change_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_action_dates", "Action", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaint_action_dates", "Action");
        }
    }
}
