namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_nameOfComplainant", "Date", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaint_nameOfComplainant", "Date");
        }
    }
}
