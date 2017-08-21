namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class werd1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes");
            DropIndex("dbo.Referrals", new[] { "ResumeId" });
            DropColumn("dbo.Referrals", "ResumeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Referrals", "ResumeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Referrals", "ResumeId");
            AddForeignKey("dbo.Referrals", "ResumeId", "dbo.Resumes", "Id", cascadeDelete: true);
        }
    }
}
