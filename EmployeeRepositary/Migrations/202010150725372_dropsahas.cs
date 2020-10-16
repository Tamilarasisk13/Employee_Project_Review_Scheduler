namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dropsahas : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Review_Details");

            CreateTable(
              "dbo.Review_Details",
              c => new
              {
                  Id = c.Int(nullable: false, identity: true),
                  Reviewername = c.String(nullable: false, maxLength: 30),
                  ReviewerDesignationId = c.Int(nullable: false),
                  ReviewerDepartmentId = c.Int(nullable: false),
                  Revieweename = c.String(nullable: false, maxLength: 30),
                  RevieweeDesignationId = c.Int(nullable: false),
                  RevieweeDepartmentId = c.Int(nullable: false),
                  Date = c.DateTime(nullable: false),
              })
              .PrimaryKey(t => t.Id)
            ;

        }

        public override void Down()
        {
        }
    }
}
