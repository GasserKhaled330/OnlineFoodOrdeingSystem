namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderItemsId = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        FoodItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderItemsId)
                .ForeignKey("dbo.FoodItems", t => t.FoodItemId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.FoodItemId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        OrderStatus = c.Int(nullable: false),
                        OrderTotalAmount = c.Double(nullable: false),
                        OrderPlacedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderDetails", "FoodItemId", "dbo.FoodItems");
            DropIndex("dbo.OrderDetails", new[] { "FoodItemId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderDetails");
        }
    }
}
