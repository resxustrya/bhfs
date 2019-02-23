namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_cols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_patient", "age", c => c.Int(nullable: false));
            DropColumn("dbo.complaint_nameOfComplainant", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaint_nameOfComplainant", "age", c => c.Int(nullable: false));
            DropColumn("dbo.complaint_patient", "age");
        }
    }
}
