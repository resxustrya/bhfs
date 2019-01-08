namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_tables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.complaint_types_list",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ComplaintID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.complaints",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        firstname = c.String(),
                        lastname = c.String(),
                        mi = c.String(),
                        age = c.Int(nullable: false),
                        civil_status = c.String(),
                        gender = c.String(),
                        date = c.String(),
                        address = c.String(),
                        name_facility_complained = c.String(),
                        facility_type = c.String(),
                        facility_address = c.String(),
                        p_firstname = c.String(),
                        p_lastname = c.String(),
                        p_mi = c.String(),
                        other_complaint = c.String(),
                        nature_of_complaint = c.String(),
                        assistance_needed = c.String(),
                        communication_form = c.String(),
                        ownership = c.String(),
                        date_informed_the_hf = c.DateTime(nullable: false),
                        date_hf_submitted_reply = c.DateTime(nullable: false),
                        date_release_to_records = c.DateTime(nullable: false),
                        date_final_resolution = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.complaints");
            DropTable("dbo.complaint_types_list");
        }
    }
}
