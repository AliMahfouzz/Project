namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableattendance2 : DbMigration
    {
        public override void Up()
        {
           
            DropIndex("dbo.Attendances", new[] { "Student_StudentId" });
          
            AddColumn("dbo.Attendances", "FirstName", c => c.String());
            AddColumn("dbo.Attendances", "FatherName", c => c.String());
            AddColumn("dbo.Attendances", "LastName", c => c.String());
            AddColumn("dbo.Attendances", "Gender", c => c.String());
            AddColumn("dbo.Attendances", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "HomeNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "Address", c => c.String());
            AddColumn("dbo.Attendances", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "ParentId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Attendances", "DepartmentId");
            CreateIndex("dbo.Attendances", "ParentId");
            AddForeignKey("dbo.Attendances", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: false);
            AddForeignKey("dbo.Attendances", "ParentId", "dbo.Parents", "ParentId");
           
        }
        
        public override void Down()
        {
            
            DropForeignKey("dbo.Attendances", "ParentId", "dbo.Parents");
            DropForeignKey("dbo.Attendances", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Attendances", new[] { "ParentId" });
            DropIndex("dbo.Attendances", new[] { "DepartmentId" });
            DropColumn("dbo.Attendances", "ParentId");
            DropColumn("dbo.Attendances", "DepartmentId");
            DropColumn("dbo.Attendances", "Address");
            DropColumn("dbo.Attendances", "HomeNumber");
            DropColumn("dbo.Attendances", "DateOfBirth");
            DropColumn("dbo.Attendances", "Gender");
            DropColumn("dbo.Attendances", "LastName");
            DropColumn("dbo.Attendances", "FatherName");
            DropColumn("dbo.Attendances", "FirstName");
          
            
        }
    }
}
