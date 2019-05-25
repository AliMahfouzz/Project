namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabledepartment : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Departments");
        }
    }
}
