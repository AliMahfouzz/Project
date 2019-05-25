namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editcoursetable2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "StartTime", c => c.String());
            AddColumn("dbo.Courses", "EndTime", c => c.String());
            DropColumn("dbo.Courses", "Time");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Time", c => c.String());
            DropColumn("dbo.Courses", "EndTime");
            DropColumn("dbo.Courses", "StartTime");
        }
    }
}
