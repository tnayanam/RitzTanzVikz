namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Adfcxc : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "IsReferralSuccessful", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "IsReferralSuccessful");
        }
    }
}
