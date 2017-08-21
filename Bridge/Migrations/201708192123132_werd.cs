namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class werd : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Skills", "SkillId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Skills", "SkillId");
        }

        public override void Down()
        {
            AddColumn("dbo.Skills", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Skills");
            DropColumn("dbo.Skills", "SkillId");
            AddPrimaryKey("dbo.Skills", "Id");
        }
    }
}
