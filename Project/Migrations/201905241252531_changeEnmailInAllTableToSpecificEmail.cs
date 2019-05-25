namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeEnmailInAllTableToSpecificEmail : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Enrollments", name: "ParentID", newName: "Parent_ParentId");
            RenameColumn(table: "dbo.Enrollments", name: "StudentID", newName: "Student_StudentId");
            RenameColumn(table: "dbo.Enrollments", name: "TeacherID", newName: "Teacher_TeacherId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_ParentID", newName: "IX_Parent_ParentId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_StudentID", newName: "IX_Student_StudentId");
            RenameIndex(table: "dbo.Enrollments", name: "IX_TeacherID", newName: "IX_Teacher_TeacherId");
            AddColumn("dbo.Students", "StudentEmail", c => c.String());
            AddColumn("dbo.Parents", "ParentEmail", c => c.String());
            AddColumn("dbo.Enrollments", "StudentEmail", c => c.String());
            AddColumn("dbo.Enrollments", "ParentEmail", c => c.String());
            AddColumn("dbo.Enrollments", "TeacherEmail", c => c.String());
            AddColumn("dbo.Enrollments", "CourseName", c => c.String());
            AddColumn("dbo.Teachers", "TeacherEmail", c => c.String());
            DropColumn("dbo.Students", "Email");
            DropColumn("dbo.Parents", "Email");
            DropColumn("dbo.Teachers", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Teachers", "Email", c => c.String());
            AddColumn("dbo.Parents", "Email", c => c.String());
            AddColumn("dbo.Students", "Email", c => c.String());
            DropColumn("dbo.Teachers", "TeacherEmail");
            DropColumn("dbo.Enrollments", "CourseName");
            DropColumn("dbo.Enrollments", "TeacherEmail");
            DropColumn("dbo.Enrollments", "ParentEmail");
            DropColumn("dbo.Enrollments", "StudentEmail");
            DropColumn("dbo.Parents", "ParentEmail");
            DropColumn("dbo.Students", "StudentEmail");
            RenameIndex(table: "dbo.Enrollments", name: "IX_Teacher_TeacherId", newName: "IX_TeacherID");
            RenameIndex(table: "dbo.Enrollments", name: "IX_Student_StudentId", newName: "IX_StudentID");
            RenameIndex(table: "dbo.Enrollments", name: "IX_Parent_ParentId", newName: "IX_ParentID");
            RenameColumn(table: "dbo.Enrollments", name: "Teacher_TeacherId", newName: "TeacherID");
            RenameColumn(table: "dbo.Enrollments", name: "Student_StudentId", newName: "StudentID");
            RenameColumn(table: "dbo.Enrollments", name: "Parent_ParentId", newName: "ParentID");
        }
    }
}
