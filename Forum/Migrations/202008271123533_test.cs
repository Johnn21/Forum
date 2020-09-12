namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "Body");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "Body", c => c.String(nullable: false));
        }
    }
}
