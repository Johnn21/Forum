namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredIdentity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "IdentityUserId", "dbo.IdentityUsers");
            DropIndex("dbo.Posts", new[] { "IdentityUserId" });
            AlterColumn("dbo.Posts", "IdentityUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Posts", "IdentityUserId");
            AddForeignKey("dbo.Posts", "IdentityUserId", "dbo.IdentityUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "IdentityUserId", "dbo.IdentityUsers");
            DropIndex("dbo.Posts", new[] { "IdentityUserId" });
            AlterColumn("dbo.Posts", "IdentityUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Posts", "IdentityUserId");
            AddForeignKey("dbo.Posts", "IdentityUserId", "dbo.IdentityUsers", "Id");
        }
    }
}
