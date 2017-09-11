namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class minorfix : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.ReferralInstances", newName: "ReferrerInstances");
            AddColumn("dbo.Referrals", "SuccessulReferrerId", c => c.String());
            AddColumn("dbo.ReferrerInstances", "ReferrerInstanceId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.ReferrerInstances", "ReferrerInstanceId");
            DropColumn("dbo.ReferrerInstances", "ReferralStatus");
        }

        public override void Down()
        {
            AddColumn("dbo.ReferrerInstances", "ReferralStatus", c => c.String());
            AddColumn("dbo.ReferrerInstances", "ReferralInstanceId", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.ReferrerInstances");
            DropColumn("dbo.ReferrerInstances", "ReferrerInstanceId");
            DropColumn("dbo.Referrals", "SuccessulReferrerId");
            AddPrimaryKey("dbo.ReferrerInstances", "ReferralInstanceId");
            RenameTable(name: "dbo.ReferrerInstances", newName: "ReferralInstances");
        }
    }
}
