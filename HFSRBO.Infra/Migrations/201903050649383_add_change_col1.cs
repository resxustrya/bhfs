namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_change_col1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaint_dates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        complaintID = c.Int(nullable: false),
                        member = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.complaint_action_dates", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.complaint_action_dates", "DateType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaint_action_dates", "DateType", c => c.String());
            AlterColumn("dbo.complaint_action_dates", "Date", c => c.DateTime());
            DropTable("dbo.complaint_dates");
        }
    }
}
