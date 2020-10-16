namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class final : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Review_Details", "Departments_DepartmentId", c => c.Int());
            AddColumn("dbo.Review_Details", "Designations_DesignationId", c => c.Int());
            AddColumn("dbo.Review_Details", "Employee_Id", c => c.Int());
            CreateIndex("dbo.Review_Details", "Departments_DepartmentId");
            CreateIndex("dbo.Review_Details", "Designations_DesignationId");
            CreateIndex("dbo.Review_Details", "Employee_Id");
            AddForeignKey("dbo.Review_Details", "Departments_DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Review_Details", "Designations_DesignationId", "dbo.Designations", "DesignationId");
            AddForeignKey("dbo.Review_Details", "Employee_Id", "dbo.Employees", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Review_Details", "Employee_Id", "dbo.Employees");
            DropForeignKey("dbo.Review_Details", "Designations_DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Review_Details", "Departments_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Review_Details", new[] { "Employee_Id" });
            DropIndex("dbo.Review_Details", new[] { "Designations_DesignationId" });
            DropIndex("dbo.Review_Details", new[] { "Departments_DepartmentId" });
            DropColumn("dbo.Review_Details", "Employee_Id");
            DropColumn("dbo.Review_Details", "Designations_DesignationId");
            DropColumn("dbo.Review_Details", "Departments_DepartmentId");
        }
    }
}
