namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class review : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Review_Details");
            CreateTable(
             "dbo.Review_Details",
             c => new
             {
                 Id = c.Int(nullable: false, identity: true),
                 Reviewername = c.String(maxLength: 30),
                 ReviewerDesignationId = c.Int(nullable: false),
                 ReviewerDepartmentId = c.Int(nullable: false),
                 Revieweename = c.String(maxLength: 30),
                 RevieweeDesignationId = c.Int(nullable: false),
                 RevieweeDepartmentId = c.Int(nullable: false),
                 Date = c.DateTime(nullable: false),
                 //Department_DepartmentId = c.Int(),
                 //departments_DepartmentId = c.Int(),
                 //Designation_DesignationId = c.Int(),
                 //designations_DesignationId = c.Int(),
                 //employee_Id = c.Int(),
                 //Employee_Id = c.Int(),
             })
             .PrimaryKey(t => t.Id)
            .ForeignKey("dbo.Departments", t => t.ReviewerDepartmentId, cascadeDelete: true)
            //.ForeignKey("dbo.Departments", t => t.RevieweeDepartmentId, cascadeDelete: true)
            .ForeignKey("dbo.Designations", t => t.ReviewerDesignationId, cascadeDelete: true)
            //.ForeignKey("dbo.Designations", t => t.RevieweeDesignationId, cascadeDelete: true)
            //.ForeignKey("dbo.Employees", t => t.Reviewername, cascadeDelete: true)
            //.ForeignKey("dbo.Employees", t => t.Revieweename, cascadeDelete: true);
            .Index(t => t.ReviewerDepartmentId)
            //.Index(t => t.departments_DepartmentId)
            .Index(t => t.ReviewerDesignationId);
            //.Index(t => t.designations_DesignationId)
            //.Index(t => t.employee_Id)
           // .Index(t => t.Reviewername);



        }

        public override void Down()
        {
        }
    }
}
