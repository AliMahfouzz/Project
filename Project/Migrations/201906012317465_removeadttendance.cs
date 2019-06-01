namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeadttendance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "Student_StudentId", "dbo.Students");
            DropIndex("dbo.Attendances", new[] { "Course_CourseId" });
            DropIndex("dbo.Attendances", new[] { "Student_StudentId" });
            DropTable("dbo.Attendances");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        date = c.DateTime(nullable: false),
                        StudentEmail = c.String(),
                        Status = c.Boolean(nullable: false),
                        CourseName = c.String(),
                        Course_CourseId = c.Int(),
                        Student_StudentId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.date);
            
            CreateIndex("dbo.Attendances", "Student_StudentId");
            CreateIndex("dbo.Attendances", "Course_CourseId");
            AddForeignKey("dbo.Attendances", "Student_StudentId", "dbo.Students", "StudentId");
            AddForeignKey("dbo.Attendances", "Course_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
