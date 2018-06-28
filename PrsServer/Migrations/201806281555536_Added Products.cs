namespace PrsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProducts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PartNumber = c.String(nullable: false, maxLength: 30),
                        Name = c.String(nullable: false, maxLength: 60),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Unit = c.String(nullable: false, maxLength: 30),
                        PhotoPath = c.String(nullable: false, maxLength: 120),
                        Active = c.Boolean(nullable: false),
                        VendorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Phone", c => c.String(nullable: false, maxLength: 12));
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Products", new[] { "VendorId" });
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 12));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
            DropTable("dbo.Products");
        }
    }
}
