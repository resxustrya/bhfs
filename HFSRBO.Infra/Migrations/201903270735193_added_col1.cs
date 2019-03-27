namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_nameOfComplainant", "email", c => c.String());
            AddColumn("dbo.complaints", "dateReceive", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "dateReceive");
            DropColumn("dbo.complaint_nameOfComplainant", "email");
        }
    }
}
