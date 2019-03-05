namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remove_col : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.complaints", "date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "date", c => c.DateTime());
        }
    }
}
