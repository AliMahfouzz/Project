namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableteacher : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Teachers", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Teachers", "DepartmentId");
            AddForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.Teachers", "Department");
            DropColumn("dbo.Teachers", "CourseClass");
            DropColumn("dbo.Teachers", "CourseTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "CourseTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Teachers", "CourseClass", c => c.String());
            AddColumn("dbo.Teachers", "Department", c => c.String());
            DropForeignKey("dbo.Teachers", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Teachers", new[] { "DepartmentId" });
            DropColumn("dbo.Teachers", "DepartmentId");
        }
    }
}
