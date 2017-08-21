namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class werd132 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Referrals", "DegreeId");


        }

        public override void Down()
        {
            AddColumn("dbo.Referrals", "DegreeId", c => c.Int(nullable: false));
            AddColumn("dbo.Degrees", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Degrees");
            DropColumn("dbo.Degrees", "DegreeId");
            AddPrimaryKey("dbo.Degrees", "Id");
        }
    }
}
