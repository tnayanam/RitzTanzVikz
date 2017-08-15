namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asrhjg : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Referrals", "ResumeId");
            AddForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.Referrals", new[] { "ResumeId" });
        }
    }
}
