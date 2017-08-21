namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class df3ww : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Referrals", "CandidateId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Referrals", "CandidateId");
        }
    }
}
