namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "JobSeekerId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "JobSeekerId");
        }
    }
}
