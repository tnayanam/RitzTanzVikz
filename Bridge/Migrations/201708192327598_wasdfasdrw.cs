namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wasdfasdrw : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Referrals", new[] { "User_Id" });
            DropColumn("dbo.Referrals", "ReferrerId");
            RenameColumn(table: "dbo.Referrals", name: "User_Id", newName: "ReferrerId");
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Referrals", "ReferrerId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Referrals", new[] { "ReferrerId" });
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Referrals", "ReferrerId", c => c.String());
            RenameColumn(table: "dbo.Referrals", name: "ReferrerId", newName: "User_Id");
            AddColumn("dbo.Referrals", "ReferrerId", c => c.String());
            CreateIndex("dbo.Referrals", "User_Id");
        }
    }
}
