namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df3wwasse : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Referrals", new[] { "JobSeekerId" });
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            DropColumn("dbo.Referrals", "CandidateId");
            RenameColumn(table: "dbo.Referrals", name: "JobSeekerId", newName: "CandidateId");
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Referrals", "CandidateId");
            CreateIndex("dbo.Referrals", "ReferrerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            DropIndex("dbo.Referrals", new[] { "CandidateId" });
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String());
            RenameColumn(table: "dbo.Referrals", name: "CandidateId", newName: "JobSeekerId");
            AddColumn("dbo.Referrals", "CandidateId", c => c.String());
            CreateIndex("dbo.Referrals", "ReferrerId");
            CreateIndex("dbo.Referrals", "JobSeekerId");
        }
    }
}
