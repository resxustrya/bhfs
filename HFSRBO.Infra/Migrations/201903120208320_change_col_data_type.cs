namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_col_data_type : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.complaints", "communication_form", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "communication_form", c => c.String());
        }
    }
}
