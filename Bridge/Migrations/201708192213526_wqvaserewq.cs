namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wqvaserewq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "ResumeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Referrals", "ResumeId");
            AddForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes", "ResumeId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.Referrals", new[] { "ResumeId" });
            DropColumn("dbo.Referrals", "ResumeId");
        }
    }
}
