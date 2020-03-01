namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        EmailId = c.String(),
                        Gender = c.String(),
                        Mobilenumber = c.Long(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        DOJ = c.DateTime(nullable: false),
                        Username = c.String(),
                        Password = c.String(),
                        ConformPassword = c.String(),
                        Designation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
