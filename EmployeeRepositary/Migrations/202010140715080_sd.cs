namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {

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
                .PrimaryKey(t => t.Id);
                //.ForeignKey("dbo.Departments", t => t.ReviewerDepartmentId, cascadeDelete: true)
                //.ForeignKey("dbo.Departments", t => t.RevieweeDepartmentId, cascadeDelete: true)
                //.ForeignKey("dbo.Designations", t => t.ReviewerDesignationId, cascadeDelete: true)
                //.ForeignKey("dbo.Designations", t => t.RevieweeDesignationId, cascadeDelete: true)
                //.ForeignKey("dbo.Employees", t => t.Reviewername, cascadeDelete: true)
                //.ForeignKey("dbo.Employees", t => t.Revieweename, cascadeDelete: true);
                //.Index(t => t.Department_DepartmentId)
                //.Index(t => t.departments_DepartmentId)
                //.Index(t => t.Designation_DesignationId)
                //.Index(t => t.designations_DesignationId)
                //.Index(t => t.employee_Id)
                //.Index(t => t.Employee_Id);



            CreateStoredProcedure(
                "dbo.ReviewDetails_Insert",
                p => new
                    {
                        Reviewername = p.String(maxLength: 30),
                        ReviewerDesignationId = p.Int(),
                        ReviewerDepartmentId = p.Int(),
                        Revieweename = p.String(maxLength: 30),
                        RevieweeDesignationId = p.Int(),
                        RevieweeDepartmentId = p.Int(),
                        Date = p.DateTime(),
                        //Department_DepartmentId = p.Int(),
                        //departments_DepartmentId = p.Int(),
                        //Designation_DesignationId = p.Int(),
                        //designations_DesignationId = p.Int(),
                        //employee_Id = p.Int(),
                        //Employee_Id = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[ReviewDetails]([Reviewername], [ReviewerDesignationId], [ReviewerDepartmentId], [Revieweename], [RevieweeDesignationId], [RevieweeDepartmentId], [Date])
                      VALUES (@Reviewername, @ReviewerDesignationId, @ReviewerDepartmentId, @Revieweename, @RevieweeDesignationId, @RevieweeDepartmentId, @Date)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[ReviewDetails]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[ReviewDetails] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.ReviewDetails_Update",
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
                        //Department_DepartmentId = p.Int(),
                        //departments_DepartmentId = p.Int(),
                        //Designation_DesignationId = p.Int(),
                        //designations_DesignationId = p.Int(),
                        //employee_Id = p.Int(),
                        //Employee_Id = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[ReviewDetails]
                      SET [Reviewername] = @Reviewername, [ReviewerDesignationId] = @ReviewerDesignationId, [ReviewerDepartmentId] = @ReviewerDepartmentId, [Revieweename] = @Revieweename, [RevieweeDesignationId] = @RevieweeDesignationId, [RevieweeDepartmentId] = @RevieweeDepartmentId, [Date] = @Date
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.ReviewDetails_Delete",
                p => new
                    {
                        Id = p.Int(),
                        //Department_DepartmentId = p.Int(),
                        //departments_DepartmentId = p.Int(),
                        //Designation_DesignationId = p.Int(),
                        //designations_DesignationId = p.Int(),
                        //employee_Id = p.Int(),
                        //Employee_Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[ReviewDetails]
                      WHERE [Id] = @Id)"
//AND (([Department_DepartmentId] = @Department_DepartmentId) OR ([Department_DepartmentId] IS NULL AND @Department_DepartmentId IS NULL))) AND (([departments_DepartmentId] = @departments_DepartmentId) OR ([departments_DepartmentId] IS NULL AND @departments_DepartmentId IS NULL))) AND (([Designation_DesignationId] = @Designation_DesignationId) OR ([Designation_DesignationId] IS NULL AND @Designation_DesignationId IS NULL))) AND (([designations_DesignationId] = @designations_DesignationId) OR ([designations_DesignationId] IS NULL AND @designations_DesignationId IS NULL))) AND (([employee_Id] = @employee_Id) OR ([employee_Id] IS NULL AND @employee_Id IS NULL))) AND (([Employee_Id] = @Employee_Id) OR ([Employee_Id] IS NULL AND @Employee_Id IS NULL)))"
            );
            
        }
        
        public override void Down()
        {
            //DropStoredProcedure("dbo.ReviewDetails_Delete");
            //DropStoredProcedure("dbo.ReviewDetails_Update");
            //DropStoredProcedure("dbo.ReviewDetails_Insert");
            //DropStoredProcedure("dbo.Designations_Delete");
            //DropStoredProcedure("dbo.Designations_Update");
            //DropStoredProcedure("dbo.Designations_Insert");
            //DropStoredProcedure("dbo.Employee_Delete");
            //DropStoredProcedure("dbo.Employee_Update");
            //DropStoredProcedure("dbo.Employee_Insert");
            //DropStoredProcedure("dbo.Departments_Delete");
            //DropStoredProcedure("dbo.Departments_Update");
            //DropStoredProcedure("dbo.Departments_Insert");
            //DropStoredProcedure("dbo.AccountDetails_Delete");
            //DropStoredProcedure("dbo.AccountDetails_Update");
            //DropStoredProcedure("dbo.AccountDetails_Insert");
            //DropForeignKey("dbo.ReviewDetails", "Employee_Id", "dbo.Employees");
            //DropForeignKey("dbo.ReviewDetails", "employee_Id", "dbo.Employees");
            //DropForeignKey("dbo.ReviewDetails", "designations_DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.ReviewDetails", "Designation_DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.ReviewDetails", "departments_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.ReviewDetails", "Department_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.Review_Details", "Employee_Id", "dbo.Employees");
            //DropForeignKey("dbo.Review_Details", "employee_Id", "dbo.Employees");
            //DropForeignKey("dbo.Review_Details", "designations_DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.Review_Details", "Designation_DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.Review_Details", "departments_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.Review_Details", "Department_DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            //DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            //DropForeignKey("dbo.Employees", "AccountId", "dbo.AccountDetails");
            //DropIndex("dbo.ReviewDetails", new[] { "Employee_Id" });
            //DropIndex("dbo.ReviewDetails", new[] { "employee_Id" });
            //DropIndex("dbo.ReviewDetails", new[] { "designations_DesignationId" });
            //DropIndex("dbo.ReviewDetails", new[] { "Designation_DesignationId" });
            //DropIndex("dbo.ReviewDetails", new[] { "departments_DepartmentId" });
            //DropIndex("dbo.ReviewDetails", new[] { "Department_DepartmentId" });
            //DropIndex("dbo.Review_Details", new[] { "Employee_Id" });
            //DropIndex("dbo.Review_Details", new[] { "employee_Id" });
            //DropIndex("dbo.Review_Details", new[] { "designations_DesignationId" });
            //DropIndex("dbo.Review_Details", new[] { "Designation_DesignationId" });
            //DropIndex("dbo.Review_Details", new[] { "departments_DepartmentId" });
            //DropIndex("dbo.Review_Details", new[] { "Department_DepartmentId" });
            //DropIndex("dbo.Employees", new[] { "AccountId" });
            //DropIndex("dbo.Employees", new[] { "DepartmentId" });
            //DropIndex("dbo.Employees", new[] { "DesignationId" });
            //DropIndex("dbo.Employees", new[] { "Mobilenumber" });
            //DropIndex("dbo.Employees", new[] { "EmailId" });
            //DropIndex("dbo.AccountDetails", new[] { "Password" });
            //DropIndex("dbo.AccountDetails", new[] { "Username" });
            //DropTable("dbo.ReviewDetails");
            //DropTable("dbo.Review_Details");
            //DropTable("dbo.ExceptionLoggers");
            //DropTable("dbo.Designations");
            //DropTable("dbo.Employees");
            //DropTable("dbo.Departments");
            //DropTable("dbo.AccountDetails");
        }
    }
}
