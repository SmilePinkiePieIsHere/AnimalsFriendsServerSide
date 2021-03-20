using Microsoft.EntityFrameworkCore;

namespace AnimalsFriends.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>().HasData(
                new Post { Id = 1, Title = "Баба Марта идва!", Category = Helpers.Types.BlogCategory.Causes },
                new Post { Id = 2, Title = "Великденски яйца!", Category = Helpers.Types.BlogCategory.News },
                new Post { Id = 3, Title = "Томи има нужда от лечение!", Category = Helpers.Types.BlogCategory.News },
                new Post { Id = 4, Title = "Ване се въстановява!", Category = Helpers.Types.BlogCategory.Causes },
                new Post { Id = 5, Title = "Коледна къщичка!", Category = Helpers.Types.BlogCategory.Causes });

            modelBuilder.Entity<Animal>().HasData(
                new Animal { Id = 1, UserId = 1, Name = "Zima", Gender = Helpers.Types.Gender.Male, CurrentStatus = Helpers.Types.AnimalStatus.InMedicalCare, Description = "Бял, пухест и добър!", Species = Helpers.Types.AnimalSpecies.Dog, ProfileImg = "/Resources/images/zima.jpg" },
                new Animal { Id = 2, UserId = 1, Name = "Buria", Gender = Helpers.Types.Gender.Male, CurrentStatus = Helpers.Types.AnimalStatus.NeedHome, Description = "Сладък котарак!", Species = Helpers.Types.AnimalSpecies.Cat, ProfileImg = "/Resources/images/zima.jpg" },
                new Animal { Id = 3, UserId = 2, Name = "Terry", Gender = Helpers.Types.Gender.Male, CurrentStatus = Helpers.Types.AnimalStatus.Adopted, Description = "Оранжева фурия!", Species = Helpers.Types.AnimalSpecies.Cat, ProfileImg = "/Resources/images/zima.jpg" });

            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, Email = "danitza@example.com" },
                new User { Id = 2, Email = "niya@example.com" });
        }
    }
}
