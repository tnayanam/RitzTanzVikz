namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aascd : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.CoverLetters", "FileName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.CoverLetters", "ContentType", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.CoverLetters", "Content", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.CoverLetters", "Content", c => c.Binary());
            AlterColumn("dbo.CoverLetters", "ContentType", c => c.String(maxLength: 100));
            AlterColumn("dbo.CoverLetters", "FileName", c => c.String(maxLength: 255));
        }
    }
}
