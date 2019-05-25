namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittablestudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Name", c => c.String());
            AddColumn("dbo.Students", "Department_DepartmentId", c => c.Int());
            CreateIndex("dbo.Students", "Department_DepartmentId");
            AddForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            DropColumn("dbo.Students", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Department", c => c.String());
            DropForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_DepartmentId" });
            DropColumn("dbo.Students", "Department_DepartmentId");
            DropColumn("dbo.Students", "Name");
        }
    }
}
