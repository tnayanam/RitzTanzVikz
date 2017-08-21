namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wqvfsr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "CoverLetterId", c => c.Int(nullable: false));
            CreateIndex("dbo.Referrals", "CoverLetterId");
            AddForeignKey("dbo.Referrals", "CoverLetterId", "dbo.CoverLetters", "CoverLetterId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "CoverLetterId", "dbo.CoverLetters");
            DropIndex("dbo.Referrals", new[] { "CoverLetterId" });
            DropColumn("dbo.Referrals", "CoverLetterId");
        }
    }
}
