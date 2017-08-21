namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdtfse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CoverLetters", new[] { "UserId" });
            AlterColumn("dbo.CoverLetters", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.CoverLetters", "UserId");
            AddForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.CoverLetters", new[] { "UserId" });
            AlterColumn("dbo.CoverLetters", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CoverLetters", "UserId");
            AddForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
