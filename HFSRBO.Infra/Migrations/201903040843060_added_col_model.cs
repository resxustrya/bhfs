namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_col_model : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaint_types_list",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComplaintID = c.Int(nullable: false),
                        ComplaintTypeId = c.Int(nullable: false),
                        Member = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.complaint_types_list");
        }
    }
}
