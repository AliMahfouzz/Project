namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableMaterial : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Materials", "FilePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Materials", "FilePath");
        }
    }
}
