namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IntToStringIdUserReview : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Reviews", new[] { "IdentityUser_Id" });
            DropColumn("dbo.Reviews", "IdentityUserId");
            RenameColumn(table: "dbo.Reviews", name: "IdentityUser_Id", newName: "IdentityUserId");
            AlterColumn("dbo.Reviews", "IdentityUserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.Reviews", "IdentityUserId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Reviews", new[] { "IdentityUserId" });
            AlterColumn("dbo.Reviews", "IdentityUserId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Reviews", name: "IdentityUserId", newName: "IdentityUser_Id");
            AddColumn("dbo.Reviews", "IdentityUserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Reviews", "IdentityUser_Id");
        }
    }
}
