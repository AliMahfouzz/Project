namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class remtable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Devoirs", "File_id", "dbo.UploadFiles");
            DropIndex("dbo.Devoirs", new[] { "File_id" });
            DropColumn("dbo.Devoirs", "FileName");
            DropColumn("dbo.Devoirs", "File_id");
            DropTable("dbo.UploadFiles");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UploadFiles",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        FilePath = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Devoirs", "File_id", c => c.Int());
            AddColumn("dbo.Devoirs", "FileName", c => c.String());
            CreateIndex("dbo.Devoirs", "File_id");
            AddForeignKey("dbo.Devoirs", "File_id", "dbo.UploadFiles", "id");
        }
    }
}
