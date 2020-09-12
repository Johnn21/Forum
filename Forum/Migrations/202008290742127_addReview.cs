namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addReview : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Body = c.String(nullable: false),
                        IdentityUserId = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                        IdentityUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.IdentityUser_Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.IdentityUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "PostId", "dbo.Posts");
            DropForeignKey("dbo.Reviews", "IdentityUser_Id", "dbo.IdentityUsers");
            DropIndex("dbo.Reviews", new[] { "IdentityUser_Id" });
            DropIndex("dbo.Reviews", new[] { "PostId" });
            DropTable("dbo.Reviews");
        }
    }
}
