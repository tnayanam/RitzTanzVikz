namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfasdefasdrtfqwsedr : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ReferralStatus",
                c => new
                    {
                        ReferralStatusId = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ReferralStatusId);
            
            AddColumn("dbo.ReferralInstances", "ReferralStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.ReferralInstances", "ReferralStatusId");
            AddForeignKey("dbo.ReferralInstances", "ReferralStatusId", "dbo.ReferralStatus", "ReferralStatusId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReferralInstances", "ReferralStatusId", "dbo.ReferralStatus");
            DropIndex("dbo.ReferralInstances", new[] { "ReferralStatusId" });
            DropColumn("dbo.ReferralInstances", "ReferralStatusId");
            DropTable("dbo.ReferralStatus");
        }
    }
}
