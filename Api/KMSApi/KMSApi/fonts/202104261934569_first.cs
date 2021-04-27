namespace KMSApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Parts", "Order_OrderId", "dbo.Orders");
            DropIndex("dbo.Parts", new[] { "Order_OrderId" });
            RenameColumn(table: "dbo.Parts", name: "Order_OrderId", newName: "OrderId");
            AlterColumn("dbo.Parts", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Parts", "OrderId");
            AddForeignKey("dbo.Parts", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parts", "OrderId", "dbo.Orders");
            DropIndex("dbo.Parts", new[] { "OrderId" });
            AlterColumn("dbo.Parts", "OrderId", c => c.Int());
            RenameColumn(table: "dbo.Parts", name: "OrderId", newName: "Order_OrderId");
            CreateIndex("dbo.Parts", "Order_OrderId");
            AddForeignKey("dbo.Parts", "Order_OrderId", "dbo.Orders", "OrderId");
        }
    }
}
