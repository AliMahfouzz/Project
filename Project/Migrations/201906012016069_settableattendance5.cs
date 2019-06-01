namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableattendance5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Attendances", "ParentId", "dbo.Parents");
            DropIndex("dbo.Attendances", new[] { "DepartmentId" });
            DropIndex("dbo.Attendances", new[] { "ParentId" });
           
            
            DropColumn("dbo.Attendances", "FirstName");
            DropColumn("dbo.Attendances", "FatherName");
            DropColumn("dbo.Attendances", "LastName");
            DropColumn("dbo.Attendances", "Gender");
            DropColumn("dbo.Attendances", "DateOfBirth");
            DropColumn("dbo.Attendances", "HomeNumber");
            DropColumn("dbo.Attendances", "Address");
            DropColumn("dbo.Attendances", "DepartmentId");
            DropColumn("dbo.Attendances", "ParentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "ParentId", c => c.String(maxLength: 128));
            AddColumn("dbo.Attendances", "DepartmentId", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "Address", c => c.String());
            AddColumn("dbo.Attendances", "HomeNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Attendances", "DateOfBirth", c => c.DateTime(nullable: false));
            AddColumn("dbo.Attendances", "Gender", c => c.String());
            AddColumn("dbo.Attendances", "LastName", c => c.String());
            AddColumn("dbo.Attendances", "FatherName", c => c.String());
            AddColumn("dbo.Attendances", "FirstName", c => c.String());

            DropIndex("dbo.Attendances", new[] { "StudentID" });

            CreateIndex("dbo.Attendances", "ParentId");
            CreateIndex("dbo.Attendances", "DepartmentId");
            AddForeignKey("dbo.Attendances", "ParentId", "dbo.Parents", "ParentId");
            AddForeignKey("dbo.Attendances", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
