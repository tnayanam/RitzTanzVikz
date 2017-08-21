namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wasdfasdrabert : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Resumes", name: "UserId", newName: "CandidateId");
            RenameIndex(table: "dbo.Resumes", name: "IX_UserId", newName: "IX_CandidateId");
            AddColumn("dbo.Referrals", "DegreeId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "DegreeId");
            RenameIndex(table: "dbo.Resumes", name: "IX_CandidateId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Resumes", name: "CandidateId", newName: "UserId");
        }
    }
}
