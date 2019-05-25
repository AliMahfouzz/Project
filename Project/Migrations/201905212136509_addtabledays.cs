namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addtabledays : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Days",
                c => new
                    {
                        DayId = c.Int(nullable: false, identity: true),
                        DayName = c.String(),
                    })
                .PrimaryKey(t => t.DayId);
            
            AlterColumn("dbo.Courses", "Time", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Courses", "Time", c => c.DateTime(nullable: false));
            DropTable("dbo.Days");
        }
    }
}
