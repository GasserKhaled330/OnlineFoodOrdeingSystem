namespace OnlineFoodOrdering.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderAddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderAddress", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderAddress");
        }
    }
}
