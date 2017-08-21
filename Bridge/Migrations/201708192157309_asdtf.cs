namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdtf : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "UserId" });
            AlterColumn("dbo.Resumes", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Resumes", "UserId");
            AddForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.Resumes", new[] { "UserId" });
            AlterColumn("dbo.Resumes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Resumes", "UserId");
            AddForeignKey("dbo.Resumes", "UserId", "dbo.AspNetUsers", "Id");
        }
    }
}
