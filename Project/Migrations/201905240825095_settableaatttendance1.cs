namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableaatttendance1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Attendance_date", "dbo.Attendances");
            DropIndex("dbo.Students", new[] { "Attendance_date" });
            AlterColumn("dbo.Attendances", "StudentID", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attendances", "StudentID");
            AddForeignKey("dbo.Attendances", "StudentID", "dbo.Students", "StudentId");
            DropColumn("dbo.Students", "Attendance_date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Attendance_date", c => c.DateTime());
            DropForeignKey("dbo.Attendances", "StudentID", "dbo.Students");
            DropIndex("dbo.Attendances", new[] { "StudentID" });
            AlterColumn("dbo.Attendances", "StudentID", c => c.String());
            CreateIndex("dbo.Students", "Attendance_date");
            AddForeignKey("dbo.Students", "Attendance_date", "dbo.Attendances", "date");
        }
    }
}
