namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TabletData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TabletDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TabletName = c.String(nullable: false),
                        ScreenSize = c.Int(nullable: false),
                        InternalMemory = c.String(nullable: false),
                        CameraPixels = c.Int(nullable: false),
                        BatteryName = c.String(),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TabletDatas", "PostId", "dbo.Posts");
            DropIndex("dbo.TabletDatas", new[] { "PostId" });
            DropTable("dbo.TabletDatas");
        }
    }
}
