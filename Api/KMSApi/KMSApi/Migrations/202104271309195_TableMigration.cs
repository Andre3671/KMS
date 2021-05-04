namespace KMSApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TableMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Vessel_name = c.String(),
                        Shipyard = c.String(),
                        Owner = c.String(),
                        HullNr = c.String(),
                        SalesId = c.Int(nullable: false),
                        Buyer = c.String(),
                        DeliveryDate = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.Parts",
                c => new
                    {
                        PartId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        Name = c.String(),
                        Spec = c.String(),
                    })
                .PrimaryKey(t => t.PartId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "OrderId", "dbo.Orders");
            DropIndex("dbo.Parts", new[] { "OrderId" });
            DropTable("dbo.Parts");
            DropTable("dbo.Orders");
        }
    }
}
