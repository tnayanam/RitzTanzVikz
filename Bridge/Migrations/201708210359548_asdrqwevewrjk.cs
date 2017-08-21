namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdrqwevewrjk : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Referrals", "ReferrerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Referrals", "ReferrerId");
        }
    }
}
