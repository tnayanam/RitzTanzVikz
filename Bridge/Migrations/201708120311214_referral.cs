namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class referral : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Referrals", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Referrals", "UserId", c => c.Int(nullable: false));
        }
    }
}
