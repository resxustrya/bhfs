namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "pccCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "pccCheck");
        }
    }
}
