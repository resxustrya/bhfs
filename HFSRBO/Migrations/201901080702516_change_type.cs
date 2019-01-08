namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "date_confined", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "date_confined", c => c.String());
        }
    }
}
