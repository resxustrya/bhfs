namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class added_models : DbMigration
    {
        public override void Up()
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
            
            CreateTable(
                "dbo.hospitals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.hospitals");
            DropTable("dbo.hospital_on_complaint");
        }
    }
}
