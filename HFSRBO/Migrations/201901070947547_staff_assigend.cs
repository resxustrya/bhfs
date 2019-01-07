namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class staff_assigend : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.staff_assigend",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.staff_assigend");
        }
    }
}
