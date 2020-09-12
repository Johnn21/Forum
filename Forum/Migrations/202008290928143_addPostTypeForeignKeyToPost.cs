namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addPostTypeForeignKeyToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "PostTypeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "PostTypeId");
            AddForeignKey("dbo.Posts", "PostTypeId", "dbo.PostTypes", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "PostTypeId", "dbo.PostTypes");
            DropIndex("dbo.Posts", new[] { "PostTypeId" });
            DropColumn("dbo.Posts", "PostTypeId");
        }
    }
}
