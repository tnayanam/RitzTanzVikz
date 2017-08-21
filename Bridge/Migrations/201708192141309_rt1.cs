namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class rt1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Degrees", "DegreeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Degrees", "DegreeId");
        }

        public override void Down()
        {
        }
    }
}
