namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.actions_takened",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        actions = c.String(),
                        ComplaintID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
        }
        
        public override void Down()
        {
            DropTable("dbo.actions_takened");
        }
    }
}
