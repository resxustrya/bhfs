namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.remarks",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        remark = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.remarks");
        }
    }
}
