namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wqvaqasdf : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Referrals", new[] { "CandidateId" });
            AddColumn("dbo.Referrals", "ReferrerId", c => c.String());
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Referrals", "CandidateId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Referrals", new[] { "CandidateId" });
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Referrals", "ReferrerId");
            CreateIndex("dbo.Referrals", "CandidateId");
        }
    }
}
