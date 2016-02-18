namespace GreenBears.VideoTuts.Infrastructure.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Username = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Image = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAproved = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
            CreateTable(
                "dbo.Videos",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Description = c.String(),
                        Url = c.String(nullable: false),
                        Views = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAproved = c.Boolean(nullable: false),
                        User_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Users", t => t.User_ID)
                .Index(t => t.User_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "User_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "User_ID", "dbo.Users");
            DropIndex("dbo.Videos", new[] { "User_ID" });
            DropIndex("dbo.Users", new[] { "User_ID" });
            DropTable("dbo.Videos");
            DropTable("dbo.Users");
            DropTable("dbo.Admins");
        }
    }
}
