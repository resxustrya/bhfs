namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaint_action_dates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        DateType = c.String(),
                        complaintID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.complaint_action_dates");
        }
    }
}
