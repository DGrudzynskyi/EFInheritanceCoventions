namespace EFExamples2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Werehouses", "PhoneNumber", c => c.String());
            AddColumn("dbo.Werehouses", "HeadOfficer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Werehouses", "HeadOfficer");
            DropColumn("dbo.Werehouses", "PhoneNumber");
        }
    }
}
