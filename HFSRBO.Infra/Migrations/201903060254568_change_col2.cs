namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_col2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaint_dates", "Date", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaint_dates", "Date", c => c.DateTime(nullable: false));
        }
    }
}
