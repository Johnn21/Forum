namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBodyToPos : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "Body", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Posts", "Name", c => c.String());
            DropColumn("dbo.Posts", "Body");
        }
    }
}
