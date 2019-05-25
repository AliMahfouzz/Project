namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edi1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "Name", c => c.String());
            AddColumn("dbo.Courses", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Courses", "Department_DepartmentId");
            AddForeignKey("dbo.Courses", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Courses", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "DepartmentName", c => c.String());
            DropForeignKey("dbo.Courses", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Courses", "Department_DepartmentId");
            DropColumn("dbo.Courses", "Name");
        }
    }
}
