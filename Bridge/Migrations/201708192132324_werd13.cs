namespace Bridge.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class werd13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Resumes", "ResumeId", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Resumes", "ResumeId");
        }

        public override void Down()
        {
            AddColumn("dbo.Resumes", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Resumes");
            DropColumn("dbo.Resumes", "ResumeId");
            AddPrimaryKey("dbo.Resumes", "Id");
        }
    }
}
