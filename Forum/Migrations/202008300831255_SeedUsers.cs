namespace Forum.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                
                INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'06d73f6a-204a-4df3-b87d-ecd1b4d1df78', N'admin@forum.com', 0, N'ADeqTPPdH6eMbWkxvNZcx/hrMtJROcCvf21IpHDGi45UWwpKmoZBe/p3zgX9Uvd9Ng==', N'11dc6831-56be-4aef-9520-ad7ad00deab4', NULL, 0, 0, NULL, 1, 0, N'admin@forum.com')
                INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'079799d8-2b05-4148-a7d1-355366c61bb0', N'guest1@vidly.com', 0, N'AA8UKg1QqpKM/o5cqxWjDpFQV07Ho/DOaDc3aN8MR17gCfd9VfBHxR0U6cFvfpZKAg==', N'cf048767-8e46-47b7-b5f9-ebe7bda1a465', NULL, 0, 0, NULL, 1, 0, N'guest1@vidly.com')
                INSERT INTO [dbo].[IdentityUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'b2d1cc74-404b-4762-b5f2-8312241d8180', N'guest@vidly.com', 0, N'ACToB3QWUsJTfGjnKcrz7xCqe2vKdTqBOvRZ8Kjz9IML1Xsyahi14mO1jEoHV8pZrw==', N'c906500b-e7b7-4863-98ae-c91299fff93d', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'b2fd1d0d-a5c6-4fd5-9c4c-986df91e6e73', N'CanDeletePosts')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId], [IdentityUser_Id]) VALUES (N'06d73f6a-204a-4df3-b87d-ecd1b4d1df78', N'b2fd1d0d-a5c6-4fd5-9c4c-986df91e6e73', NULL)


            ");
        }
        
        public override void Down()
        {
        }
    }
}
 