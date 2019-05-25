namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insertOfTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        date = c.DateTime(nullable: false),
                        StudentID = c.String(maxLength: 128),
                        Email = c.String(),
                        Status = c.Boolean(nullable: false),
                        CourseId = c.Int(nullable: false),
                        CourseName = c.String(),
                    })
                .PrimaryKey(t => t.date)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .Index(t => t.StudentID)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        Department = c.String(),
                        Class = c.String(),
                        Time = c.DateTime(nullable: false),
                        Grade = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CourseId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        FatherName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        HomeNumber = c.Int(nullable: false),
                        Address = c.String(),
                        Department = c.String(),
                        Email = c.String(),
                        ParentID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.StudentId)
                .ForeignKey("dbo.Parents", t => t.ParentID)
                .Index(t => t.ParentID);
            
            CreateTable(
                "dbo.Parents",
                c => new
                    {
                        ParentId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Gender = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.ParentId);
            
            CreateTable(
                "dbo.Enrollments",
                c => new
                    {
                        EnrollmentId = c.Int(nullable: false, identity: true),
                        StudentID = c.String(maxLength: 128),
                        ParentID = c.String(maxLength: 128),
                        TeacherID = c.String(maxLength: 128),
                        CourseId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.EnrollmentId)
                .ForeignKey("dbo.Courses", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Parents", t => t.ParentID)
                .ForeignKey("dbo.Students", t => t.StudentID)
                .ForeignKey("dbo.Teachers", t => t.TeacherID)
                .Index(t => t.StudentID)
                .Index(t => t.ParentID)
                .Index(t => t.TeacherID)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Gender = c.String(),
                        Email = c.String(),
                        Address = c.String(),
                        PhoneNumber = c.Int(nullable: false),
                        Degree = c.String(),
                        Department = c.String(),
                        CourseName = c.String(),
                        CourseClass = c.String(),
                        CourseTime = c.DateTime(nullable: false),
                        Course_CourseId = c.Int(),
                    })
                .PrimaryKey(t => t.TeacherId)
                .ForeignKey("dbo.Courses", t => t.Course_CourseId)
                .Index(t => t.Course_CourseId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Enrollments", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Course_CourseId", "dbo.Courses");
            DropForeignKey("dbo.Enrollments", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Enrollments", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.Enrollments", "CourseId", "dbo.Courses");
            DropForeignKey("dbo.Attendances", "StudentID", "dbo.Students");
            DropForeignKey("dbo.Students", "ParentID", "dbo.Parents");
            DropForeignKey("dbo.Attendances", "CourseId", "dbo.Courses");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Teachers", new[] { "Course_CourseId" });
            DropIndex("dbo.Enrollments", new[] { "CourseId" });
            DropIndex("dbo.Enrollments", new[] { "TeacherID" });
            DropIndex("dbo.Enrollments", new[] { "ParentID" });
            DropIndex("dbo.Enrollments", new[] { "StudentID" });
            DropIndex("dbo.Students", new[] { "ParentID" });
            DropIndex("dbo.Attendances", new[] { "CourseId" });
            DropIndex("dbo.Attendances", new[] { "StudentID" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Teachers");
            DropTable("dbo.Enrollments");
            DropTable("dbo.Parents");
            DropTable("dbo.Students");
            DropTable("dbo.Courses");
            DropTable("dbo.Attendances");
        }
    }
}
