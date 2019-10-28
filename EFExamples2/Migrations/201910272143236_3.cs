namespace EFExamples2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parcels", "Werehouse_Id", "dbo.Werehouses");
            AddColumn("dbo.Parcels", "Cancelled", c => c.Boolean(nullable: false));
            AddColumn("dbo.Parcels", "TargetWerehouse_Id", c => c.Int());
            AddColumn("dbo.Parcels", "Werehouse_Id1", c => c.Int());
            CreateIndex("dbo.Parcels", "TargetWerehouse_Id");
            CreateIndex("dbo.Parcels", "Werehouse_Id1");
            AddForeignKey("dbo.Parcels", "TargetWerehouse_Id", "dbo.Werehouses", "Id");
            AddForeignKey("dbo.Parcels", "Werehouse_Id1", "dbo.Werehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcels", "Werehouse_Id1", "dbo.Werehouses");
            DropForeignKey("dbo.Parcels", "TargetWerehouse_Id", "dbo.Werehouses");
            DropIndex("dbo.Parcels", new[] { "Werehouse_Id1" });
            DropIndex("dbo.Parcels", new[] { "TargetWerehouse_Id" });
            DropColumn("dbo.Parcels", "Werehouse_Id1");
            DropColumn("dbo.Parcels", "TargetWerehouse_Id");
            DropColumn("dbo.Parcels", "Cancelled");
            AddForeignKey("dbo.Parcels", "Werehouse_Id", "dbo.Werehouses", "Id");
        }
    }
}
