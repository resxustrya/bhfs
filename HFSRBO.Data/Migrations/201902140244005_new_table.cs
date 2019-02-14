namespace HFSRBO.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateEntry = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.complaints");
        }
    }
}
