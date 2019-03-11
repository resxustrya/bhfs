namespace HFSRBO.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial_Migration : DbMigration
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
            
            CreateTable(
                "dbo.complaint_dates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.String(),
                        complaintID = c.Int(nullable: false),
                        member = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.complaint_nameOfComplainant",
                c => new
                    {
                        complaintId = c.Int(nullable: false, identity: true),
                        firstname = c.String(),
                        lastname = c.String(),
                        mi = c.String(),
                        civil_status = c.String(),
                        gender = c.String(),
                        address = c.String(),
                        relationship = c.String(),
                        telNo = c.String(),
                        mobile = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.complaintId);
            
            CreateTable(
                "dbo.complaint_action_dates",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Action = c.String(),
                        complaintID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.complaint_assistance",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        assistance = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        codeNumber = c.String(),
                        hospitalID = c.Int(nullable: false),
                        date_confined = c.DateTime(),
                        other_complaint = c.String(),
                        reasonOfConfinement = c.String(),
                        assistance_needed = c.String(),
                        communication_form = c.String(),
                        pccNumber = c.String(),
                        ownership = c.String(),
                        status = c.String(),
                        staff = c.String(),
                        date_created = c.DateTime(nullable: false),
                        active = c.Boolean(nullable: false),
                        annonymos = c.Boolean(nullable: false),
                        pccCheck = c.Boolean(nullable: false),
                        year = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.type_complaint",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(),
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
                        age = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.complaintID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.complaint_patient");
            DropTable("dbo.hospitals");
            DropTable("dbo.facility_type");
            DropTable("dbo.type_complaint");
            DropTable("dbo.complaints");
            DropTable("dbo.complaint_assistance");
            DropTable("dbo.complaint_action_dates");
            DropTable("dbo.complaint_nameOfComplainant");
            DropTable("dbo.complaint_dates");
            DropTable("dbo.complaint_types_list");
        }
    }
}
