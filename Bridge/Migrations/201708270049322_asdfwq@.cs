namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfwq : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoverLetters", "CompanyId", c => c.Int(nullable: false));
            CreateIndex("dbo.CoverLetters", "CompanyId");
            AddForeignKey("dbo.CoverLetters", "CompanyId", "dbo.Companies", "CompanyId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CoverLetters", "CompanyId", "dbo.Companies");
            DropIndex("dbo.CoverLetters", new[] { "CompanyId" });
            DropColumn("dbo.CoverLetters", "CompanyId");
        }
    }
}
