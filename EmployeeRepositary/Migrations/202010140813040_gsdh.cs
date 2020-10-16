namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gsdh : DbMigration
    {
        public override void Up()
        {
        }
        
        public override void Down()
        {
            DropTable("dbo.Review_Details");
        }
    }
}
