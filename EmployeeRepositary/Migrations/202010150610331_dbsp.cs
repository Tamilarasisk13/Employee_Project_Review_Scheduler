namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbsp : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.ReviewDetails", "Department_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.ReviewDetails", "departments_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.ReviewDetails", "Designation_DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.ReviewDetails", "designations_DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.ReviewDetails", "employee_Id", "dbo.Employees");
            //DropForeignKey("dbo.ReviewDetails", "Employee_Id", "dbo.Employees");
            //DropIndex("dbo.ReviewDetails", new[] { "Department_DepartmentId" });
            //DropIndex("dbo.ReviewDetails", new[] { "departments_DepartmentId" });
            //DropIndex("dbo.ReviewDetails", new[] { "Designation_DesignationId" });
            //DropIndex("dbo.ReviewDetails", new[] { "designations_DesignationId" });
            //DropIndex("dbo.ReviewDetails", new[] { "employee_Id" });
            //DropIndex("dbo.ReviewDetails", new[] { "Employee_Id" });
            DropTable("dbo.ReviewDetails");
            CreateStoredProcedure(
                "dbo.Review_Details_Insert",
                p => new
                    {
                        Reviewername = p.String(maxLength: 30),
                        ReviewerDesignationId = p.Int(),
                        ReviewerDepartmentId = p.Int(),
                        Revieweename = p.String(maxLength: 30),
                        RevieweeDesignationId = p.Int(),
                        RevieweeDepartmentId = p.Int(),
                        Date = p.DateTime(),
                        //Departments_DepartmentId = p.Int(),
                        //Designations_DesignationId = p.Int(),
                        //Employee_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Review_Details]([Reviewername], [ReviewerDesignationId], [ReviewerDepartmentId], [Revieweename], [RevieweeDesignationId], [RevieweeDepartmentId], [Date])
                      VALUES (@Reviewername, @ReviewerDesignationId, @ReviewerDepartmentId, @Revieweename, @RevieweeDesignationId, @RevieweeDepartmentId, @Date)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Review_Details]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Review_Details] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.Review_Details_Update",
                p => new
                    {
                        Id = p.Int(),
                        Reviewername = p.String(maxLength: 30),
                        ReviewerDesignationId = p.Int(),
                        ReviewerDepartmentId = p.Int(),
                        Revieweename = p.String(maxLength: 30),
                        RevieweeDesignationId = p.Int(),
                        RevieweeDepartmentId = p.Int(),
                        Date = p.DateTime(),
                        //Departments_DepartmentId = p.Int(),
                        //Designations_DesignationId = p.Int(),
                        //Employee_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Review_Details]
                      SET [Reviewername] = @Reviewername, [ReviewerDesignationId] = @ReviewerDesignationId, [ReviewerDepartmentId] = @ReviewerDepartmentId, [Revieweename] = @Revieweename, [RevieweeDesignationId] = @RevieweeDesignationId, [RevieweeDepartmentId] = @RevieweeDepartmentId, [Date] = @Date
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.Review_Details_Delete",
                p => new
                    {
                        Id = p.Int(),
                      
                    },
                body:
                    @"DELETE [dbo].[Review_Details]
                      WHERE ([Id] = @Id)"
//AND (([Departments_DepartmentId] = @Departments_DepartmentId) OR ([Departments_DepartmentId] IS NULL AND @Departments_DepartmentId IS NULL))) AND (([Designations_DesignationId] = @Designations_DesignationId) OR ([Designations_DesignationId] IS NULL AND @Designations_DesignationId IS NULL))) AND (([Employee_Id] = @Employee_Id) OR ([Employee_Id] IS NULL AND @Employee_Id IS NULL)))"
            );
            
            DropStoredProcedure("dbo.ReviewDetails_Insert");
            DropStoredProcedure("dbo.ReviewDetails_Update");
            DropStoredProcedure("dbo.ReviewDetails_Delete");
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.Review_Details_Delete");
            DropStoredProcedure("dbo.Review_Details_Update");
            DropStoredProcedure("dbo.Review_Details_Insert");
            CreateTable(
                "dbo.ReviewDetails",
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
                .PrimaryKey(t => t.Id);
            
            //CreateIndex("dbo.ReviewDetails", "Employee_Id");
            //CreateIndex("dbo.ReviewDetails", "employee_Id");
            //CreateIndex("dbo.ReviewDetails", "designations_DesignationId");
            //CreateIndex("dbo.ReviewDetails", "Designation_DesignationId");
            //CreateIndex("dbo.ReviewDetails", "departments_DepartmentId");
            //CreateIndex("dbo.ReviewDetails", "Department_DepartmentId");
            //AddForeignKey("dbo.ReviewDetails", "Employee_Id", "dbo.Employees", "Id");
            //AddForeignKey("dbo.ReviewDetails", "employee_Id", "dbo.Employees", "Id");
            //AddForeignKey("dbo.ReviewDetails", "designations_DesignationId", "dbo.Designations", "DesignationId");
            //AddForeignKey("dbo.ReviewDetails", "Designation_DesignationId", "dbo.Designations", "DesignationId");
            //AddForeignKey("dbo.ReviewDetails", "departments_DepartmentId", "dbo.Departments", "DepartmentId");
            //AddForeignKey("dbo.ReviewDetails", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
