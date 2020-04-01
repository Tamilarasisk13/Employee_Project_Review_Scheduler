namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class spallh : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
                "dbo.AccountDetails_Insert",
                p => new
                    {
                        Username = p.String(maxLength: 30),
                        Password = p.String(maxLength: 15),
                        Role = p.String(),
                    },
                body:
                    @"INSERT [dbo].[AccountDetails]([Username], [Password], [Role])
                      VALUES (@Username, @Password, @Role)
                      
                      DECLARE @AccountId int
                      SELECT @AccountId = [AccountId]
                      FROM [dbo].[AccountDetails]
                      WHERE @@ROWCOUNT > 0 AND [AccountId] = scope_identity()
                      
                      SELECT t0.[AccountId]
                      FROM [dbo].[AccountDetails] AS t0
                      WHERE @@ROWCOUNT > 0 AND t0.[AccountId] = @AccountId"
            );
            
            CreateStoredProcedure(
                "dbo.AccountDetails_Update",
                p => new
                    {
                        AccountId = p.Int(),
                        Username = p.String(maxLength: 30),
                        Password = p.String(maxLength: 15),
                        Role = p.String(),
                    },
                body:
                    @"UPDATE [dbo].[AccountDetails]
                      SET [Username] = @Username, [Password] = @Password, [Role] = @Role
                      WHERE ([AccountId] = @AccountId)"
            );
            
            CreateStoredProcedure(
                "dbo.AccountDetails_Delete",
                p => new
                    {
                        AccountId = p.Int(),
                    },
                body:
                    @"DELETE [dbo].[AccountDetails]
                      WHERE ([AccountId] = @AccountId)"
            );
            
        }
        
        public override void Down()
        {
            DropStoredProcedure("dbo.AccountDetails_Delete");
            DropStoredProcedure("dbo.AccountDetails_Update");
            DropStoredProcedure("dbo.AccountDetails_Insert");
        }
    }
}
