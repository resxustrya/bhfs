namespace HFSRBO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class new_table2 : DbMigration
    {
        public override void Up()
        {
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
            
            AddColumn("dbo.complaints", "annonymos", c => c.Boolean(nullable: false));
            AddColumn("dbo.pcc_number", "complaintID", c => c.Int(nullable: false));
            DropColumn("dbo.complaints", "firstname");
            DropColumn("dbo.complaints", "lastname");
            DropColumn("dbo.complaints", "mi");
            DropColumn("dbo.complaints", "age");
            DropColumn("dbo.complaints", "civil_status");
            DropColumn("dbo.complaints", "gender");
            DropColumn("dbo.complaints", "address");
            DropColumn("dbo.complaints", "facility_address");
            DropColumn("dbo.complaints", "p_firstname");
            DropColumn("dbo.complaints", "p_lastname");
            DropColumn("dbo.complaints", "p_mi");
        }
        
        public override void Down()
        {
            AddColumn("dbo.complaints", "p_mi", c => c.String());
            AddColumn("dbo.complaints", "p_lastname", c => c.String());
            AddColumn("dbo.complaints", "p_firstname", c => c.String());
            AddColumn("dbo.complaints", "facility_address", c => c.String());
            AddColumn("dbo.complaints", "address", c => c.String());
            AddColumn("dbo.complaints", "gender", c => c.String());
            AddColumn("dbo.complaints", "civil_status", c => c.String());
            AddColumn("dbo.complaints", "age", c => c.Int(nullable: false));
            AddColumn("dbo.complaints", "mi", c => c.String());
            AddColumn("dbo.complaints", "lastname", c => c.String());
            AddColumn("dbo.complaints", "firstname", c => c.String());
            DropColumn("dbo.pcc_number", "complaintID");
            DropColumn("dbo.complaints", "annonymos");
            DropTable("dbo.complaint_nameOfComplainant");
            DropTable("dbo.complaint_patient");
        }
    }
}
