namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderItem : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FoodItems", "OrderDetail_OrderItemsId", "dbo.OrderDetails");
            DropIndex("dbo.FoodItems", new[] { "OrderDetail_OrderItemsId" });
            CreateIndex("dbo.OrderDetails", "FoodItemId");
            AddForeignKey("dbo.OrderDetails", "FoodItemId", "dbo.FoodItems", "id", cascadeDelete: true);
            DropColumn("dbo.FoodItems", "OrderDetail_OrderItemsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodItems", "OrderDetail_OrderItemsId", c => c.Int());
            DropForeignKey("dbo.OrderDetails", "FoodItemId", "dbo.FoodItems");
            DropIndex("dbo.OrderDetails", new[] { "FoodItemId" });
            CreateIndex("dbo.FoodItems", "OrderDetail_OrderItemsId");
            AddForeignKey("dbo.FoodItems", "OrderDetail_OrderItemsId", "dbo.OrderDetails", "OrderItemsId");
        }
    }
}
