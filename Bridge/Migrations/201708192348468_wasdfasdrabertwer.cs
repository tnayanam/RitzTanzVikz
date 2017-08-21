namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wasdfasdrabertwer : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CoverLetters", name: "UserId", newName: "CandidateId");
            RenameIndex(table: "dbo.CoverLetters", name: "IX_UserId", newName: "IX_CandidateId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CoverLetters", name: "IX_CandidateId", newName: "IX_UserId");
            RenameColumn(table: "dbo.CoverLetters", name: "CandidateId", newName: "UserId");
        }
    }
}
