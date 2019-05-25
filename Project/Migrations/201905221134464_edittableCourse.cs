namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableCourse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Courses", "Class_ClassId", "dbo.Classes");
            DropForeignKey("dbo.Courses", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Courses", new[] { "Class_ClassId" });
            DropIndex("dbo.Courses", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.Courses", name: "Class_ClassId", newName: "ClassId");
            RenameColumn(table: "dbo.Courses", name: "Department_DepartmentId", newName: "DepartmentId");
            AlterColumn("dbo.Courses", "ClassId", c => c.Int(nullable: false));
            AlterColumn("dbo.Courses", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Courses", "DepartmentId");
            CreateIndex("dbo.Courses", "ClassId");
            AddForeignKey("dbo.Courses", "ClassId", "dbo.Classes", "ClassId", cascadeDelete: true);
            AddForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.Courses", "Name");
            DropColumn("dbo.Courses", "ClassName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "ClassName", c => c.String());
            AddColumn("dbo.Courses", "Name", c => c.String());
            DropForeignKey("dbo.Courses", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Courses", "ClassId", "dbo.Classes");
            DropIndex("dbo.Courses", new[] { "ClassId" });
            DropIndex("dbo.Courses", new[] { "DepartmentId" });
            AlterColumn("dbo.Courses", "DepartmentId", c => c.Int());
            AlterColumn("dbo.Courses", "ClassId", c => c.Int());
            RenameColumn(table: "dbo.Courses", name: "DepartmentId", newName: "Department_DepartmentId");
            RenameColumn(table: "dbo.Courses", name: "ClassId", newName: "Class_ClassId");
            CreateIndex("dbo.Courses", "Department_DepartmentId");
            CreateIndex("dbo.Courses", "Class_ClassId");
            AddForeignKey("dbo.Courses", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
            AddForeignKey("dbo.Courses", "Class_ClassId", "dbo.Classes", "ClassId");
        }
    }
}
