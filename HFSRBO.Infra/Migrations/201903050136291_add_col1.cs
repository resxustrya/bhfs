namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "codeNumber", c => c.String());
            DropColumn("dbo.complaints", "Code");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "Code", c => c.String());
            DropColumn("dbo.complaints", "codeNumber");
        }
    }
}
