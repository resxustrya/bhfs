namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_col : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaints", "year", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "year");
        }
    }
}
