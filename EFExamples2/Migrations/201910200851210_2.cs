namespace EFExamples2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "AdditionaldDeliveryFee", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.Activities", "SentToWerehouse_Id", c => c.Int());
            AlterColumn("dbo.Activities", "Timestamp", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Werehouses", "Name", c => c.String());
            CreateIndex("dbo.Activities", "SentToWerehouse_Id");
            AddForeignKey("dbo.Activities", "SentToWerehouse_Id", "dbo.Werehouses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "SentToWerehouse_Id", "dbo.Werehouses");
            DropIndex("dbo.Activities", new[] { "SentToWerehouse_Id" });
            AlterColumn("dbo.Werehouses", "Name", c => c.Int(nullable: false));
            AlterColumn("dbo.Activities", "Timestamp", c => c.Int(nullable: false));
            DropColumn("dbo.Activities", "SentToWerehouse_Id");
            DropColumn("dbo.Activities", "AdditionaldDeliveryFee");
        }
    }
}
