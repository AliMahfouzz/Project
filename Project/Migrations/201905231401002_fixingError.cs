namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixingError : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Teachers", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Teachers", new[] { "Course_CourseId" });
            CreateTable(
                "dbo.Materials",
                c => new
                    {
                        MaterialId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        CourseName = c.String(),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.MaterialId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .Index(t => t.Course_CourseId);
            
            DropColumn("dbo.Teachers", "CourseName");
            DropColumn("dbo.Teachers", "Course_CourseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Course_CourseId", c => c.Int());
            AddColumn("dbo.Teachers", "CourseName", c => c.String());
            DropForeignKey("dbo.Materials", "Course_CourseId", "dbo.Courses");
            DropIndex("dbo.Materials", new[] { "Course_CourseId" });
            DropTable("dbo.Materials");
            CreateIndex("dbo.Teachers", "Course_CourseId");
            AddForeignKey("dbo.Teachers", "Course_CourseId", "dbo.Courses", "CourseId");
        }
    }
}
