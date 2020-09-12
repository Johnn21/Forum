namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "ApplicationUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "ApplicationUserId");
            AddForeignKey("dbo.Posts", "ApplicationUserId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Posts", new[] { "ApplicationUserId" });
            DropColumn("dbo.Posts", "ApplicationUserId");
        }
    }
}
