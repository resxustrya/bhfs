namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_datatype3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "year", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "year", c => c.String());
        }
    }
}
