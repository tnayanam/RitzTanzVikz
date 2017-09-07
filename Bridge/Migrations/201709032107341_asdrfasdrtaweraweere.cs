namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class asdrfasdrtaweraweere : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "ReferrerId", "dbo.AspNetUsers");
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            CreateTable(
                "dbo.ReferralInstances",
                c => new
                {
                    ReferralInstanceId = c.Int(nullable: false, identity: true),
                    ReferralStatus = c.Boolean(nullable: false),
                    ReferralId = c.Int(nullable: false),
                    ReferrerId = c.String(nullable: false, maxLength: 128),
                })
                .PrimaryKey(t => t.ReferralInstanceId)
                .ForeignKey("dbo.Referrals", t => t.ReferralId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ReferrerId)
                .Index(t => t.ReferralId)
                .Index(t => t.ReferrerId);

            // DropColumn("dbo.Referrals", "ReferrerId");
        }

        public override void Down()
        {
            AddColumn("dbo.Referrals", "ReferrerId", c => c.String(maxLength: 128));
            DropForeignKey("dbo.ReferralInstances", "ReferrerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReferralInstances", "ReferralId", "dbo.Referrals");
            DropIndex("dbo.ReferralInstances", new[] { "ReferrerId" });
            DropIndex("dbo.ReferralInstances", new[] { "ReferralId" });
            DropTable("dbo.ReferralInstances");
            CreateIndex("dbo.Referrals", "ReferrerId");
            AddForeignKey("dbo.Referrals", "ReferrerId", "dbo.AspNetUsers", "Id");
        }
    }
}
