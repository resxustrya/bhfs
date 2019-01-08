namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "date_confined", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "date_confined");
        }
    }
}
