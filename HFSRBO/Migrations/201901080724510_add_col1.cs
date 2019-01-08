namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_types_list", "ComplaintTypeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaint_types_list", "ComplaintTypeId");
        }
    }
}
