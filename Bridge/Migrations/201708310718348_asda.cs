namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asda : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes");
            AddForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes", "ResumeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes");
            AddForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes", "ResumeId");
        }
    }
}
