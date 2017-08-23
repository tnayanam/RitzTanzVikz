namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aer1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "FileName", c => c.String(maxLength: 255));
            AddColumn("dbo.Referrals", "ContentType", c => c.String(maxLength: 100));
            AddColumn("dbo.Referrals", "Content", c => c.Binary());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "Content");
            DropColumn("dbo.Referrals", "ContentType");
            DropColumn("dbo.Referrals", "FileName");
        }
    }
}
