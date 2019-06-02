namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SettingUpAttendance : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttendanceDetails",
                c => new
                    {
                        AttendanceDetailId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.AttendanceDetailId);
            
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        date = c.DateTime(nullable: false),
                        Status = c.String(),
                        Remark = c.String(),
                        StudentEmail = c.String(),
                        CourseName = c.String(),
                        Course_CourseId = c.Int(),
                        Student_StudentId = c.String(maxLength: 128),
                        AttendanceDetail_AttendanceDetailId = c.Int(),
                    })
                .PrimaryKey(t => t.date)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .ForeignKey("dbo.Students", t => t.Student_StudentId)
                .ForeignKey("dbo.AttendanceDetails", t => t.AttendanceDetail_AttendanceDetailId)
                .Index(t => t.Course_CourseId)
                .Index(t => t.Student_StudentId)
                .Index(t => t.AttendanceDetail_AttendanceDetailId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "AttendanceDetail_AttendanceDetailId", "dbo.AttendanceDetails");
            DropForeignKey("dbo.Attendances", "Student_StudentId", "dbo.Students");
            DropForeignKey("dbo.Attendances", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Attendances", new[] { "AttendanceDetail_AttendanceDetailId" });
            DropIndex("dbo.Attendances", new[] { "Student_StudentId" });
            DropIndex("dbo.Attendances", new[] { "Course_CourseId" });
            DropTable("dbo.Attendances");
            DropTable("dbo.AttendanceDetails");
        }
    }
}
