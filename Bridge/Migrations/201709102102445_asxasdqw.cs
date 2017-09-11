namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asxasdqw : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReferralStatus", "ReferralStatusType", c => c.String());
            DropColumn("dbo.ReferralStatus", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ReferralStatus", "Status", c => c.String());
            DropColumn("dbo.ReferralStatus", "ReferralStatusType");
        }
    }
}
