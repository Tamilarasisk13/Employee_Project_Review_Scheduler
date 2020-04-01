namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class log : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExceptionLoggers",
                c => new
                    {
                        ExceptionId = c.Int(nullable: false, identity: true),
                        ExceptionMessage = c.String(),
                        ExceptionStackTrack = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        ExceptionLogTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ExceptionId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ExceptionLoggers");
        }
    }
}
