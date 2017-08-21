namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arwde : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Referrals", "JobSeekerId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Referrals", "JobSeekerId");
            AddForeignKey("dbo.Referrals", "JobSeekerId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "JobSeekerId", "dbo.AspNetUsers");
            DropIndex("dbo.Referrals", new[] { "JobSeekerId" });
            AlterColumn("dbo.Referrals", "JobSeekerId", c => c.String());
        }
    }
}
