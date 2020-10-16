namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropsa : DbMigration
    {
        public override void Up()
        {
            DropStoredProcedure("dbo.Review_Details_Insert");
            DropStoredProcedure("dbo.Review_Details_Update");
            DropStoredProcedure("dbo.Review_Details_Delete");
        }
        
        public override void Down()
        {
            throw new NotSupportedException("Scaffolding create or alter procedure operations is not supported in down methods.");
        }
    }
}
