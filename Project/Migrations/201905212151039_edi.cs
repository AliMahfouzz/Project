namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edi : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Courses", "DepartmentName", c => c.String());
            DropColumn("dbo.Courses", "Department");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "Department", c => c.String());
            DropColumn("dbo.Courses", "DepartmentName");
        }
    }
}
