namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cgfdhjfj : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Referrals", "SuccessulReferrerId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Referrals", "SuccessulReferrerId", c => c.String());
        }
    }
}
