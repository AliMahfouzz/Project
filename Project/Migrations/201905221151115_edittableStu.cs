namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edittableStu : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "Department_DepartmentId" });
            RenameColumn(table: "dbo.Students", name: "Department_DepartmentId", newName: "DepartmentId");
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "DepartmentId");
            AddForeignKey("dbo.Students", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
            DropColumn("dbo.Students", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Name", c => c.String());
            DropForeignKey("dbo.Students", "DepartmentId", "dbo.Departments");
            DropIndex("dbo.Students", new[] { "DepartmentId" });
            AlterColumn("dbo.Students", "DepartmentId", c => c.Int());
            RenameColumn(table: "dbo.Students", name: "DepartmentId", newName: "Department_DepartmentId");
            CreateIndex("dbo.Students", "Department_DepartmentId");
            AddForeignKey("dbo.Students", "Department_DepartmentId", "dbo.Departments", "DepartmentId");
        }
    }
}
