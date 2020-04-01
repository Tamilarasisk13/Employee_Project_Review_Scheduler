namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spall : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.Departments_Insert",
                p => new
                    {
                        DepartmentName = p.String(maxLength: 30),
                    },
                body:
                    @"INSERT [dbo].[Departments]([DepartmentName])
                      VALUES (@DepartmentName)
                      
                      DECLARE @DepartmentId int
                      SELECT @DepartmentId = [DepartmentId]
                      FROM [dbo].[Departments]
                      WHERE @@ROWCOUNT > 0 AND [DepartmentId] = scope_identity()
                      
                      SELECT t0.[DepartmentId]
                      FROM [dbo].[Departments] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DepartmentId] = @DepartmentId"
            );
            
            CreateStoredProcedure(
                "dbo.Departments_Update",
                p => new
                    {
                        DepartmentId = p.Int(),
                        DepartmentName = p.String(maxLength: 30),
                    },
                body:
                    @"UPDATE [dbo].[Departments]
                      SET [DepartmentName] = @DepartmentName
                      WHERE ([DepartmentId] = @DepartmentId)"
            );
            
            CreateStoredProcedure(
                "dbo.Departments_Delete",
                p => new
                    {
                        DepartmentId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Departments]
                      WHERE ([DepartmentId] = @DepartmentId)"
            );
            
            CreateStoredProcedure(
                "dbo.Designations_Insert",
                p => new
                    {
                        DesignationName = p.String(maxLength: 30),
                    },
                body:
                    @"INSERT [dbo].[Designations]([DesignationName])
                      VALUES (@DesignationName)
                      
                      DECLARE @DesignationId int
                      SELECT @DesignationId = [DesignationId]
                      FROM [dbo].[Designations]
                      WHERE @@ROWCOUNT > 0 AND [DesignationId] = scope_identity()
                      
                      SELECT t0.[DesignationId]
                      FROM [dbo].[Designations] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[DesignationId] = @DesignationId"
            );
            
            CreateStoredProcedure(
                "dbo.Designations_Update",
                p => new
                    {
                        DesignationId = p.Int(),
                        DesignationName = p.String(maxLength: 30),
                    },
                body:
                    @"UPDATE [dbo].[Designations]
                      SET [DesignationName] = @DesignationName
                      WHERE ([DesignationId] = @DesignationId)"
            );
            
            CreateStoredProcedure(
                "dbo.Designations_Delete",
                p => new
                    {
                        DesignationId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Designations]
                      WHERE ([DesignationId] = @DesignationId)"
            );
            
            RenameStoredProcedure(name: "dbo.InsertEmployee", newName: "Employee_Insert");
            RenameStoredProcedure(name: "dbo.UpdateEmployee", newName: "Employee_Update");
            RenameStoredProcedure(name: "dbo.DeleteEmployee", newName: "Employee_Delete");
        }
        
        public override void Down()
        {
            RenameStoredProcedure(name: "dbo.Employee_Delete", newName: "DeleteEmployee");
            RenameStoredProcedure(name: "dbo.Employee_Update", newName: "UpdateEmployee");
            RenameStoredProcedure(name: "dbo.Employee_Insert", newName: "InsertEmployee");
            DropStoredProcedure("dbo.Designations_Delete");
            DropStoredProcedure("dbo.Designations_Update");
            DropStoredProcedure("dbo.Designations_Insert");
            DropStoredProcedure("dbo.Departments_Delete");
            DropStoredProcedure("dbo.Departments_Update");
            DropStoredProcedure("dbo.Departments_Insert");
        }
    }
}
