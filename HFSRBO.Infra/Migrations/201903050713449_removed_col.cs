namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_col : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "date", c => c.DateTime(nullable: false));
            DropColumn("dbo.complaints", "date_informed_the_hf");
            DropColumn("dbo.complaints", "date_hf_submitted_reply");
            DropColumn("dbo.complaints", "date_release_to_records");
            DropColumn("dbo.complaints", "date_final_resolution");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "date_final_resolution", c => c.DateTime());
            AddColumn("dbo.complaints", "date_release_to_records", c => c.DateTime());
            AddColumn("dbo.complaints", "date_hf_submitted_reply", c => c.DateTime());
            AddColumn("dbo.complaints", "date_informed_the_hf", c => c.DateTime());
            AlterColumn("dbo.complaints", "date", c => c.DateTime());
        }
    }
}
