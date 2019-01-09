namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_col2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.hospitals", "address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.hospitals", "address");
        }
    }
}
