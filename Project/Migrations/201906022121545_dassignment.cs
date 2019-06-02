namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dassignment : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Devoirs", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Devoirs", "StudentId", "dbo.Students");
            DropIndex("dbo.Devoirs", new[] { "StudentId" });
            DropIndex("dbo.Devoirs", new[] { "CourseId" });
            CreateTable(
                "dbo.DAssignments",
                c => new
                    {
                        AssignemntID = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CourseName = c.String(),
                        FilePath = c.String(),
                        StudentEmail = c.String(),
                        Course_CourseId = c.Int(),
                        Student_StudentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AssignemntID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentId);
            
            DropTable("dbo.Devoirs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Devoirs",
                c => new
                    {
                        DevoirId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DevoirId);
            
            DropForeignKey("dbo.DAssignments", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.DAssignments", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.DAssignments", new[] { "Student_StudentId" });
            DropIndex("dbo.DAssignments", new[] { "Course_CourseId" });
            DropTable("dbo.DAssignments");
            CreateIndex("dbo.Devoirs", "CourseId");
            CreateIndex("dbo.Devoirs", "StudentId");
            AddForeignKey("dbo.Devoirs", "StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Devoirs", "CourseId", "dbo.Courses", "CourseId", cascadeDelete: true);
        }
    }
}
