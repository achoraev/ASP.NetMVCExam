namespace ForumSystem.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ForumSystem.Data.Models;

    public sealed class Configuration : DbMigrationsConfiguration<ApplicationDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;

            // TODO: Remove in production
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ApplicationDbContext context)
        {
            // this.SeedPost(context);
        }

        private void SeedPost(ApplicationDbContext context)
        {
            for (int i = 0; i < 10; i++)
            {
                context.Posts.AddOrUpdate(
                    a => a.Id,
                new Post
                {
                    Title = "First" + i,
                    Content = "Test post" + i,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
            }

            for (int j = 0; j < 30; j++)
            {
                context.Tags.AddOrUpdate(
                    a => a.Id,
                    new Tag
                {
                    Name = "Test tag" + j,
                    IsDeleted = false,
                    CreatedOn = DateTime.Now
                });
            }
        }
    }
}
