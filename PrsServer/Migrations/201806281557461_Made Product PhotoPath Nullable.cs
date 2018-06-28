namespace PrsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeProductPhotoPathNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "PhotoPath", c => c.String(nullable: false, maxLength: 120));
        }
    }
}
