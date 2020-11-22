namespace EFExamples2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Parcels", "TargetWerehouse_Id", c => c.Int());
            CreateIndex("dbo.Parcels", "TargetWerehouse_Id");
            AddForeignKey("dbo.Parcels", "TargetWerehouse_Id", "dbo.Werehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcels", "TargetWerehouse_Id", "dbo.Werehouses");
            DropIndex("dbo.Parcels", new[] { "TargetWerehouse_Id" });
            DropColumn("dbo.Parcels", "TargetWerehouse_Id");
        }
    }
}
