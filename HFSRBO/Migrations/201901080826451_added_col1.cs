namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "Region", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "Region");
        }
    }
}
