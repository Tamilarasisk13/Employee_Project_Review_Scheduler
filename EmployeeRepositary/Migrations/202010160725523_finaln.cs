namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class finaln : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Review_Details", name: "Departments_DepartmentId", newName: "Department_DepartmentId");
            RenameColumn(table: "dbo.Review_Details", name: "Designations_DesignationId", newName: "Designation_DesignationId");
            RenameIndex(table: "dbo.Review_Details", name: "IX_Departments_DepartmentId", newName: "IX_Department_DepartmentId");
            RenameIndex(table: "dbo.Review_Details", name: "IX_Designations_DesignationId", newName: "IX_Designation_DesignationId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Review_Details", name: "IX_Designation_DesignationId", newName: "IX_Designations_DesignationId");
            RenameIndex(table: "dbo.Review_Details", name: "IX_Department_DepartmentId", newName: "IX_Departments_DepartmentId");
            RenameColumn(table: "dbo.Review_Details", name: "Designation_DesignationId", newName: "Designations_DesignationId");
            RenameColumn(table: "dbo.Review_Details", name: "Department_DepartmentId", newName: "Departments_DepartmentId");
        }
    }
}
