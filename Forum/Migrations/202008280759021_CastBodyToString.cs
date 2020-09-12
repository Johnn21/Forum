namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CastBodyToString : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Questions", "Body", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Questions", "Body", c => c.Int(nullable: false));
        }
    }
}
