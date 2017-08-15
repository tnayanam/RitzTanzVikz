namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asras : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.Referrals", new[] { "ResumeId" });
            CreateIndex("dbo.Referrals", "CompanyId");
            AddForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Referrals", new[] { "CompanyId" });
            CreateIndex("dbo.Referrals", "ResumeId");
            AddForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes", "Id", cascadeDelete: true);
        }
    }
}
