using Microsoft.EntityFrameworkCore;

namespace AnimalsFriends.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Баба Марта идва!", Category = Helpers.Classes.BlogCategory.Causes },
                new Post { Id = 2, Title = "Великденски яйца!", Category = Helpers.Classes.BlogCategory.News },
                new Post { Id = 3, Title = "Томи има нужда от лечение!", Category = Helpers.Classes.BlogCategory.News },
                new Post { Id = 4, Title = "Ване се въстановява!", Category = Helpers.Classes.BlogCategory.Causes },
                new Post { Id = 5, Title = "Коледна къщичка!", Category = Helpers.Classes.BlogCategory.Causes });

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, UserId = 1, Name = "Zima", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Бял, пухест и добър!", Species = Helpers.Classes.AnimalSpecies.Dog, ProfileImg = "/Resources/images/zima.jpg" },
                new Animal { Id = 2, UserId = 1, Name = "Buria", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.NeedHome, Description = "Сладък котарак!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = "/Resources/images/zima.jpg" },
                new Animal { Id = 3, UserId = 2, Name = "Terry", Gender = Helpers.Classes.Gender.Male, CurrentStatus = Helpers.Classes.AnimalStatus.Adopted, Description = "Оранжева фурия!", Species = Helpers.Classes.AnimalSpecies.Cat, ProfileImg = "/Resources/images/zima.jpg" });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "danitza@example.com" },
                new User { Id = 2, Email = "niya@example.com" });
        }
    }
}
