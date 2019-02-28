namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaint_assistance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        assistance = c.String(),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.complaint_assistance");
        }
    }
}
