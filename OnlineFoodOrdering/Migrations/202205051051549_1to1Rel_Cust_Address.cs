namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1to1Rel_Cust_Address : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false),
                        city = c.String(),
                        street = c.String(),
                        appartment = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Customers", t => t.id, cascadeDelete: true)
                .Index(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "id", "dbo.Customers");
            DropIndex("dbo.Addresses", new[] { "id" });
            DropTable("dbo.Addresses");
        }
    }
}
