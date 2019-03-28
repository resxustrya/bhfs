namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.remarks", "complaintID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.remarks", "complaintID");
        }
    }
}
