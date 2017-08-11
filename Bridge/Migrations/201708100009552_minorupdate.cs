namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class minorupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers");
            AddForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.CoverLetters", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
