namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingUpGrades : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GradeDetails",
                c => new
                    {
                        GradeDetailId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.GradeDetailId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        grade = c.Double(nullable: false),
                        StudentEmail = c.String(),
                        CourseName = c.String(),
                        Course_CourseId = c.Int(),
                        Student_StudentId = c.String(maxLength: 128),
                        GradeDetail_GradeDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.GradeDetails", t => t.GradeDetail_GradeDetailId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.GradeDetail_GradeDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Grades", "GradeDetail_GradeDetailId", "dbo.GradeDetails");
            DropForeignKey("dbo.Grades", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Grades", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Grades", new[] { "GradeDetail_GradeDetailId" });
            DropIndex("dbo.Grades", new[] { "Student_StudentId" });
            DropIndex("dbo.Grades", new[] { "Course_CourseId" });
            DropTable("dbo.Grades");
            DropTable("dbo.GradeDetails");
        }
    }
}
