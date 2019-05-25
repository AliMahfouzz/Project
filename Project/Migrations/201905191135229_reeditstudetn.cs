namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class reeditstudetn : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Students", new[] { "ParentID" });
            CreateIndex("dbo.Students", "ParentId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Students", new[] { "ParentId" });
            CreateIndex("dbo.Students", "ParentID");
        }
    }
}
