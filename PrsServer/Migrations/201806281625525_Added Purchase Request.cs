namespace PrsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPurchaseRequest : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "Status", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "Status", c => c.String(nullable: false, maxLength: 30));
        }
    }
}
