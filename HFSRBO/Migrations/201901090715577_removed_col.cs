namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removed_col : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.hospital_on_complaint");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.hospital_on_complaint",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComplaintID = c.Int(nullable: false),
                        HospitalID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
