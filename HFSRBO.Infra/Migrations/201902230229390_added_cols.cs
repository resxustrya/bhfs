namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_cols : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.complaint_nameOfComplainant", "relationship", c => c.String());
            AddColumn("dbo.complaint_nameOfComplainant", "telNo", c => c.String());
            AddColumn("dbo.complaint_nameOfComplainant", "mobile", c => c.String());
            AddColumn("dbo.complaints", "reasonOfConfinement", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.complaints", "reasonOfConfinement");
            DropColumn("dbo.complaint_nameOfComplainant", "mobile");
            DropColumn("dbo.complaint_nameOfComplainant", "telNo");
            DropColumn("dbo.complaint_nameOfComplainant", "relationship");
        }
    }
}
