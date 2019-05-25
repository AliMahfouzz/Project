namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EDITtableEnrollment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            RenameColumn(table: "dbo.Enrollments", name: "CourseId", newName: "Course_CourseId");
            AlterColumn("dbo.Enrollments", "Course_CourseId", c => c.Int());
            CreateIndex("dbo.Enrollments", "Course_CourseId");
            AddForeignKey("dbo.Enrollments", "Course_CourseId", "dbo.Courses", "CourseId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Enrollments", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Enrollments", new[] { "Course_CourseId" });
            AlterColumn("dbo.Enrollments", "Course_CourseId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Enrollments", name: "Course_CourseId", newName: "CourseId");
            CreateIndex("dbo.Enrollments", "CourseId");
            AddForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
