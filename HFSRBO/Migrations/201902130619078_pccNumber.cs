namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pccNumber : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.pcc_number",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        pccNumber = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.pcc_number");
        }
    }
}
