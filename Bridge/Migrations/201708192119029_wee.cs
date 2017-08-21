namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class wee : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Companies", "CompanyId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Companies", "CompanyId");
        }

        public override void Down()
        {
            AddColumn("dbo.Companies", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Companies");
            DropColumn("dbo.Companies", "CompanyId");
            AddPrimaryKey("dbo.Companies", "Id");
        }
    }
}
