namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addedcoverletterdb : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "UserId" });
            CreateTable(
                "dbo.CoverLetters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CoverLetterName = c.String(maxLength: 255),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        datetime = c.DateTime(nullable: false),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            AlterColumn("dbo.Resumes", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Resumes", "UserId");
            AddForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "UserId" });
            DropIndex("dbo.CoverLetters", new[] { "UserId" });
            AlterColumn("dbo.Resumes", "UserId", c => c.String(maxLength: 128));
            DropTable("dbo.CoverLetters");
            CreateIndex("dbo.Resumes", "UserId");
            AddForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
