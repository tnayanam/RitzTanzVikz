namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies");
            DropIndex("dbo.Referrals", new[] { "CompanyId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Referrals", "CompanyId");
            AddForeignKey("dbo.Referrals", "CompanyId", "dbo.Companies", "Id");
        }
    }
}
