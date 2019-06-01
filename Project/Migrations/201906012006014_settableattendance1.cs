namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableattendance1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Attendances", name: "StudentID", newName: "Student_StudentId");
            RenameIndex(table: "dbo.Attendances", name: "IX_StudentID", newName: "IX_Student_StudentId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Attendances", name: "IX_Student_StudentId", newName: "IX_StudentID");
            RenameColumn(table: "dbo.Attendances", name: "Student_StudentId", newName: "StudentID");
        }
    }
}
