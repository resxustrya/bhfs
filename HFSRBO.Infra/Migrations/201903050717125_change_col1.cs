namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_col1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "date", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "date", c => c.DateTime(nullable: false));
        }
    }
}
