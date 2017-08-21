namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class rt11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CoverLetters", "CoverLetterId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.CoverLetters", "CoverLetterId");
        }

        public override void Down()
        {
            AddColumn("dbo.CoverLetters", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.CoverLetters");
            DropColumn("dbo.CoverLetters", "CoverLetterId");
            AddPrimaryKey("dbo.CoverLetters", "Id");
        }
    }
}
