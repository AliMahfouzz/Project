namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EDITtableassignee : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Assignees", "CourseId", "dbo.Courses");
            DropIndex("dbo.Assignees", new[] { "CourseId" });
            RenameColumn(table: "dbo.Assignees", name: "CourseId", newName: "Course_CourseId");
            AlterColumn("dbo.Assignees", "Course_CourseId", c => c.Int());
            CreateIndex("dbo.Assignees", "Course_CourseId");
            AddForeignKey("dbo.Assignees", "Course_CourseId", "dbo.Courses", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignees", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Assignees", new[] { "Course_CourseId" });
            AlterColumn("dbo.Assignees", "Course_CourseId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Assignees", name: "Course_CourseId", newName: "CourseId");
            CreateIndex("dbo.Assignees", "CourseId");
            AddForeignKey("dbo.Assignees", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
