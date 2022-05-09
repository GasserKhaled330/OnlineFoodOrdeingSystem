namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingQuantity_TotalPriceToCartItem : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CartItems", "quantity", c => c.Int(nullable: false));
            AddColumn("dbo.CartItems", "totalPrice", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.CartItems", "totalPrice");
            DropColumn("dbo.CartItems", "quantity");
        }
    }
}
