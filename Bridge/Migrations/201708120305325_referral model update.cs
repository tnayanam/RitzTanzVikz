namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class referralmodelupdate : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Referrals", new[] { "CompanyId" });
            AddColumn("dbo.Referrals", "ReferralName", c => c.String());
            AddColumn("dbo.Referrals", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.Referrals", "DegreeId", c => c.Int(nullable: false));
            AddColumn("dbo.Referrals", "ResumeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "ResumeId");
            DropColumn("dbo.Referrals", "DegreeId");
            DropColumn("dbo.Referrals", "UserId");
            DropColumn("dbo.Referrals", "ReferralName");
            CreateIndex("dbo.Referrals", "CompanyId");
            AddForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies", "Id", cascadeDelete: true);
        }
    }
}
