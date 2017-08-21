namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CoverLetters", "CoverLetterName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Resumes", "ResumeName", c => c.String(nullable: false, maxLength: 255));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resumes", "ResumeName", c => c.String(maxLength: 255));
            AlterColumn("dbo.CoverLetters", "CoverLetterName", c => c.String(maxLength: 255));
        }
    }
}
