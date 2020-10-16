namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gsdgdfgdf : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Review_Details", "Department_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.Review_Details", "Designation_DesignationId", "dbo.Designations");
            //DropIndex("dbo.Review_Details", new[] { "Department_DepartmentId" });
            //DropIndex("dbo.Review_Details", new[] { "departments_DepartmentId" });
            //DropIndex("dbo.Review_Details", new[] { "Designation_DesignationId" });
            //DropIndex("dbo.Review_Details", new[] { "designations_DesignationId" });
            DropIndex("dbo.Review_Details", new[] { "employee_Id" });
            //CreateIndex("dbo.Review_Details", "Departments_DepartmentId");
            //CreateIndex("dbo.Review_Details", "Designations_DesignationId");
            //DropColumn("dbo.Review_Details", "Department_DepartmentId");
            //DropColumn("dbo.Review_Details", "Designation_DesignationId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Review_Details", "Designation_DesignationId", c => c.Int());
            AddColumn("dbo.Review_Details", "Department_DepartmentId", c => c.Int());
        //    DropIndex("dbo.Review_Details", new[] { "Designations_DesignationId" });
          //  DropIndex("dbo.Review_Details", new[] { "Departments_DepartmentId" });
            CreateIndex("dbo.Review_Details", "employee_Id");
            CreateIndex("dbo.Review_Details", "designations_DesignationId");
            CreateIndex("dbo.Review_Details", "Designation_DesignationId");
            CreateIndex("dbo.Review_Details", "departments_DepartmentId");
            CreateIndex("dbo.Review_Details", "Department_DepartmentId");
            AddForeignKey("dbo.Review_Details", "Designation_DesignationId", "dbo.Designations", "DesignationId");
            AddForeignKey("dbo.Review_Details", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
