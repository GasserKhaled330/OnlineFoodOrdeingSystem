namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.FoodItems", "description", c => c.String(nullable: false));
            AddColumn("dbo.FoodItems", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.FoodItems", "ImageData", c => c.Binary());
            AddColumn("dbo.FoodItems", "ImageMimeType", c => c.String());
            AlterColumn("dbo.FoodItems", "name", c => c.String(nullable: false));
            CreateIndex("dbo.FoodItems", "CategoryId");
            AddForeignKey("dbo.FoodItems", "CategoryId", "dbo.Categories", "id", cascadeDelete: true);
            DropColumn("dbo.FoodItems", "foodItemImage");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FoodItems", "foodItemImage", c => c.String());
            DropForeignKey("dbo.FoodItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.FoodItems", new[] { "CategoryId" });
            AlterColumn("dbo.FoodItems", "name", c => c.String());
            DropColumn("dbo.FoodItems", "ImageMimeType");
            DropColumn("dbo.FoodItems", "ImageData");
            DropColumn("dbo.FoodItems", "CategoryId");
            DropColumn("dbo.FoodItems", "description");
            DropTable("dbo.Categories");
        }
    }
}
