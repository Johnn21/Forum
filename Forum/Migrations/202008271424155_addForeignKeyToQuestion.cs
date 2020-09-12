namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addForeignKeyToQuestion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "IdentityUserId", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Questions", "PostId", c => c.Int());
            CreateIndex("dbo.Questions", "IdentityUserId");
            CreateIndex("dbo.Questions", "PostId");
            AddForeignKey("dbo.Questions", "IdentityUserId", "dbo.IdentityUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Questions", "PostId", "dbo.Posts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Questions", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Questions", "IdentityUserId", "dbo.IdentityUsers");
            DropIndex("dbo.Questions", new[] { "PostId" });
            DropIndex("dbo.Questions", new[] { "IdentityUserId" });
            DropColumn("dbo.Questions", "PostId");
            DropColumn("dbo.Questions", "IdentityUserId");
        }
    }
}
