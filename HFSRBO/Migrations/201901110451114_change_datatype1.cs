namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_datatype1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "date", c => c.String());
            AlterColumn("dbo.complaints", "date_confined", c => c.String());
            AlterColumn("dbo.complaints", "date_informed_the_hf", c => c.String());
            AlterColumn("dbo.complaints", "date_hf_submitted_reply", c => c.String());
            AlterColumn("dbo.complaints", "date_release_to_records", c => c.String());
            AlterColumn("dbo.complaints", "date_final_resolution", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "date_final_resolution", c => c.DateTime());
            AlterColumn("dbo.complaints", "date_release_to_records", c => c.DateTime());
            AlterColumn("dbo.complaints", "date_hf_submitted_reply", c => c.DateTime());
            AlterColumn("dbo.complaints", "date_informed_the_hf", c => c.DateTime());
            AlterColumn("dbo.complaints", "date_confined", c => c.DateTime());
            AlterColumn("dbo.complaints", "date", c => c.DateTime());
        }
    }
}
