namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class wasdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "User_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Referrals", "User_Id");
            AddForeignKey("dbo.Referrals", "User_Id", "dbo.AspNetUsers", "Id");
        }

        public override void Down()
        {
            DropForeignKey("dbo.Referrals", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Referrals", new[] { "User_Id" });
            AlterColumn("dbo.Referrals", "CandidateId", c => c.String(maxLength: 128));
            DropColumn("dbo.Referrals", "User_Id");
            CreateIndex("dbo.Referrals", "CandidateId");
            AddForeignKey("dbo.Referrals", "CandidateId", "dbo.AspNetUsers", "Id");
        }
    }
}
