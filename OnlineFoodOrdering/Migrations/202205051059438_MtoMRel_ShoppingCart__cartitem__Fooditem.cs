namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MtoMRel_ShoppingCart__cartitem__Fooditem : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        shoppingCartId = c.Int(nullable: false),
                        foodItemId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.shoppingCartId, t.foodItemId })
                .ForeignKey("dbo.FoodItems", t => t.foodItemId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.shoppingCartId, cascadeDelete: true)
                .Index(t => t.shoppingCartId)
                .Index(t => t.foodItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "shoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.CartItems", "foodItemId", "dbo.FoodItems");
            DropIndex("dbo.CartItems", new[] { "foodItemId" });
            DropIndex("dbo.CartItems", new[] { "shoppingCartId" });
            DropTable("dbo.CartItems");
        }
    }
}
