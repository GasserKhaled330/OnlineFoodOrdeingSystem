namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1to1Rel_Cust_ShopingCart : DbMigration
    {
        public override void Up()
        {
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "id", "dbo.Customers");
            DropIndex("dbo.ShoppingCarts", new[] { "id" });
            DropTable("dbo.ShoppingCarts");
        }
    }
}
