namespace EFExamples2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Activities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Timestamp = c.Int(nullable: false),
                        IsReverted = c.Boolean(nullable: false),
                        Price = c.Decimal(precision: 18, scale: 2),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        ExpectedDeliveryFee = c.Decimal(precision: 18, scale: 2),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Parcel_Id = c.Int(),
                        Werehouse_Id = c.Int(),
                        TargetWerehouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Parcels", t => t.Parcel_Id)
                .ForeignKey("dbo.Werehouses", t => t.Werehouse_Id)
                .ForeignKey("dbo.Werehouses", t => t.TargetWerehouse_Id)
                .Index(t => t.Parcel_Id)
                .Index(t => t.Werehouse_Id)
                .Index(t => t.TargetWerehouse_Id);
            
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DeliveryFee = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Werehouse_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Werehouses", t => t.Werehouse_Id)
                .Index(t => t.Werehouse_Id);
            
            CreateTable(
                "dbo.Werehouses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.Int(nullable: false),
                        City = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "TargetWerehouse_Id", "dbo.Werehouses");
            DropForeignKey("dbo.Activities", "Werehouse_Id", "dbo.Werehouses");
            DropForeignKey("dbo.Parcels", "Werehouse_Id", "dbo.Werehouses");
            DropForeignKey("dbo.Activities", "Parcel_Id", "dbo.Parcels");
            DropIndex("dbo.Parcels", new[] { "Werehouse_Id" });
            DropIndex("dbo.Activities", new[] { "TargetWerehouse_Id" });
            DropIndex("dbo.Activities", new[] { "Werehouse_Id" });
            DropIndex("dbo.Activities", new[] { "Parcel_Id" });
            DropTable("dbo.Werehouses");
            DropTable("dbo.Parcels");
            DropTable("dbo.Activities");
        }
    }
}
