namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedAspUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id]) VALUES (N'06d73f6a-204a-4df3-b87d-ecd1b4d1df78')
                INSERT INTO [dbo].[AspNetUsers] ([Id]) VALUES (N'079799d8-2b05-4148-a7d1-355366c61bb0')
                INSERT INTO [dbo].[AspNetUsers] ([Id]) VALUES (N'b2d1cc74-404b-4762-b5f2-8312241d8180')


            ");
        }
        
        public override void Down()
        {
        }
    }
}
