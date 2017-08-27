namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class se : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "CoverLetterId", "dbo.CoverLetters");
            DropIndex("dbo.Referrals", new[] { "CoverLetterId" });
            AlterColumn("dbo.Referrals", "CoverLetterId", c => c.Int());
            CreateIndex("dbo.Referrals", "CoverLetterId");
            AddForeignKey("dbo.Referrals", "CoverLetterId", "dbo.CoverLetters", "CoverLetterId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "CoverLetterId", "dbo.CoverLetters");
            DropIndex("dbo.Referrals", new[] { "CoverLetterId" });
            AlterColumn("dbo.Referrals", "CoverLetterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Referrals", "CoverLetterId");
            AddForeignKey("dbo.Referrals", "CoverLetterId", "dbo.CoverLetters", "CoverLetterId", cascadeDelete: true);
        }
    }
}
