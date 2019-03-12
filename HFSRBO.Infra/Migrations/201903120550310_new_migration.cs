namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.communications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        desc = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AlterColumn("dbo.complaints", "communication_form", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.complaints", "communication_form", c => c.String());
            DropTable("dbo.communications");
        }
    }
}
