namespace EmployeeRepositary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop : DbMigration
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
              //.ForeignKey("dbo.Employees", t => t.Reviewername, cascadeDelete: true)
              .ForeignKey("dbo.Departments", t => t.ReviewerDepartmentId, cascadeDelete: true)
              .ForeignKey("dbo.Designations", t => t.ReviewerDesignationId, cascadeDelete: true)
             // .Index(t => t.Reviewername)
              .Index(t => t.ReviewerDepartmentId)
              .Index(t => t.ReviewerDesignationId);

        }

        public override void Down()
        {
        }
    }
}
