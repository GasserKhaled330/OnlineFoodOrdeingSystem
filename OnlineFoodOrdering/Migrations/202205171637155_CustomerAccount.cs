namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomerAccount : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "UserId", c => c.Int(nullable: true));
            CreateIndex("dbo.Customers", "UserId");
            AddForeignKey("dbo.Customers", "UserId", "dbo.UserAccounts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "UserId", "dbo.UserAccounts");
            DropIndex("dbo.Customers", new[] { "UserId" });
            DropColumn("dbo.Customers", "UserId");
        }
    }
}
