namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcol : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "staff", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "staff");
        }
    }
}
