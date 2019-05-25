namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableMaterial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "file", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "file");
        }
    }
}
