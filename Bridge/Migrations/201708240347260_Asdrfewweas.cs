namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Asdrfewweas : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyName", c => c.String());
            DropColumn("dbo.Companies", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Companies", "Name", c => c.String());
            DropColumn("dbo.Companies", "CompanyName");
        }
    }
}
