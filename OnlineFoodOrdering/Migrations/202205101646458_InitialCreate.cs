namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItems",
                c => new
                    {
                        shoppingCartId = c.Int(nullable: false),
                        foodItemId = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        totalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.shoppingCartId, t.foodItemId })
                .ForeignKey("dbo.FoodItems", t => t.foodItemId, cascadeDelete: true)
                .ForeignKey("dbo.ShoppingCarts", t => t.shoppingCartId, cascadeDelete: true)
                .Index(t => t.shoppingCartId)
                .Index(t => t.foodItemId);
            
            CreateTable(
                "dbo.FoodItems",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        price = c.Double(nullable: false),
                        foodItemImage = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        id = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        totalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.id, cascadeDelete: true)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        customerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        contactNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.customerId);
            
            CreateTable(
                "dbo.RoleMasters",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RollName = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.UserRolesMappings",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userID = c.Int(nullable: false),
                        roleID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RoleMasters", t => t.roleID, cascadeDelete: true)
                .ForeignKey("dbo.UserAccounts", t => t.userID, cascadeDelete: true)
                .Index(t => t.userID)
                .Index(t => t.roleID);
            
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        UserPassword = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserRolesMappings", "userID", "dbo.UserAccounts");
            DropForeignKey("dbo.UserRolesMappings", "roleID", "dbo.RoleMasters");
            DropForeignKey("dbo.ShoppingCarts", "id", "dbo.Customers");
            DropForeignKey("dbo.CartItems", "shoppingCartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.CartItems", "foodItemId", "dbo.FoodItems");
            DropIndex("dbo.UserRolesMappings", new[] { "roleID" });
            DropIndex("dbo.UserRolesMappings", new[] { "userID" });
            DropIndex("dbo.ShoppingCarts", new[] { "id" });
            DropIndex("dbo.CartItems", new[] { "foodItemId" });
            DropIndex("dbo.CartItems", new[] { "shoppingCartId" });
            DropTable("dbo.UserAccounts");
            DropTable("dbo.UserRolesMappings");
            DropTable("dbo.RoleMasters");
            DropTable("dbo.Customers");
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.FoodItems");
            DropTable("dbo.CartItems");
        }
    }
}
