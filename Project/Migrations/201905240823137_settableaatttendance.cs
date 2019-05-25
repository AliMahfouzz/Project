namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableaatttendance : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "StudentID", "dbo.Students");
            DropIndex("dbo.Attendances", new[] { "StudentID" });
            AddColumn("dbo.Students", "Attendance_date", c => c.DateTime());
            AlterColumn("dbo.Attendances", "StudentID", c => c.String());
            CreateIndex("dbo.Students", "Attendance_date");
            AddForeignKey("dbo.Students", "Attendance_date", "dbo.Attendances", "date");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "Attendance_date", "dbo.Attendances");
            DropIndex("dbo.Students", new[] { "Attendance_date" });
            AlterColumn("dbo.Attendances", "StudentID", c => c.String(maxLength: 128));
            DropColumn("dbo.Students", "Attendance_date");
            CreateIndex("dbo.Attendances", "StudentID");
            AddForeignKey("dbo.Attendances", "StudentID", "dbo.Students", "StudentId");
        }
    }
}
