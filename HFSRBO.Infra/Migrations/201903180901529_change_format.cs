namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_format : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_patient", "date_confined", c => c.String());
            DropColumn("dbo.complaints", "date_confined");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "date_confined", c => c.DateTime());
            DropColumn("dbo.complaint_patient", "date_confined");
        }
    }
}
