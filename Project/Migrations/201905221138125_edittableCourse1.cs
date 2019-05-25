namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableCourse1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Courses", "ClassName");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Courses", "ClassName");
        }
    }
}
