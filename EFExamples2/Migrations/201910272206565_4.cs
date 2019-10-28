namespace EFExamples2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _4 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Parcels", "Value", c => c.Decimal(nullable: false, precision: 10, scale: 2));
            AlterColumn("dbo.Parcels", "Weight", c => c.Decimal(nullable: false, precision: 10, scale: 3));
            AlterColumn("dbo.Parcels", "DeliveryFee", c => c.Decimal(nullable: false, precision: 10, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Parcels", "DeliveryFee", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Parcels", "Weight", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Parcels", "Value", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
