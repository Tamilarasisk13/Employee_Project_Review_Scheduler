namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AccountDetails",
                c => new
                    {
                        AccountId = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 15),
                        Role = c.String(),
                    })
                .PrimaryKey(t => t.AccountId)
                .Index(t => t.Username, unique: true)
                .Index(t => t.Password, unique: true);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(nullable: false, maxLength: 30),
                        Lastname = c.String(nullable: false, maxLength: 30),
                        EmailId = c.String(nullable: false, maxLength: 60),
                        Gender = c.String(nullable: false, maxLength: 6),
                        Mobilenumber = c.Long(nullable: false),
                        DOB = c.DateTime(nullable: false),
                        DOJ = c.DateTime(nullable: false),
                        DesignationId = c.Int(nullable: false),
                        DepartmentId = c.Int(nullable: false),
                        AccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AccountDetails", t => t.AccountId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.EmailId, unique: true)
                .Index(t => t.Mobilenumber, unique: true)
                .Index(t => t.DesignationId)
                .Index(t => t.DepartmentId)
                .Index(t => t.AccountId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        DesignationId = c.Int(nullable: false, identity: true),
                        DesignationName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.DesignationId);
            
            CreateStoredProcedure(
                "dbo.InsertEmployee",
                p => new
                    {
                        Firstname = p.String(maxLength: 30),
                        Lastname = p.String(maxLength: 30),
                        EmailId = p.String(maxLength: 60),
                        Gender = p.String(maxLength: 6),
                        Mobilenumber = p.Long(),
                        DOB = p.DateTime(),
                        DOJ = p.DateTime(),
                        DesignationId = p.Int(),
                        DepartmentId = p.Int(),
                        AccountId = p.Int(),
                    },
                body:
                    @"INSERT [dbo].[Employees]([Firstname], [Lastname], [EmailId], [Gender], [Mobilenumber], [DOB], [DOJ], [DesignationId], [DepartmentId], [AccountId])
                      VALUES (@Firstname, @Lastname, @EmailId, @Gender, @Mobilenumber, @DOB, @DOJ, @DesignationId, @DepartmentId, @AccountId)
                      
                      DECLARE @Id int
                      SELECT @Id = [Id]
                      FROM [dbo].[Employees]
                      WHERE @@ROWCOUNT > 0 AND [Id] = scope_identity()
                      
                      SELECT t0.[Id]
                      FROM [dbo].[Employees] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[Id] = @Id"
            );
            
            CreateStoredProcedure(
                "dbo.UpdateEmployee",
                p => new
                    {
                        Id = p.Int(),
                        Firstname = p.String(maxLength: 30),
                        Lastname = p.String(maxLength: 30),
                        EmailId = p.String(maxLength: 60),
                        Gender = p.String(maxLength: 6),
                        Mobilenumber = p.Long(),
                        DOB = p.DateTime(),
                        DOJ = p.DateTime(),
                        DesignationId = p.Int(),
                        DepartmentId = p.Int(),
                        AccountId = p.Int(),
                    },
                body:
                    @"UPDATE [dbo].[Employees]
                      SET [Firstname] = @Firstname, [Lastname] = @Lastname, [EmailId] = @EmailId, [Gender] = @Gender, [Mobilenumber] = @Mobilenumber, [DOB] = @DOB, [DOJ] = @DOJ, [DesignationId] = @DesignationId, [DepartmentId] = @DepartmentId, [AccountId] = @AccountId
                      WHERE ([Id] = @Id)"
            );
            
            CreateStoredProcedure(
                "dbo.DeleteEmployee",
                p => new
                    {
                        Id = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[Employees]
                      WHERE ([Id] = @Id)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.DeleteEmployee");
            DropStoredProcedure("dbo.UpdateEmployee");
            DropStoredProcedure("dbo.InsertEmployee");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropForeignKey("dbo.Employees", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Employees", "AccountId", "dbo.AccountDetails");
            DropIndex("dbo.Employees", new[] { "AccountId" });
            DropIndex("dbo.Employees", new[] { "DepartmentId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.Employees", new[] { "Mobilenumber" });
            DropIndex("dbo.Employees", new[] { "EmailId" });
            DropIndex("dbo.AccountDetails", new[] { "Password" });
            DropIndex("dbo.AccountDetails", new[] { "Username" });
            DropTable("dbo.Designations");
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
            DropTable("dbo.AccountDetails");
        }
    }
}
