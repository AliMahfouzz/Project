namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtableClass : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Classes",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        ClassName = c.String(),
                    })
                .PrimaryKey(t => t.ClassId);
            
            AddColumn("dbo.Courses", "ClassName", c => c.String());
            AddColumn("dbo.Courses", "Class_ClassId", c => c.Int());
            CreateIndex("dbo.Courses", "Class_ClassId");
            AddForeignKey("dbo.Courses", "Class_ClassId", "dbo.Classes", "ClassId");
            DropColumn("dbo.Courses", "Class");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Class", c => c.String());
            DropForeignKey("dbo.Courses", "Class_ClassId", "dbo.Classes");
            DropIndex("dbo.Courses", new[] { "Class_ClassId" });
            DropColumn("dbo.Courses", "Class_ClassId");
            DropColumn("dbo.Courses", "ClassName");
            DropTable("dbo.Classes");
        }
    }
}
