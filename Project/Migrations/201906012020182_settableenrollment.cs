namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableenrollment : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Enrollments", name: "Parent_ParentId", newName: "ParentID");
            RenameColumn(table: "dbo.Enrollments", name: "Student_StudentId", newName: "StudentID");
            RenameIndex(table: "dbo.Enrollments", name: "IX_Student_StudentId", newName: "IX_StudentID");
            RenameIndex(table: "dbo.Enrollments", name: "IX_Parent_ParentId", newName: "IX_ParentID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Enrollments", name: "IX_ParentID", newName: "IX_Parent_ParentId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_StudentID", newName: "IX_Student_StudentId");
            RenameColumn(table: "dbo.Enrollments", name: "StudentID", newName: "Student_StudentId");
            RenameColumn(table: "dbo.Enrollments", name: "ParentID", newName: "Parent_ParentId");
        }
    }
}
