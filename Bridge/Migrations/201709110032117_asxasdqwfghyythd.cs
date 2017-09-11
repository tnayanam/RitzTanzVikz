namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asxasdqwfghyythd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "ReferrerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Referrals", "ReferrerId");
            AddForeignKey("dbo.Referrals", "ReferrerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "ReferrerId", "dbo.AspNetUsers");
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            DropColumn("dbo.Referrals", "ReferrerId");
        }
    }
}
