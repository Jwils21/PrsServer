namespace PrsServer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Update1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 30));
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "FirstName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "LastName", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 30));
            AlterColumn("dbo.Users", "Phone", c => c.String(maxLength: 12));
            CreateIndex("dbo.Users", "UserName", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Users", new[] { "UserName" });
            AlterColumn("dbo.Users", "Phone", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Users", "LastName", c => c.String());
            AlterColumn("dbo.Users", "FirstName", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "UserName", c => c.String());
        }
    }
}
