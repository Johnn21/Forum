namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PhoneData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PhoneDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhoneName = c.String(nullable: false),
                        BatteryName = c.String(),
                        MemoryRam = c.Int(nullable: false),
                        CameraPixels = c.Int(nullable: false),
                        PostId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PhoneDatas", "PostId", "dbo.Posts");
            DropIndex("dbo.PhoneDatas", new[] { "PostId" });
            DropTable("dbo.PhoneDatas");
        }
    }
}
