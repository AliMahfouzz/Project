namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class settableattendance : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attendances", "StudentEmail", c => c.String());
            DropColumn("dbo.Attendances", "Email");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Email", c => c.String());
            DropColumn("dbo.Attendances", "StudentEmail");
        }
    }
}
