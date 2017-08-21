namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wqvaqwerqwer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "CandidateId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Referrals", "CandidateId");
            AddForeignKey("dbo.Referrals", "CandidateId", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Referrals", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Referrals", "UserId", c => c.String());
            DropForeignKey("dbo.Referrals", "CandidateId", "dbo.AspNetUsers");
            DropIndex("dbo.Referrals", new[] { "CandidateId" });
            DropColumn("dbo.Referrals", "CandidateId");
        }
    }
}
