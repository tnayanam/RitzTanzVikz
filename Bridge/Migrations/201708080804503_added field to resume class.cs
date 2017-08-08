namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfieldtoresumeclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "FileName", c => c.String(maxLength: 255));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "FileName");
        }
    }
}
