namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdrfasdrtawerawe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "dateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "dateTime");
        }
    }
}
