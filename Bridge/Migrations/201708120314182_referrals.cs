namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class referrals : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "UserId");
        }
    }
}
