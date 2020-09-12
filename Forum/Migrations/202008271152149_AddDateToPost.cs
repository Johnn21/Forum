namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateToPost : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Posts", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Posts", "DateAdded");
        }
    }
}
