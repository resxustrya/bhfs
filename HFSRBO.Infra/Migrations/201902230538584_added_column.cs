namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_column : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "pccNumber", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "pccNumber");
        }
    }
}
