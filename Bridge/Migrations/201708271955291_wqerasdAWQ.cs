namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wqerasdAWQ : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Degrees", "DegreeName", c => c.String());
            AddColumn("dbo.Skills", "SkillName", c => c.String());
            DropColumn("dbo.Degrees", "Name");
            DropColumn("dbo.Skills", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Name", c => c.String());
            AddColumn("dbo.Degrees", "Name", c => c.String());
            DropColumn("dbo.Skills", "SkillName");
            DropColumn("dbo.Degrees", "DegreeName");
        }
    }
}
