namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wqvaqwer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.Referrals", "CompanyId");
            AddForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies", "CompanyId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Referrals", new[] { "CompanyId" });
            DropColumn("dbo.Referrals", "CompanyId");
        }
    }
}
