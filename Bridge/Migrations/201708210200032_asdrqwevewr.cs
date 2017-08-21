namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdrqwevewr : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Referrals", "DegreeId");
            AddForeignKey("dbo.Referrals", "DegreeId", "dbo.Degrees", "DegreeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "DegreeId", "dbo.Degrees");
            DropIndex("dbo.Referrals", new[] { "DegreeId" });
        }
    }
}
