namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asdfr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Resumes", "FileName", c => c.String(nullable: false, maxLength: 255));
            AlterColumn("dbo.Resumes", "ContentType", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Resumes", "Content", c => c.Binary(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Resumes", "Content", c => c.Binary());
            AlterColumn("dbo.Resumes", "ContentType", c => c.String(maxLength: 100));
            AlterColumn("dbo.Resumes", "FileName", c => c.String(maxLength: 255));
        }
    }
}
