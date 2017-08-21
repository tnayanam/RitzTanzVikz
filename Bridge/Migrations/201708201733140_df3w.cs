namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class df3w : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Referrals", "ReferrerId");
        }

        public override void Down()
        {
            AddColumn("dbo.Referrals", "CandidateId", c => c.String());
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Referrals", "ReferrerId");
        }
    }
}
