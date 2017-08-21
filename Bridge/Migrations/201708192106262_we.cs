namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class we : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.CoverLetters", new[] { "UserId" });
            DropIndex("dbo.Resumes", new[] { "UserId" });
            AlterColumn("dbo.CoverLetters", "UserId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Resumes", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.CoverLetters", "UserId");
            CreateIndex("dbo.Resumes", "UserId");
            DropColumn("dbo.Referrals", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Referrals", "CompanyId", c => c.Int(nullable: false));
            DropIndex("dbo.Resumes", new[] { "UserId" });
            DropIndex("dbo.CoverLetters", new[] { "UserId" });
            AlterColumn("dbo.Resumes", "UserId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.CoverLetters", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Resumes", "UserId");
            CreateIndex("dbo.CoverLetters", "UserId");
        }
    }
}
