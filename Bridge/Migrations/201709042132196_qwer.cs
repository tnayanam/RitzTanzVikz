namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qwer : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ReferralInstances", "ReferralStatus", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ReferralInstances", "ReferralStatus", c => c.Boolean(nullable: false));
        }
    }
}
