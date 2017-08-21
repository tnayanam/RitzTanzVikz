namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class werd133 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "ReferralId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Referrals", "ReferralId");
        }

        public override void Down()
        {
            AddColumn("dbo.Referrals", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Referrals");
            DropColumn("dbo.Referrals", "ReferralId");
            AddPrimaryKey("dbo.Referrals", "Id");
        }
    }
}
