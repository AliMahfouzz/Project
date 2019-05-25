namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableassignee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Assignees",
                c => new
                    {
                        AssigneeId = c.Int(nullable: false, identity: true),
                        TeacherEmail = c.String(),
                        CourseName = c.String(),
                        CourseId = c.Int(nullable: false),
                        Teacher_TeacherId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.AssigneeId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_TeacherId)
                .Index(t => t.CourseId)
                .Index(t => t.Teacher_TeacherId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Assignees", "Teacher_TeacherId", "dbo.Teachers");
            DropForeignKey("dbo.Assignees", "CourseId", "dbo.Courses");
            DropIndex("dbo.Assignees", new[] { "Teacher_TeacherId" });
            DropIndex("dbo.Assignees", new[] { "CourseId" });
            DropTable("dbo.Assignees");
        }
    }
}
