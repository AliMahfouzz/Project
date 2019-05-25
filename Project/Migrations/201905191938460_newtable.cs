namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newtable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devoirs",
                c => new
                    {
                        DevoirId = c.Int(nullable: false, identity: true),
                        StudentId = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DevoirId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentId)
                .Index(t => t.StudentId)
                .Index(t => t.CourseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devoirs", "StudentId", "dbo.Students");
            DropForeignKey("dbo.Devoirs", "CourseId", "dbo.Courses");
            DropIndex("dbo.Devoirs", new[] { "CourseId" });
            DropIndex("dbo.Devoirs", new[] { "StudentId" });
            DropTable("dbo.Devoirs");
        }
    }
}
