namespace Bridge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sd : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.JobApplications", newName: "Referrals");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Referrals", newName: "JobApplications");
        }
    }
}
