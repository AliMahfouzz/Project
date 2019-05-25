namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableMaterial2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Materials", "file");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Materials", "file", c => c.Binary());
        }
    }
}
