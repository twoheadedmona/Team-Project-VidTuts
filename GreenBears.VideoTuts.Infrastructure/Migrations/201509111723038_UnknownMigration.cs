namespace GreenBears.VideoTuts.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UnknownMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "User_ID", "dbo.Users");
            DropIndex("dbo.Users", new[] { "User_ID" });
            DropColumn("dbo.Users", "User_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "User_ID", c => c.Int());
            CreateIndex("dbo.Users", "User_ID");
            AddForeignKey("dbo.Users", "User_ID", "dbo.Users", "ID");
        }
    }
}
