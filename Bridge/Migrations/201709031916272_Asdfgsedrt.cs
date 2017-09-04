namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asdfgsedrt : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "SkillId", c => c.Int(nullable: false));
            CreateIndex("dbo.Referrals", "SkillId");
            AddForeignKey("dbo.Referrals", "SkillId", "dbo.Skills", "SkillId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "SkillId", "dbo.Skills");
            DropIndex("dbo.Referrals", new[] { "SkillId" });
            DropColumn("dbo.Referrals", "SkillId");
        }
    }
}
