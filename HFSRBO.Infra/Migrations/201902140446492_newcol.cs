namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newcol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaint_nameOfComplainant",
                c => new
                    {
                        complaintId = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        mi = c.String(),
                        age = c.Int(nullable: false),
                        civil_status = c.String(),
                        gender = c.String(),
                        address = c.String(),
                    })
                .PrimaryKey(t => t.complaintId);
            
            CreateTable(
                "dbo.complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        date = c.DateTime(),
                        hospitalID = c.Int(nullable: false),
                        date_confined = c.DateTime(),
                        other_complaint = c.String(),
                        assistance_needed = c.String(),
                        communication_form = c.String(),
                        ownership = c.String(),
                        date_informed_the_hf = c.DateTime(),
                        date_hf_submitted_reply = c.DateTime(),
                        date_release_to_records = c.DateTime(),
                        date_final_resolution = c.DateTime(),
                        status = c.String(),
                        staff = c.String(),
                        date_created = c.DateTime(nullable: false),
                        active = c.Boolean(nullable: false),
                        annonymos = c.Boolean(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.facility_type",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.hospitals",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        facilityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.complaint_patient",
                c => new
                    {
                        complaintID = c.Int(nullable: false, identity: true),
                        p_firstname = c.String(),
                        p_lastname = c.String(),
                        p_mi = c.String(),
                    })
                .PrimaryKey(t => t.complaintID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.complaint_patient");
            DropTable("dbo.hospitals");
            DropTable("dbo.facility_type");
            DropTable("dbo.complaints");
            DropTable("dbo.complaint_nameOfComplainant");
        }
    }
}
