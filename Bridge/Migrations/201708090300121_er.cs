namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class er : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "datetime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Resumes", "datetime");
        }
    }
}
